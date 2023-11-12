using FluentValidation;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Service.IServices;

namespace RestaurantReservation.Validator
{
    public class MenuItemValidator : AbstractValidator<MenuItem>
    {
        private readonly IRestaurantService _restaurantService;

        public MenuItemValidator(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;

            RuleFor(menuItem => menuItem.RestaurantId)
                .NotEmpty().WithMessage("Restaurant ID is required")
                .MustAsync(RestaurantExistsAsync).WithMessage("Restaurant with the provided ID does not exist");

            RuleFor(menuItem => menuItem.Name)
                .NotEmpty().WithMessage("Name is required");

            RuleFor(menuItem => menuItem.Price)
                .NotEmpty().WithMessage("Price is required")
                .GreaterThan(0).WithMessage("Price should be greater than 0");
        }

        private async Task<bool> RestaurantExistsAsync(int restaurantId, CancellationToken cancellationToken)
        {
            var existingRestaurant = await _restaurantService.ExistByIdAsync(restaurantId);
            return existingRestaurant;
        }
    }
}