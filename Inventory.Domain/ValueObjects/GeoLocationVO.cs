using Inventory.Domain.Primitives;

namespace Inventory.Domain.ValueObjects
{
    public sealed class GeoLocationVO
        : BaseVO
    {
        #region Properties

        public double Latitude { get; } = default!;
        public double Longitude { get; } = default!;

        #endregion

        #region Ctor

        public GeoLocationVO() { } //For ORM

        private GeoLocationVO(
            double latitude,
            double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        #endregion

        #region Methods

        public static GeoLocationVO From(
            double latitude,
            double longitude)
        {
            if (latitude < -90 || latitude > 90)
            {
                throw new ArgumentOutOfRangeException(nameof(latitude), latitude, "Inupt parameter must be between -90 and 90 degrees.");
            }

            if (longitude < -180 || longitude > 180)
            {
                throw new ArgumentOutOfRangeException(nameof(longitude), longitude, "Inuput parameter must be between -180 and 180 degrees.");
            }

            return new GeoLocationVO(latitude, longitude);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
        }

        #endregion
    }
}