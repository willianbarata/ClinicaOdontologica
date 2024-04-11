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
    public class EspecialidadeRepository : Repository<Especialidade>, IEspecialidadeRepository
    {
        public EspecialidadeRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
