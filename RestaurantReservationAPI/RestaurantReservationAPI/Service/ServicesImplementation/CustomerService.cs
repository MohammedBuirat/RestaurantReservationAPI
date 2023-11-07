using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.IRepostories;
using RestaurantReservation.Service.IServices;

namespace RestaurantReservation.Service.ServicesImplementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> AddAsync(Customer entity)
        {
            try
            {
                await _customerRepository.AddAsync(entity);
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
                await _customerRepository.DeleteAsync(id);
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
                return await _customerRepository.ExistsAsync(id);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            try
            {
                IEnumerable<Customer> customers = await _customerRepository.GetAllAsync();
                return customers;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Customer>();
            }
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            try
            {
                return await _customerRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(Customer entity)
        {
            try
            {
                await _customerRepository.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
