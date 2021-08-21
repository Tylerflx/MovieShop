using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRespository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);   //get one record
            return user;
        }

        public async Task<User> GetUserFavoritesById(int id)
        {
            var user = await _dbContext.Users.Include(f => f.Favorites).ThenInclude(f => f.Movie).FirstOrDefaultAsync(f => f.Id == id);
            return user;
        }

        public async Task<User> GetUserPurchasesById(int id)
        {
            var user = await _dbContext.Users.Include(p => p.Purchases).ThenInclude(p => p.Movie).FirstOrDefaultAsync(p => p.Id == id);
            return user;
        }
    }
}
