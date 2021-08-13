using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    //T can be replaced by class type: generic constraints => T:Class
    // T: struct can replaced by value type
    public interface IAsyncRepository<T> where T: class
    {
        //Can create as many as entities class
        //this is base interface
        //we will have common CRUD operations
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteASync(T entity);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter);
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null);
        Task<bool> GetExistsAsync(Expression<Func<T, bool>> filter = null);
    }
}
