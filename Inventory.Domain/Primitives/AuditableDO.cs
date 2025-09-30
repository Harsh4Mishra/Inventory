
namespace Inventory.Domain.Primitives
{
    /// <summary>
    /// Auditable base class for all domain objects (entities)
    /// </summary>
    public abstract class AuditableDO
        : BaseDO
    {
        #region Properties

        public string CreatedBy { get; private set; } = default!;
        public DateTime CreatedOn { get; private set; } = default!;
        public string? UpdatedBy { get; private set; }
        public DateTime? UpdatedOn { get; private set; }

        #endregion

        #region Methods

        protected void MarkCreated(string createdBy)
        {
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
        }

        protected void MarkUpdated(string updatedBy)
        {
            UpdatedBy = updatedBy;
            UpdatedOn = DateTime.Now;
        }


        #endregion
    }
}
