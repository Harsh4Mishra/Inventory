using MediatR;

namespace Inventory.Application.Features.Vendor.Commands.UpdateVendorCommand
{
    public sealed record UpdateVendorCommand : IRequest<Unit>
    {
        #region Properties
        public Guid Id { get; set; } = default;
        public string Name { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string Contact { get; set; } = default!;
        #endregion
    }
}
