using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Repositories.IRepostories;
using RestaurantReservation.Service.IServices;
using RestaurantReservationAPI.Service.ServicesImplementation;
using System.Linq.Expressions;

namespace RestaurantReservation.Service.ServicesImplementation
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {

        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository) : base(repository)
        {
        }
    }
}