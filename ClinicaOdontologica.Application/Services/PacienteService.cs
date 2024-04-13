using AutoMapper;
using ClinicaOdontologica.Application.DTOs;
using ClinicaOdontologica.Application.Interfaces;
using ClinicaOdontologica.Application.ValidationErrors;
using ClinicaOdontologica.Domain.Entities;
using ClinicaOdontologica.Infrastructure.Repositories;
using ClinicaOdontologica.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Application.Services
{
    public class PacienteService : IPacienteService
    {
        public IPacienteRepository _pacienteRepository;
        public IPlanoOdontologicoRepository _planoOdontoRepository;
        private readonly IMapper _mapper;

        public PacienteService(IPacienteRepository pacienteRepository, IMapper mapper, IPlanoOdontologicoRepository planoOdontoRepository)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
            _planoOdontoRepository = planoOdontoRepository;
        }
        public async Task<IEnumerable<PacienteDTO>> GetPacientes()
        {
            var pacientes = await _pacienteRepository.GetAllAsync();
            var listaPacienteDTOs = _mapper.Map<IEnumerable<PacienteDTO>>(pacientes);
            return listaPacienteDTOs;
        }
        public async Task<PacienteDTO> GetById(int? id)
        {
            var pacienteEntity = await _pacienteRepository.GetAsync(x => x.Id == id);
            var pacienteDTO = _mapper.Map<PacienteDTO>(pacienteEntity);
            return pacienteDTO;
        }
        public async Task<PacienteDTO> Add(PacienteDTO pacienteDTO)
        {
            #region Validar Plano de Saúde
            var planoOdonto = _planoOdontoRepository.Get(x => x.Id == pacienteDTO.PlanoOdontologicoId);

            if (planoOdonto == null)
            {
                throw new PlanoOdontologicoNotFoundException();
            }
            #endregion

            #region Validar CPF
            if (!ValidarCpf(pacienteDTO.Cpf))
            {
                throw new CpfInvalidoException();
            }
            #endregion

            if(pacienteDTO.DataNascimento > DateTime.Now)
            {
                throw new DataNascimentoInvalidaException();
            }

            var pacienteEntity = _mapper.Map<Paciente>(pacienteDTO);
            var pacienteCriado = await _pacienteRepository.CreateAsync(pacienteEntity);
            var pacienteCriadoDTO = _mapper.Map<PacienteDTO>(pacienteCriado);
            return pacienteCriadoDTO;
        }
        public async Task Update(PacienteDTO pacienteDTO)
        {
            var pacienteEntity = _mapper.Map<Paciente>(pacienteDTO);
            await _pacienteRepository.UpdateAsync(pacienteEntity);
        }
        public async Task Remove(int? id)
        {
            var pacienteEntity = await _pacienteRepository.GetAsync(x => x.Id == id);
            await _pacienteRepository.DeleteAsync(pacienteEntity);
        }
        private bool ValidarCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                return false;
            }

            if (!ValidarSomenteNumeros(cpf))
            {
                return false;
            }
            return true;
        }

        private bool ValidarSomenteNumeros(string texto)
        {
            const string regex = @"^\d+$"; // Expressão regular para dígitos numéricos
            return Regex.IsMatch(texto, regex);
        }
    }
}
