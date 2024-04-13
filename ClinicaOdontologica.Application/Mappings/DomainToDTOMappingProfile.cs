using AutoMapper;
using ClinicaOdontologica.Application.DTOs;
using ClinicaOdontologica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Especialidade, EspecialidadeDTO>().ReverseMap();
            CreateMap<PlanoOdontologico, PlanoOdontologicoDTO>().ReverseMap();    
        }
    }
}
