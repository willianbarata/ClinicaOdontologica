using ClinicaOdontologica.Application.DTOs;
using ClinicaOdontologica.Application.Interfaces;
using ClinicaOdontologica.Application.Services;
using ClinicaOdontologica.Application.ValidationErrors;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaOdontologica.API.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class PlanoOdontologicoController : ControllerBase
    {
        public readonly IPlanoOdontologicoService _planoOdontoService;

        public PlanoOdontologicoController(IPlanoOdontologicoService planoOdontoService)
        {
            _planoOdontoService = planoOdontoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanoOdontologicoDTO>>> Get()
        {
            try
            {
                var planoOdonto = await _planoOdontoService.GetPlanosOdontologicos();
                return Ok(planoOdonto);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet("{id}", Name = "GetPlanoOdontologico")]
        public async Task<ActionResult<PlanoOdontologicoDTO>> Get(int id)
        {
            var planoOdontologico = await _planoOdontoService.GetById(id);

            if (planoOdontologico == null)
            {
                return NotFound();
            }
            return Ok(planoOdontologico);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PlanoOdontologicoDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PlanoOdontologicoDTO>> Post([FromBody] PlanoOdontologicoDTO planoOdontologicoDTO)
        {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var planoOdontologicoCriadoDTO = await _planoOdontoService.Add(planoOdontologicoDTO);

                return new CreatedAtRouteResult("GetPlanoOdontologico",
                    new { id = planoOdontologicoCriadoDTO.Id }, planoOdontologicoCriadoDTO);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PlanoOdontologicoDTO planoOdontologicoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != planoOdontologicoDTO.Id)
            {
                return BadRequest();
            }
            await _planoOdontoService.Update(planoOdontologicoDTO);
            return Ok(planoOdontologicoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PlanoOdontologicoDTO>> Delete(int id)
        {
            var planoOdontologico = await _planoOdontoService.GetById(id);
            if (planoOdontologico == null)
            {
                return NotFound();
            }
            await _planoOdontoService.Remove(id);
            return Ok(planoOdontologico);
        }
    }
}
