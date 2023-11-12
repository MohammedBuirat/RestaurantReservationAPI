using FluentValidation;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Validator
{
    public class RestaurantValidator : AbstractValidator<Restaurant>
    {
        public RestaurantValidator()
        {
            RuleFor(restaurant => restaurant.Name).NotEmpty().WithMessage("Restaurant Name could not be null or empty");
            RuleFor(restaurant => restaurant.Address).NotEmpty().WithMessage("Restaurant Address could not be null or empty");
            RuleFor(restaurant => restaurant.PhoneNumber).NotEmpty().WithMessage("Restaurant Phone Number could not be null or empty");
            RuleFor(restaurant => restaurant.OpeningHours).NotEmpty().WithMessage("Restaurant Opening Hours could not be null or empty");
        }
    }
}
