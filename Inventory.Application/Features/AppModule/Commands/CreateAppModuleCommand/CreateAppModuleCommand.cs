using MediatR;

namespace Inventory.Application.Features.AppModule.Commands.CreateAppModuleCommand
{
    public sealed record CreateAppModuleCommand : IRequest<int>
    {
        #region Properties
        public int TenantId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        #endregion
    }
}
