using MediatR;

namespace Inventory.Application.Features.Vendor.Commands.CreateVendorCommand
{
    public sealed record CreateVendorCommand : IRequest<Guid>
    {
        #region Properties
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        #endregion
    }
}
