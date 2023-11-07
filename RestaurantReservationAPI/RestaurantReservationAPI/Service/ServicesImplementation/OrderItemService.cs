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
    public class OrderItemService : Service<OrderItem>, IOrderItemService
    {

        private readonly IOrderItemRepository _repository;

        public OrderItemService(IOrderItemRepository repository) : base(repository)
        {
        }
    }
}
