using FluentValidation;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Service.IServices;

namespace RestaurantReservation.Validator
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        private readonly IRestaurantService _restaurantService;

        public EmployeeValidator(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;

            RuleFor(employee => employee.RestaurantId)
                .NotEmpty().WithMessage("Restaurant ID is required")
                .MustAsync(RestaurantExistsAsync).WithMessage("Restaurant with the provided ID does not exist");

            RuleFor(employee => employee.FirstName)
                .NotEmpty().WithMessage("First Name is required");

            RuleFor(employee => employee.LastName)
                .NotEmpty().WithMessage("Last Name is required");

            RuleFor(employee => employee.Position)
                .NotEmpty().WithMessage("Position is required");
        }

        private async Task<bool> RestaurantExistsAsync(int restaurantId, CancellationToken cancellationToken)
        {
            var existingRestaurant = await _restaurantService.ExistByIdAsync(restaurantId);
            return existingRestaurant;
        }
    }
}
