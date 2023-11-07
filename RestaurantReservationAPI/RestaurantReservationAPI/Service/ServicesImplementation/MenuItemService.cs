using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Repositories.IRepostories;
using RestaurantReservation.Service.IServices;
using RestaurantReservationAPI.Service.ServicesImplementation;

namespace RestaurantReservation.Service.ServicesImplementation
{
    public class MenuItemService : Service<MenuItem>, IMenuItemService
    {
        private readonly IMenuItemRepository _repository;

        public MenuItemService(IMenuItemRepository repository) : base(repository)
        {
        }
    }
}
}
