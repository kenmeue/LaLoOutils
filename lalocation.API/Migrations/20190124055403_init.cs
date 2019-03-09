using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lalocation.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<string>(nullable: true),
                    Complement = table.Column<string>(nullable: true),
                    CodePostal = table.Column<string>(nullable: true),
                    Ville = table.Column<string>(nullable: true),
                    Pays = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BienStatuts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BienStatuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BienTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BienTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContratDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EstObligatoire = table.Column<bool>(nullable: false),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContratStatuts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratStatuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocataireStatuts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocataireStatuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaiementModes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaiementModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaiementMotifs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaiementMotifs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaiementStatuts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaiementStatuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periodicites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodicites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProprietaireStatuts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProprietaireStatuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true),
                    PasswwordHash = table.Column<byte[]>(nullable: true),
                    PasswwordSalt = table.Column<byte[]>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    KnownAs = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastActive = table.Column<DateTime>(nullable: false),
                    Interests = table.Column<string>(nullable: true),
                    Introduction = table.Column<string>(nullable: true),
                    LookingFor = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodiciteDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(nullable: true),
                    PeriodiciteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodiciteDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodiciteDetail_Periodicites_PeriodiciteId",
                        column: x => x.PeriodiciteId,
                        principalTable: "Periodicites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locataires",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: true),
                    StatutId = table.Column<int>(nullable: true),
                    Reference = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locataires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locataires_LocataireStatuts_StatutId",
                        column: x => x.StatutId,
                        principalTable: "LocataireStatuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locataires_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proprietaires",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: true),
                    StatutId = table.Column<int>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    AdresseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proprietaires_Adresses_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proprietaires_ProprietaireStatuts_StatutId",
                        column: x => x.StatutId,
                        principalTable: "ProprietaireStatuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proprietaires_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Biens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeId = table.Column<int>(nullable: true),
                    StatutId = table.Column<int>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateDebutExploitation = table.Column<DateTime>(nullable: false),
                    DateFinExploitation = table.Column<DateTime>(nullable: false),
                    AdresseId = table.Column<int>(nullable: true),
                    LocataireEncoursId = table.Column<int>(nullable: true),
                    LocataireId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biens_Adresses_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Biens_Locataires_LocataireEncoursId",
                        column: x => x.LocataireEncoursId,
                        principalTable: "Locataires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Biens_Locataires_LocataireId",
                        column: x => x.LocataireId,
                        principalTable: "Locataires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Biens_BienStatuts_StatutId",
                        column: x => x.StatutId,
                        principalTable: "BienStatuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Biens_BienTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "BienTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BienProprietaires",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BienId = table.Column<int>(nullable: true),
                    ProprietaireId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BienProprietaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BienProprietaires_Biens_BienId",
                        column: x => x.BienId,
                        principalTable: "Biens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BienProprietaires_Proprietaires_ProprietaireId",
                        column: x => x.ProprietaireId,
                        principalTable: "Proprietaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contrats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocataireId = table.Column<int>(nullable: true),
                    StatutId = table.Column<int>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    BienId = table.Column<int>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    DateDebut = table.Column<DateTime>(nullable: false),
                    DateFin = table.Column<DateTime>(nullable: true),
                    PeriodiciteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contrats_Biens_BienId",
                        column: x => x.BienId,
                        principalTable: "Biens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contrats_Locataires_LocataireId",
                        column: x => x.LocataireId,
                        principalTable: "Locataires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contrats_Periodicites_PeriodiciteId",
                        column: x => x.PeriodiciteId,
                        principalTable: "Periodicites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contrats_ContratStatuts_StatutId",
                        column: x => x.StatutId,
                        principalTable: "ContratStatuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContratDocumentFournis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeId = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    ContratId = table.Column<int>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratDocumentFournis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratDocumentFournis_Contrats_ContratId",
                        column: x => x.ContratId,
                        principalTable: "Contrats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratDocumentFournis_ContratDocuments_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ContratDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paiements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StatutId = table.Column<int>(nullable: true),
                    ContratId = table.Column<int>(nullable: true),
                    PeriodiciteDetailId = table.Column<int>(nullable: false),
                    DatePaiement = table.Column<DateTime>(nullable: false),
                    DatePaiementEffectif = table.Column<DateTime>(nullable: false),
                    PaiementTypeId = table.Column<int>(nullable: false),
                    PaiementMotifId = table.Column<int>(nullable: true),
                    PaiementModeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paiements_Contrats_ContratId",
                        column: x => x.ContratId,
                        principalTable: "Contrats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paiements_PaiementModes_PaiementModeId",
                        column: x => x.PaiementModeId,
                        principalTable: "PaiementModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paiements_PaiementMotifs_PaiementMotifId",
                        column: x => x.PaiementMotifId,
                        principalTable: "PaiementMotifs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paiements_PaiementStatuts_StatutId",
                        column: x => x.StatutId,
                        principalTable: "PaiementStatuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaiementMotifDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PaiementMotifId = table.Column<int>(nullable: true),
                    TemplateUrl = table.Column<string>(nullable: true),
                    PaiementId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaiementMotifDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaiementMotifDocuments_Paiements_PaiementId",
                        column: x => x.PaiementId,
                        principalTable: "Paiements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaiementMotifDocuments_PaiementMotifs_PaiementMotifId",
                        column: x => x.PaiementMotifId,
                        principalTable: "PaiementMotifs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BienProprietaires_BienId",
                table: "BienProprietaires",
                column: "BienId");

            migrationBuilder.CreateIndex(
                name: "IX_BienProprietaires_ProprietaireId",
                table: "BienProprietaires",
                column: "ProprietaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Biens_AdresseId",
                table: "Biens",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Biens_LocataireEncoursId",
                table: "Biens",
                column: "LocataireEncoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Biens_LocataireId",
                table: "Biens",
                column: "LocataireId");

            migrationBuilder.CreateIndex(
                name: "IX_Biens_StatutId",
                table: "Biens",
                column: "StatutId");

            migrationBuilder.CreateIndex(
                name: "IX_Biens_TypeId",
                table: "Biens",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratDocumentFournis_ContratId",
                table: "ContratDocumentFournis",
                column: "ContratId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratDocumentFournis_TypeId",
                table: "ContratDocumentFournis",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_BienId",
                table: "Contrats",
                column: "BienId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_LocataireId",
                table: "Contrats",
                column: "LocataireId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_PeriodiciteId",
                table: "Contrats",
                column: "PeriodiciteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_StatutId",
                table: "Contrats",
                column: "StatutId");

            migrationBuilder.CreateIndex(
                name: "IX_Locataires_StatutId",
                table: "Locataires",
                column: "StatutId");

            migrationBuilder.CreateIndex(
                name: "IX_Locataires_UserId",
                table: "Locataires",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaiementMotifDocuments_PaiementId",
                table: "PaiementMotifDocuments",
                column: "PaiementId");

            migrationBuilder.CreateIndex(
                name: "IX_PaiementMotifDocuments_PaiementMotifId",
                table: "PaiementMotifDocuments",
                column: "PaiementMotifId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_ContratId",
                table: "Paiements",
                column: "ContratId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_PaiementModeId",
                table: "Paiements",
                column: "PaiementModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_PaiementMotifId",
                table: "Paiements",
                column: "PaiementMotifId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_StatutId",
                table: "Paiements",
                column: "StatutId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodiciteDetail_PeriodiciteId",
                table: "PeriodiciteDetail",
                column: "PeriodiciteId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietaires_AdresseId",
                table: "Proprietaires",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietaires_StatutId",
                table: "Proprietaires",
                column: "StatutId");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietaires_UserId",
                table: "Proprietaires",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BienProprietaires");

            migrationBuilder.DropTable(
                name: "ContratDocumentFournis");

            migrationBuilder.DropTable(
                name: "PaiementMotifDocuments");

            migrationBuilder.DropTable(
                name: "PeriodiciteDetail");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "Proprietaires");

            migrationBuilder.DropTable(
                name: "ContratDocuments");

            migrationBuilder.DropTable(
                name: "Paiements");

            migrationBuilder.DropTable(
                name: "ProprietaireStatuts");

            migrationBuilder.DropTable(
                name: "Contrats");

            migrationBuilder.DropTable(
                name: "PaiementModes");

            migrationBuilder.DropTable(
                name: "PaiementMotifs");

            migrationBuilder.DropTable(
                name: "PaiementStatuts");

            migrationBuilder.DropTable(
                name: "Biens");

            migrationBuilder.DropTable(
                name: "Periodicites");

            migrationBuilder.DropTable(
                name: "ContratStatuts");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Locataires");

            migrationBuilder.DropTable(
                name: "BienStatuts");

            migrationBuilder.DropTable(
                name: "BienTypes");

            migrationBuilder.DropTable(
                name: "LocataireStatuts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
