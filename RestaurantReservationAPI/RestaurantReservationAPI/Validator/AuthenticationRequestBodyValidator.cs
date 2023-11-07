using FluentValidation;
using RestaurantReservation.DTO;
using RestaurantReservation.Service.IServices;

namespace RestaurantReservation.Validator
{
    public class AuthenticationRequestBodyValidator : AbstractValidator<AuthenticationRequestBody>
    {

        public AuthenticationRequestBodyValidator(IRestaurantService restaurantService)
        {
            RuleFor(login => login.Username).NotEmpty().WithMessage("Username can't be null or empty");
            RuleFor(login => login.Password).NotEmpty().WithMessage("User password can't be null or empty");
        }
    }
}
