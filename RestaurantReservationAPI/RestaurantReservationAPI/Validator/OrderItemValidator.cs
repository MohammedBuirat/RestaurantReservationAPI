using FluentValidation;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Service.IServices;
using System.Threading.Tasks;

namespace RestaurantReservation.Validator
{
    public class OrderItemValidator : AbstractValidator<OrderItem>
    {
        private readonly IOrderService _orderService;
        private readonly IMenuItemService _menuItemService;

        public OrderItemValidator(IOrderService orderService, IMenuItemService menuItemService)
        {
            _orderService = orderService;
            _menuItemService = menuItemService;

            RuleFor(orderItem => orderItem.OrderId)
                .NotEmpty().WithMessage("Order ID is required")
                .MustAsync(OrderExistsAsync).WithMessage("Order with the provided ID does not exist");

            RuleFor(orderItem => orderItem.MenuItemId)
                .NotEmpty().WithMessage("Menu Item ID is required")
                .MustAsync(MenuItemExistsAsync).WithMessage("Menu Item with the provided ID does not exist");

            RuleFor(orderItem => orderItem.Quantity)
                .NotEmpty().WithMessage("Quantity is required")
                .GreaterThan(0).WithMessage("Quantity should be greater than 0");
        }

        private async Task<bool> OrderExistsAsync(int orderId, CancellationToken cancellationToken)
        {
            var existingOrder = await _orderService.ExistByIdAsync(orderId);
            return existingOrder;
        }

        private async Task<bool> MenuItemExistsAsync(int menuItemId, CancellationToken cancellationToken)
        {
            var existingMenuItem = await _menuItemService.ExistByIdAsync(menuItemId);
            return existingMenuItem;
        }
    }
}
