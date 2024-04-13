using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Application.DTOs
{
    public class PlanoOdontologicoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome da plano de saúde")]
        [MinLength(2, ErrorMessage = "A descrição deve ter no mínimo 2 caracteres")]
        [MaxLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
    }
}
