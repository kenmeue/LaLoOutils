using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using lalocation.API.Data;
using lalocation.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lalocation.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly ILalocationRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(ILalocationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers() {
            var usersFromRepo = await _repo.GetUsers();
            var userstoReturn = _mapper.Map<IEnumerable<UserForListDto>>(usersFromRepo);
            return Ok(userstoReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id) {
            var userFromRepo = await _repo.GetUser(id);
            var usertoReturn = _mapper.Map<UserForDetailedDto>(userFromRepo);
            return Ok(usertoReturn);
        }
    }
}