using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Application.ValidationErrors
{
    public class PlanoOdontologicoNotFoundException : Exception
    {
        public PlanoOdontologicoNotFoundException() : base("Plano odontológico não encontrado")
        {
        }
    }
}
