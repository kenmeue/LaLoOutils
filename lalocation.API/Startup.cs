using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using lalocation.API.Data;
using lalocation.API.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace lalocation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<DbContext,DataContext>();
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opt => {
                    opt.SerializerSettings.ReferenceLoopHandling = 
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
                
            services.AddCors();
            services.AddAutoMapper();
            services.AddTransient<Seed>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ILalocationRepository, LalocationRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey (Encoding.ASCII
                         .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                         ValidateIssuer = false,
                         ValidateAudience = false
                    };
                });
           
           // Register the Swagger generator, defining one or more Swagger documents  
      services.AddSwaggerGen(c =>  
      {  
            // var v1Info = new OpenApiInfo { Version = "v2", Title = "API V2" };
            // var v2Info = new OpenApiInfo { Version = "v1", Title = "API V1" };

            // var subject = Subject(
            //     setupApis: apis =>
            //     {
            //         apis.Add("GET", "v1/collection", nameof(FakeController.ReturnsEnumerable));
            //         apis.Add("GET", "v2/collection", nameof(FakeController.ReturnsEnumerable));
            //     },
            //     setupAction: c =>
            //     {
            //         c.SwaggerDocs.Clear();
            //         c.SwaggerDocs.Add("v1", v1Info);
            //         c.SwaggerDocs.Add("v2", v2Info);
            //         c.DocInclusionPredicate = (docName, api) => api.RelativePath.StartsWith(docName);
            //     });

            // var v1Swagger = subject.GetSwagger("v1");
            // var v2Swagger = subject.GetSwagger("v2");


        c.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "API V1" });  
      });  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seed seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
              //  app.UseHsts();
              app.UseExceptionHandler(builder => {
                  builder.Run(async context => {
                      context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                      var error = context.Features.Get<IExceptionHandlerFeature>();
                      if (error != null)
                      {
                          context.Response.AddApplicationError(error.Error.Message);
                          await context.Response.WriteAsync(error.Error.Message);
                      }
                  });
              });
            }
            seeder.SeedAll();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
           // app.UseHttpsRedirection();

           // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lalocation API V1");
            });
            app.UseMvc();
        }
    }
}
