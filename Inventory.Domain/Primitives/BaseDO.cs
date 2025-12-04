
namespace Inventory.Domain.Primitives
{
    /// <summary>
    /// Base class for all domain objects (entities).
    /// </summary>
    public abstract class BaseDO
        : IEquatable<BaseDO>
    {
        #region Properties

        public int Id { get; private set; } = default;//int.Newint();

        #endregion

        #region Methods

        #region Operators

        public static bool operator ==(BaseDO? left, BaseDO? right)
        {
            return ReferenceEquals(left, right)
                || (left is not null && left.Equals(right));
        }

        public static bool operator !=(BaseDO? left, BaseDO? right)
        {
            return !(left == right);
        }

        #endregion

        public override bool Equals(object? other)
        {
            return other is BaseDO domainObject
                && GetType() == domainObject.GetType()
                && domainObject.Id == Id;
        }

        public bool Equals(BaseDO? other)
        {
            return Equals((object?)other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion
    }
}
