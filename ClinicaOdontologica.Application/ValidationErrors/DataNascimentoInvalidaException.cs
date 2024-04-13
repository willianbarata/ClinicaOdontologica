using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Application.ValidationErrors
{
    public class DataNascimentoInvalidaException : Exception
    {
        public DataNascimentoInvalidaException() : base("A data de nascimento é inválida")
        {
        }
    }
}
