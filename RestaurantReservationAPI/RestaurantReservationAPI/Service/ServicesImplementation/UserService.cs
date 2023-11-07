using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Repositories.GenericRepository;
using RestaurantReservation.Db.Repositories.IRepostories;
using RestaurantReservationAPI.Service.IServices;
using System.Linq.Expressions;

namespace RestaurantReservationAPI.Service.ServicesImplementation
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository repository) : base(repository)
        {
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
