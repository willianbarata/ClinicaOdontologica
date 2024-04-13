using ClinicaOdontologica.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Application.Interfaces
{
    public interface IPlanoOdontologicoService
    {
        Task<IEnumerable<PlanoOdontologicoDTO>> GetPlanosOdontologicos();
        Task<PlanoOdontologicoDTO> GetById(int? id);
        Task<PlanoOdontologicoDTO> Add(PlanoOdontologicoDTO planoOdontologicoDTO);
        Task Update(PlanoOdontologicoDTO planoOdontologicoDTO);
        Task Remove(int? id);
    }
}
