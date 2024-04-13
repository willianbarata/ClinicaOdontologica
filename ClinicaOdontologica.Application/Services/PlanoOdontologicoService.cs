using AutoMapper;
using ClinicaOdontologica.Application.DTOs;
using ClinicaOdontologica.Application.Interfaces;
using ClinicaOdontologica.Domain.Entities;
using ClinicaOdontologica.Infrastructure.Repositories;
using ClinicaOdontologica.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Application.Services
{
    public class PlanoOdontologicoService : IPlanoOdontologicoService
    {
        public IPlanoOdontologicoRepository _planoRepository;
        private readonly IMapper _mapper;

        public PlanoOdontologicoService(IPlanoOdontologicoRepository planoRepository, IMapper mapper)
        {
            _planoRepository = planoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlanoOdontologicoDTO>> GetPlanosOdontologicos()
        {
            var listaPlanosOdontologicos = await _planoRepository.GetAllAsync();
            var listaPlanosOdontoDTO = _mapper.Map<IEnumerable<PlanoOdontologicoDTO>>(listaPlanosOdontologicos);
            return listaPlanosOdontoDTO;
        }

        public async Task<PlanoOdontologicoDTO> Add(PlanoOdontologicoDTO planoOdontologicoDTO)
        {
            var planoOdontoEntity = _mapper.Map<PlanoOdontologico>(planoOdontologicoDTO);
            var planoOdontologicoCriado = await _planoRepository.CreateAsync(planoOdontoEntity);
            var planoOdontologicoCriadoDTO = _mapper.Map<PlanoOdontologicoDTO>(planoOdontologicoCriado);
            return planoOdontologicoCriadoDTO;
        }

        public async Task<PlanoOdontologicoDTO> GetById(int? id)
        {
            var planoOdontoEntity = await _planoRepository.GetAsync(x => x.Id == id);
            var planoOdontoDTO = _mapper.Map<PlanoOdontologicoDTO>(planoOdontoEntity);
            return planoOdontoDTO;
        }



        public async Task Update(PlanoOdontologicoDTO planoOdontologicoDTO)
        {
            var planoOdontoEntity = _mapper.Map<PlanoOdontologico>(planoOdontologicoDTO);
            await _planoRepository.UpdateAsync(planoOdontoEntity);
        }

        public async Task Remove(int? id)
        {
            var planoOdontoEntity = await _planoRepository.GetAsync(x => x.Id == id);
            await _planoRepository.DeleteAsync(planoOdontoEntity);
        }
    }
}
