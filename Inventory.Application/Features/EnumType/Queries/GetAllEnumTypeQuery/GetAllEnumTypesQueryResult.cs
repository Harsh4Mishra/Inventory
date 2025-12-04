namespace Inventory.Application.Features.EnumType.Queries.GetAllEnumTypeQuery
{
    public class GetAllEnumTypesQueryResult
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;

        #endregion
    }
}
