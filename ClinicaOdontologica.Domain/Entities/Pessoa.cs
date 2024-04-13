using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Domain.Entities
{
    [Table("Pessoas")]
    public abstract class Pessoa : Entity
    {
        public string Nome { get; protected set; }
        public string Cpf { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public string Endereco { get; protected set; }
        public string Telefone { get; protected set; }

        public Pessoa(string nome, string cpf, DateTime dataNascimento, string endereco, string telefone)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            Telefone = telefone;
        }
    }
}
