using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Application.DTOs
{
    public class EspecialidadeDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Informe o nome da especialidade")]
        [MinLength(3, ErrorMessage = "A descrição deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres")]
        public string Descricao { get; set; }
    }
}
