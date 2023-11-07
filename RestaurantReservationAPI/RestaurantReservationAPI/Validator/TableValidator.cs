using FluentValidation;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Service.IServices;

namespace RestaurantReservation.Validator
{
    public class TableValidator : AbstractValidator<Table>
    {
        private readonly IRestaurantService _restaurantService;

        public TableValidator(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;

            RuleFor(table => table.ResturantId)
                .NotEmpty().WithMessage("Restaurant ID is required")
                .Must(ExistsRestaurant).WithMessage("Restaurant with the provided ID does not exist");

            RuleFor(table => table.Capacity)
                .NotEmpty().WithMessage("Table Capacity is required")
                .GreaterThan(0).WithMessage("Table Capacity should be greater than 0");
        }

        private bool ExistsRestaurant(int restaurantId)
        {
            var existingRestaurant = _restaurantService.ExistByIdAsync(restaurantId); 
            return existingRestaurant != null;
        }
    }
}
