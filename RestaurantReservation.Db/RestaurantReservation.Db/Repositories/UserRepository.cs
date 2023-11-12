using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.GenericRepository;
using RestaurantReservation.Db.Repositories.IRepostories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        public UserRepository(RestaurantReservationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> UserByNameAndPassword(string name, string password)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => (u.Username == name) && (u.Password == password) );
        }

        public async Task<bool> UserNameIsTaken(string name)
        {
            return await _dbContext.Users.AnyAsync(u => u.Username == name);
        }
    }
}
