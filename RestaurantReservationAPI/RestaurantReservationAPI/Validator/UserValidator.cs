using FluentValidation;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Service.IServices;

namespace RestaurantReservationAPI.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator(IRestaurantService restaurantService)
        {
            RuleFor(user => user.Username).NotEmpty().WithMessage("Username can't be null or empty");
            RuleFor(user => user.Password).NotEmpty().WithMessage("Password can't be null or empty");
        }
    }
}
