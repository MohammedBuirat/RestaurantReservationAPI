using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Repositories.IRepostories;
using RestaurantReservation.Service.IServices;

namespace RestaurantReservation.Service.ServicesImplementation
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ILogger _logger;

        public ReservationService(IReservationRepository reservationRepository, ILogger<ReservationService> logger)
        {
            _reservationRepository = reservationRepository;
            _logger = logger;
        }

        public async Task<bool> AddAsync(Reservation entity)
        {
            try
            {
                await _reservationRepository.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Adding Reservation");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _reservationRepository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While deleting Reservation with id: {Id}", id);
                return false;
            }
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            try
            {
                return await _reservationRepository.ExistsAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Checking if there is a Reservation with id: {Id}", id);
                return false;
            }
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            try
            {
                IEnumerable<Reservation> reservations = await _reservationRepository.GetAllAsync();
                return reservations;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While getting all Reservations");
                return Enumerable.Empty<Reservation>();
            }
        }

        public async Task<Reservation?> GetByIdAsync(int id)
        {
            try
            {
                return await _reservationRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While getting Reservation with id: {Id}", id);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(Reservation entity)
        {
            try
            {
                await _reservationRepository.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Updating Reservation");
                return false;
            }
        }
    }
}
