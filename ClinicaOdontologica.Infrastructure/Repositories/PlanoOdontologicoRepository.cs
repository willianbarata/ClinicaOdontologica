using ClinicaOdontologica.Domain.Entities;
using ClinicaOdontologica.Infrastructure.Context;
using ClinicaOdontologica.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Infrastructure.Repositories
{
    public class PlanoOdontologicoRepository : Repository<PlanoOdontologico>, IPlanoOdontologicoRepository
    {
        public PlanoOdontologicoRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
