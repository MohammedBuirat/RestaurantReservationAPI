using RestaurantReservation.Db.Entities;
using System.Linq.Expressions;

namespace RestaurantReservation.Service.IServices
{
    public interface IService<T> where T : class
    {
        public Task<T?> GetByIdAsync(int id);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(T entity);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<bool> ExistByIdAsync(int id);
        public Task<bool> AddAsync(T entity);
        public Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);

    }
}
