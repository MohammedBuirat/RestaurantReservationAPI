using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Repositories.IRepostories;
using RestaurantReservation.Service.IServices;

namespace RestaurantReservation.Service.ServicesImplementation
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly ILogger _logger;

        public MenuItemService(IMenuItemRepository menuItemRepository, ILogger logger)
        {
            _menuItemRepository = menuItemRepository;
            _logger = logger;
        }

        public async Task<bool> AddAsync(MenuItem entity)
        {
            try
            {
                await _menuItemRepository.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error While Adding MenuItem");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _menuItemRepository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error While deleting MenuItem");
                return false;
            }
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            try
            {
                return await _menuItemRepository.ExistsAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error While Checking if there is a MenuItem with id " + id);
                return false;
            }
        }

        public async Task<IEnumerable<MenuItem>> GetAllAsync()
        {
            try
            {
                IEnumerable<MenuItem> menuItems = await _menuItemRepository.GetAllAsync();
                return menuItems;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error While getting all MenuItems");
                return Enumerable.Empty<MenuItem>();
            }
        }

        public async Task<MenuItem?> GetByIdAsync(int id)
        {
            try
            {
                return await _menuItemRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error While getting MenuItem with id :" + id);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(MenuItem entity)
        {
            try
            {
                await _menuItemRepository.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error While Updating MenuItem");
                return false;
            }
        }
    }
}
