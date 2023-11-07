using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.GenericRepository;
using RestaurantReservation.Db.Repositories.IRepostories;
using RestaurantReservation.Service.IServices;
using RestaurantReservationAPI.Service.ServicesImplementation;
using System.Linq.Expressions;

namespace RestaurantReservation.Service.ServicesImplementation
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _repositroy;
        public CustomerService(IRepository<Customer> repository) : base(repository)
        {
        }
    }
}
