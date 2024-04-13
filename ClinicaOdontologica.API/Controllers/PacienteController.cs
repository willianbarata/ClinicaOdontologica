using ClinicaOdontologica.Application.DTOs;
using ClinicaOdontologica.Application.Interfaces;
using ClinicaOdontologica.Application.Services;
using ClinicaOdontologica.Application.ValidationErrors;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaOdontologica.API.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        public readonly IPacienteService _pacienteService;
        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacienteDTO>>> Get()
        {
            try
            {
                var listaPacientes = await _pacienteService.GetPacientes();
                return Ok(listaPacientes);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet("{id}", Name = "GetPaciente")]
        public async Task<ActionResult<PacienteDTO>> Get(int id)
        {
            var pacienteDTO = await _pacienteService.GetById(id);

            if (pacienteDTO == null)
            {
                return NotFound();
            }
            return Ok(pacienteDTO);
        }


        [HttpPost]
        [ProducesResponseType(typeof(PacienteDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PacienteDTO>> Post([FromBody] PacienteDTO pacienteDto)
        {
            try{
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var pacienteDTO = await _pacienteService.Add(pacienteDto);

                return new CreatedAtRouteResult("GetPaciente",
                    new { id = pacienteDTO.Id }, pacienteDTO);
            }
            catch (PlanoOdontologicoNotFoundException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (CpfInvalidoException cpf)
            {
                return BadRequest(new { error = cpf.Message });
            }
            catch (DataNascimentoInvalidaException date)
            {
                return BadRequest(new { error = date.Message });
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PacienteDTO pacienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != pacienteDTO.Id)
            {
                return BadRequest();
            }
            await _pacienteService.Update(pacienteDTO);
            return Ok(pacienteDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EspecialidadeDTO>> Delete(int id)
        {
            var paciente = await _pacienteService.GetById(id);
            if (paciente == null)
            {
                return NotFound();
            }
            await _pacienteService.Remove(id);
            return Ok(paciente);
        }
    }
}
