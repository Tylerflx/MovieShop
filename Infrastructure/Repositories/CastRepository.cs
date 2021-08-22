using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CastRepository : EfRepository<Cast>, ICastRepository
    {
        //this class repository used to connect dbcontext with db
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
            //inherit from base class
        }

        public override async Task<IEnumerable<Cast>> ListAllAsync()
        {
            var cast = await _dbContext.Casts.Take(1000).ToListAsync();
            if (cast == null)
            {
                throw new Exception($"No cast found");
            }
            return cast;
        }

        public override async Task<Cast> GetByIdAsync(int id)
        {
            //this will use sql query to get records from db
            //using Entity Framework
            var cast = await _dbContext.Casts.Include(c => c.MovieCasts).ThenInclude(c => c.Movie).FirstOrDefaultAsync(c => c.Id == id);
            if (cast == null)
            {
                throw new Exception($"No cast found for this cast id: {id}");
            }
            return cast;
        }
    }
}
