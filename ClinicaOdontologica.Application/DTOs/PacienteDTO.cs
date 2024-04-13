using ClinicaOdontologica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Application.DTOs
{
    public class PacienteDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome do paciente")]
        [MinLength(3, ErrorMessage = "A descrição deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o CPF do paciente")] // Mensagem de erro personalizada
        [MinLength(11, ErrorMessage = "O CPF deve ter 11 dígitos")] // Validação de tamanho mínimo
        [MaxLength(11, ErrorMessage = "O CPF deve ter 11 dígitos")] // Validação de tamanho máximo
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Informe a data de nascimento do paciente")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe um endereço")]
        [MinLength(3, ErrorMessage = "O endereço deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O endereço deve ter no máximo 100 caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe o número do telefone")]
        public string Telefone { get; set; }
        public int PlanoOdontologicoId { get; set; }
    }
}
