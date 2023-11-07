using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.GenericRepository;
using RestaurantReservation.Service.IServices;
using System.Linq.Expressions;

namespace RestaurantReservationAPI.Service.ServicesImplementation
{
    public class Service<T> : IService<T> where T : class
    {
        IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _repository.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            try
            {
                return await _repository.ExistsAsync(id);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                IEnumerable<T> entities = await _repository.GetAllAsync();
                return entities;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<T>();
            }
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                T entity = await _repository.GetFirstOrDefaultAsync(filter);
                return entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                await _repository.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
