using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.DTO.CustomerDto
{
    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}