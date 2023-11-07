using FluentValidation;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Service.IServices;
using System;

namespace RestaurantReservation.Validator
{
    public class OrderValidator : AbstractValidator<Order>
    {
        private readonly IReservationService _reservationService;
        private readonly IEmployeeService _employeeService;

        public OrderValidator(IReservationService reservationService, IEmployeeService employeeService)
        {
            _reservationService = reservationService;
            _employeeService = employeeService;

            RuleFor(order => order.ReservationId)
                .NotEmpty().WithMessage("Reservation ID is required")
                .MustAsync(ReservationExistsAsync).WithMessage("Reservation with the provided ID does not exist");

            RuleFor(order => order.EmployeeId)
                .NotEmpty().WithMessage("Employee ID is required")
                .MustAsync(EmployeeExistsAsync).WithMessage("Employee with the provided ID does not exist");

            RuleFor(order => order.OrderDate)
                .NotEmpty().WithMessage("Order Date is required");

            RuleFor(order => order.TotalAmount)
                .NotEmpty().WithMessage("Total Amount is required")
                .GreaterThan(0).WithMessage("Total Amount should be greater than 0");
        }

        private async Task<bool> ReservationExistsAsync(int reservationId, CancellationToken cancellationToken)
        {
            var existingReservation = await _reservationService.ExistByIdAsync(reservationId);
            return existingReservation;
        }

        private async Task<bool> EmployeeExistsAsync(int employeeId, CancellationToken cancellationToken)
        {
            var existingEmployee = await _employeeService.ExistByIdAsync(employeeId);
            return existingEmployee;
        }
    }
}
