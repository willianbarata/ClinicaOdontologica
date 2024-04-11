using ClinicaOdontologica.Application.DTOs;
using ClinicaOdontologica.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaOdontologica.API.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly IEspecialidadeService _especialidadesService;

        public EspecialidadesController(IEspecialidadeService especialidadesService)
        {
            _especialidadesService = especialidadesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecialidadeDTO>>> Get()
        {
            try
            {
                var especialidades = await _especialidadesService.GetEspecialidades();
                return Ok(especialidades);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet("{id}", Name = "GetEspecialidade")]
        public async Task<ActionResult<EspecialidadeDTO>> Get(int id)
        {
            var especialidade = await _especialidadesService.GetById(id);

            if (especialidade == null)
            {
                return NotFound();
            }
            return Ok(especialidade);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EspecialidadeDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EspecialidadeDTO>> Post([FromBody] EspecialidadeDTO especialidadeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var especialidadeCriadaDTO = await _especialidadesService.Add(especialidadeDto);

            return new CreatedAtRouteResult("GetEspecialidade",
                new { id = especialidadeCriadaDTO.ID }, especialidadeCriadaDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EspecialidadeDTO especialidadeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != especialidadeDTO.ID)
            {
                return BadRequest();
            }
            await _especialidadesService.Update(especialidadeDTO);
            return Ok(especialidadeDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EspecialidadeDTO>> Delete(int id)
        {
            var especicalidade = await _especialidadesService.GetById(id);
            if (especicalidade == null)
            {
                return NotFound();
            }
            await _especialidadesService.Remove(id);
            return Ok(especicalidade);
        }

    }
}
