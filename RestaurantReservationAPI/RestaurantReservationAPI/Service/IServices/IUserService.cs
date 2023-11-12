using RestaurantReservation.Db.Entities;
using RestaurantReservation.Service.IServices;

namespace RestaurantReservationAPI.Service.IServices
{
    public interface IUserService : IService<User>
    {
        public Task<bool> UserNameIsTaken(string name);
        public Task<User> UserByNameAndPassword(string name, string password);
    }
}
