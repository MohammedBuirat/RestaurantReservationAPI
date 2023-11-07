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
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly ILogger _logger;

        public TableService(ITableRepository tableRepository, ILogger<TableService> logger)
        {
            _tableRepository = tableRepository;
            _logger = logger;
        }

        public async Task<bool> AddAsync(Table entity)
        {
            try
            {
                await _tableRepository.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Adding Table");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _tableRepository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While deleting Table with id: {Id}", id);
                return false;
            }
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            try
            {
                return await _tableRepository.ExistsAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Checking if there is a Table with id: {Id}", id);
                return false;
            }
        }

        public async Task<IEnumerable<Table>> GetAllAsync()
        {
            try
            {
                IEnumerable<Table> tables = await _tableRepository.GetAllAsync();
                return tables;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While getting all Tables");
                return Enumerable.Empty<Table>();
            }
        }

        public async Task<Table?> GetByIdAsync(int id)
        {
            try
            {
                return await _tableRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While getting Table with id: {Id}", id);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(Table entity)
        {
            try
            {
                await _tableRepository.UpdateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Updating Table");
                return false;
            }
        }
    }
}
