using ClinicaOdontologica.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Application.Interfaces
{
    public interface IEspecialidadeService
    {
        Task<IEnumerable<EspecialidadeDTO>> GetEspecialidades();
        Task<EspecialidadeDTO> GetById(int? id);
        Task<EspecialidadeDTO> Add(EspecialidadeDTO especialidadeDTO);
        Task Update(EspecialidadeDTO especialidadeDTO);
        Task Remove(int? id);
    }
}
