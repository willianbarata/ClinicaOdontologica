using ClinicaOdontologica.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Application.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDTO>> GetPacientes();
        Task<PacienteDTO> GetById(int? id);
        Task<PacienteDTO> Add(PacienteDTO pacienteDTO);
        Task Update(PacienteDTO pacienteDTO);
        Task Remove(int? id);
    }
}
