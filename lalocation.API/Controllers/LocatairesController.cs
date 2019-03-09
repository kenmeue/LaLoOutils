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
    [Route("Api/[controller]")]
    [ApiController]
    public class LocatairesController: ControllerBase
    {
        private readonly ILalocationRepository _repo;
        private readonly IMapper _mapper;

        public LocatairesController(ILalocationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

         [HttpGet]
        public async Task<IActionResult> GetLocataires() {
            var locatairesFromRepo = await _repo.GetLocataires();
            var locatairestoReturn = _mapper.Map<IEnumerable<LocataireForListDto>>(locatairesFromRepo);
            return Ok(locatairestoReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocataire(int id) {
            var locataireFromRepo = await _repo.GetLocataire(id);
            var locatairetoReturn = _mapper.Map<LocataireForDetailedDto>(locataireFromRepo);
            return Ok(locatairetoReturn);
        }
    }
}