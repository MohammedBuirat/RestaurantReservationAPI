using FluentValidation;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Service.IServices;
using System;
using System.Linq;

namespace RestaurantReservation.Validator
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        private readonly ICustomerService _customerService;
        private readonly IRestaurantService _restaurantService;
        private readonly ITableService _tableService;

        public ReservationValidator(ICustomerService customerService, IRestaurantService restaurantService, ITableService tableService)
        {
            _customerService = customerService;
            _restaurantService = restaurantService;
            _tableService = tableService;

            RuleFor(reservation => reservation.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required")
                .MustAsync(CustomerExistsAsync).WithMessage("Customer with the provided ID does not exist");

            RuleFor(reservation => reservation.RestaurantId)
                .NotEmpty().WithMessage("Restaurant ID is required")
                .MustAsync(RestaurantExistsAsync).WithMessage("Restaurant with the provided ID does not exist");

            RuleFor(reservation => reservation.Table)
                .NotNull().WithMessage("Table information is required")
                .MustAsync(TableExistsAsync).WithMessage("Table with the provided information does not exist");

            RuleFor(reservation => reservation.ReservationDate)
                .NotEmpty().WithMessage("Reservation Date is required")
                .GreaterThan(DateTime.Now).WithMessage("Reservation Date should be in the future");

            RuleFor(reservation => reservation.PartySize)
                .NotEmpty().WithMessage("Party Size is required")
                .GreaterThan(0).WithMessage("Party Size should be greater than 0");

            RuleFor(reservation => reservation.Orders)
                .NotNull().WithMessage("Orders list could not be null");
        }

        private async Task<bool> CustomerExistsAsync(int customerId, CancellationToken cancellationToken)
        {
            var existingCustomer = await _customerService.ExistByIdAsync(customerId);
            return existingCustomer;
        }

        private async Task<bool> RestaurantExistsAsync(int restaurantId, CancellationToken cancellationToken)
        {
            var existingRestaurant = await _restaurantService.ExistByIdAsync(restaurantId);
            return existingRestaurant;
        }

        private async Task<bool> TableExistsAsync(Table table, CancellationToken cancellationToken)
        {
            var existingTable = await _tableService.ExistByIdAsync(table.Id);
            return existingTable;
        }
    }
}
