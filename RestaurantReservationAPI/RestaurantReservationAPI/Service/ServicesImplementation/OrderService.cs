using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Repositories.IRepostories;
using RestaurantReservation.Service.IServices;
using RestaurantReservationAPI.Service.ServicesImplementation;

namespace RestaurantReservation.Service.ServicesImplementation
{
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository) : base(repository)
        {
        }
    }
}
