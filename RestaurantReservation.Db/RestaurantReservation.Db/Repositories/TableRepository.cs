using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.GenericRepository;
using RestaurantReservation.Db.Repositories.IRepostories;

namespace RestaurantReservation.Db.Repositories
{
    public class TableRepository : Repository<Table>, ITableRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        public TableRepository(RestaurantReservationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
