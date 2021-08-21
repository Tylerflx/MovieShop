using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IUserRespository: IAsyncRepository<User>
    {
        Task<User> GetUserByEmail(string email);    //user recall
        Task<User> GetUserFavoritesById(int id);
        Task<User> GetUserPurchasesById(int id);
    }
}
