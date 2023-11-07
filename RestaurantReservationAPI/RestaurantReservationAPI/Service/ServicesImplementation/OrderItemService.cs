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
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ILogger _logger;

        public OrderItemService(IOrderItemRepository orderItemRepository, ILogger<OrderItemService> logger)
        {
            _orderItemRepository = orderItemRepository;
            _logger = logger;
        }

        public async Task<bool> AddAsync(OrderItem entity)
        {
            try
            {
                await _orderItemRepository.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Adding OrderItem");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _orderItemRepository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While deleting OrderItem with id: {Id}", id);
                return false;
            }
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            try
            {
                return await _orderItemRepository.ExistsAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Checking if there is an OrderItem with id: {Id}", id);
                return false;
            }
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            try
            {
                IEnumerable<OrderItem> orderItems = await _orderItemRepository.GetAllAsync();
                return orderItems;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While getting all OrderItems");
                return Enumerable.Empty<OrderItem>();
            }
        }

        public async Task<OrderItem?> GetByIdAsync(int id)
        {
            try
            {
                return await _orderItemRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While getting OrderItem with id: {Id}", id);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(OrderItem entity)
        {
            try
            {
                await _orderItemRepository.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Updating OrderItem");
                return false;
            }
        }
    }
}
