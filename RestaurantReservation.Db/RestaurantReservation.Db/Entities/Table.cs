﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public int ResturantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int Capacity { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
