using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Domain.Entities
{
    public sealed class Dentista : Pessoa
    {
        public string CRO { get; set; }
        public Especialidade Especialidade { get; set; }

        public Dentista(string nome, string cpf, DateTime dataNascimento, string endereco, string telefone, string cro, Especialidade especialidade) : base(nome, cpf, dataNascimento, endereco, telefone)
        {
            CRO = cro;
            Especialidade = especialidade;
        }
    }
}
