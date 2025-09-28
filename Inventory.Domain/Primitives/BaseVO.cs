
namespace Inventory.Domain.Primitives
{
    /// <summary>
    /// Base class for all value objects.
    /// </summary>
    public abstract class BaseVO
        : IEquatable<BaseVO>
    {
        #region Methods

        /// <summary>
        /// Gets the components that define equality for this value object.
        /// </summary>
        protected abstract IEnumerable<object> GetEqualityComponents();

        public static bool operator ==(BaseVO? left, BaseVO? right)
        {
            return ReferenceEquals(left, right)
                || (left is not null && left.Equals(right));
        }

        public static bool operator !=(BaseVO? left, BaseVO? right)
        {
            return !(left == right);
        }

        public override bool Equals(object? obj)
        {
            return obj is BaseVO valueObject
                && GetType() == valueObject.GetType()
                && GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public bool Equals(BaseVO? other)
        {
            return Equals((object?)other);
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();

            foreach (var component in GetEqualityComponents())
            {
                if (component is not null)
                {
                    hash.Add(component);
                }
            }
            return hash.ToHashCode();
        }

        #endregion
    }
}
