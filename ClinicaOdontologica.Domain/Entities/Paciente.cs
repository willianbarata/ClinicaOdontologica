using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Domain.Entities
{
    public sealed class Paciente : Pessoa
    {
        public Paciente(string nome, string cpf, DateTime dataNascimento, string endereco, string telefone, int planoOdontologicoId) : base(nome, cpf, dataNascimento, endereco, telefone)
        {
            PlanoOdontologicoId = planoOdontologicoId;
        }

        public PlanoOdontologico PlanoOdontologico { get; set; }
        public int PlanoOdontologicoId { get; set; }

    }
}
