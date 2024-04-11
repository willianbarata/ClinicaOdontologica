using AutoMapper;
using ClinicaOdontologica.Application.DTOs;
using ClinicaOdontologica.Application.Interfaces;
using ClinicaOdontologica.Domain.Entities;
using ClinicaOdontologica.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Application.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private IEspecialidadeRepository _especialidadeRepository;
        private readonly IMapper _mapper;

        public EspecialidadeService(IEspecialidadeRepository especialidadeRepository, IMapper mapper)
        {
            _especialidadeRepository = especialidadeRepository;
            _mapper = mapper;
        }

        public async Task<EspecialidadeDTO> Add(EspecialidadeDTO especialidadeDTO)
        {
            var especialidadeEntity = _mapper.Map<Especialidade>(especialidadeDTO);
            var especialidadeCriada = await _especialidadeRepository.CreateAsync(especialidadeEntity);
            var especialidadeCriadaDTO = _mapper.Map<EspecialidadeDTO>(especialidadeCriada);
            return especialidadeCriadaDTO;
        }

        public async Task<EspecialidadeDTO> GetById(int? id)
        {
            var especialidadeEntity = await _especialidadeRepository.GetAsync(x => x.Id == id);
            var especialidadeDTO = _mapper.Map<EspecialidadeDTO>(especialidadeEntity);
            return especialidadeDTO;
        }

        public async Task<IEnumerable<EspecialidadeDTO>> GetEspecialidades()
        {
            var especialidades = await _especialidadeRepository.GetAllAsync();
            var especialidadesDTO = _mapper.Map<IEnumerable<EspecialidadeDTO>>(especialidades);
            return especialidadesDTO;
        }
        public async Task Update(EspecialidadeDTO especialidadeDTO)
        {
            var especialidadeEntity = _mapper.Map<Especialidade>(especialidadeDTO);
            await _especialidadeRepository.UpdateAsync(especialidadeEntity);
            
        }
        public async Task Remove(int? id)
        {
            var especialidadeEntity = await _especialidadeRepository.GetAsync(x => x.Id == id);
            await _especialidadeRepository.DeleteAsync(especialidadeEntity);
        }

    }
}
