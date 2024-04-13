using ClinicaOdontologica.Domain.Entities;
using ClinicaOdontologica.Infrastructure.Context;
using ClinicaOdontologica.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Infrastructure.Repositories
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
