using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.IRepostories;
using RestaurantReservationAPI.Service.IServices;

namespace RestaurantReservationAPI.Service.ServicesImplementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> AddAsync(User entity)
        {
            try
            {
                await _userRepository.AddAsync(entity);
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
                await _userRepository.DeleteAsync(id);
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
                return await _userRepository.ExistsAsync(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                IEnumerable<User> users = await _userRepository.GetAllAsync();
                return users;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<User>();
            }
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            try
            {
                return await _userRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            try
            {
                await _userRepository.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<User> UserByNameAndPassword(string name, string password)
        {
            User user = await _userRepository.UserByNameAndPassword(name, password);
            return user;
        }

        public async Task<bool> UserNameIsTaken(string name)
        {
            bool nameIsTaken = await _userRepository.UserNameIsTaken(name);
            return nameIsTaken;
        }
    }
}
