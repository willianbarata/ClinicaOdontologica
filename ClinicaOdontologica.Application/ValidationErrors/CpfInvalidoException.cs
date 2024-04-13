using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Application.ValidationErrors
{
    public class CpfInvalidoException : Exception
    {
        public CpfInvalidoException() : base("CPF inválido e deve conter apenas números.")
        {
        }
    }
}
