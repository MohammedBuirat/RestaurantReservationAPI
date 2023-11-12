using FluentValidation;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Validator
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator() 
        {
            RuleFor(customer => customer.FirstName).NotEmpty().WithMessage("First Name could not be null or empty");
            RuleFor(customer => customer.Email).NotEmpty().WithMessage("email can't be null or empty").
                EmailAddress().WithMessage("email format invalid"); ;
            RuleFor(customer => customer.PhoneNumber).NotEmpty().WithMessage("Phone number is required")
                .MinimumLength(8).MaximumLength(15).
                WithMessage("Phone number length should be between 8 and 15"); ;
        }
    }
}
