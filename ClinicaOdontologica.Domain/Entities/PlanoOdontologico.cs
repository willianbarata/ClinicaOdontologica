using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Domain.Entities
{
    public sealed class PlanoOdontologico : Entity
    {
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }
    }
}
