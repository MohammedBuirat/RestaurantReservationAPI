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
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ILogger _logger;

        public RestaurantService(IRestaurantRepository restaurantRepository, ILogger<RestaurantService> logger)
        {
            _restaurantRepository = restaurantRepository;
            _logger = logger;
        }

        public async Task<bool> AddAsync(Restaurant entity)
        {
            try
            {
                await _restaurantRepository.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Adding Restaurant");
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _restaurantRepository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While deleting Restaurant with id: {Id}", id);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _restaurantRepository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While deleting Restaurant with id: {Id}", id);
                return false;
            }
        }

        public async Task<bool> ExistById(int id)
        {
            try
            {
                return await _restaurantRepository.ExistsAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Checking if there is a Restaurant with id: {Id}", id);
                return false;
            }
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            try
            {
                return await _restaurantRepository.ExistsAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Checking if there is a Restaurant with id: {Id}", id);
                return false;
            }
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            try
            {
                List<Restaurant> restaurants = await _restaurantRepository.GetAllAsync();
                return restaurants;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While getting all Restaurants");
                return Enumerable.Empty<Restaurant>();
            }
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            try
            {
                IEnumerable<Restaurant> restaurants = await _restaurantRepository.GetAllAsync();
                return restaurants;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While getting all Restaurants");
                return Enumerable.Empty<Restaurant>();
            }
        }

        public async Task<Restaurant> GetById(int id)
        {
            try
            {
                return await _restaurantRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While getting Restaurant with id: {Id}", id);
                return null;
            }
        }

        public async Task<Restaurant> GetByIdAsync(int id)
        {
            try
            {
                return await _restaurantRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While getting Restaurant with id: {Id}", id);
                return null;
            }
        }

        public async Task<bool> Update(Restaurant entity)
        {
            try
            {
                await _restaurantRepository.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Updating Restaurant");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Restaurant entity)
        {
            try
            {
                await _restaurantRepository.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Updating Restaurant");
                return false;
            }
        }
    }
}
