using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Domain.Entities
{
    public sealed class Paciente : Pessoa
    {
        public PlanoOdontologico PlanoOdontologico { get; set; }

        public Paciente(string nome, string cpf, DateTime dataNascimento, string endereco, string telefone, PlanoOdontologico planoOdontologico) : base(nome, cpf, dataNascimento, endereco, telefone)
        {
            PlanoOdontologico = planoOdontologico;
        }
    }
}
