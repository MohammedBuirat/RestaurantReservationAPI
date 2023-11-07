﻿using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories.IRepostories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public Task<decimal?> CalculateAverageOrderAmount(int EmployeeId);
    }
}
