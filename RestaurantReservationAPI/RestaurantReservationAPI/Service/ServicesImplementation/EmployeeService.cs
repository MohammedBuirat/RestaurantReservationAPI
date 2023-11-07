using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.IRepostories;

namespace RestaurantReservation.Service.ServicesImplementation
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger _logger;

        public EmployeeService(IEmployeeRepository employeeRepository, ILogger<OrderService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public async Task<bool> AddAsync(Employee entity)
        {
            try
            {
                await _employeeRepository.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Adding Employee");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _employeeRepository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While deleting Employee with id: {Id}", id);
                return false;
            }
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            try
            {
                return await _employeeRepository.ExistsAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Checking if there is an Employee with id: {Id}", id);
                return false;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            try
            {
                IEnumerable<Employee> employees = await _employeeRepository.GetAllAsync();
                return employees;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While getting all Employees");
                return Enumerable.Empty<Employee>();
            }
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            try
            {
                return await _employeeRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While getting Employee with id: {Id}", id);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(Employee entity)
        {
            try
            {
                await _employeeRepository.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Updating Employee");
                return false;
            }
        }
    }
}
