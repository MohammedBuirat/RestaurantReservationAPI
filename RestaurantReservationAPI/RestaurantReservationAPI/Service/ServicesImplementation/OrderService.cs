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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger _logger;

        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<bool> AddAsync(Order entity)
        {
            try
            {
                await _orderRepository.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Adding Order");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _orderRepository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While deleting Order with id: {Id}", id);
                return false;
            }
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            try
            {
                return await _orderRepository.ExistsAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Checking if there is an Order with id: {Id}", id);
                return false;
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllAsync();
                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While getting all Orders");
                return Enumerable.Empty<Order>();
            }
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            try
            {
                return await _orderRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While getting Order with id: {Id}", id);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(Order entity)
        {
            try
            {
                await _orderRepository.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Updating Order");
                return false;
            }
        }
    }
}
