using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Repositories.IRepostories;
using RestaurantReservation.Service.IServices;
using RestaurantReservationAPI.Service.ServicesImplementation;

namespace RestaurantReservation.Service.ServicesImplementation
{
    public class ReservationService : Service<Reservation>, IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository repository) : base(repository)
        {
        }

    }
}
