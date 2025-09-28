using Inventory.Domain.Primitives;
using System.Text.RegularExpressions;

namespace Inventory.Domain.ValueObjects
{
    public sealed class PhoneVO
        : BaseVO
    {
        #region Fields

        private static readonly Regex _phoneRegex = new(@"^[6-9]\d{9}$", RegexOptions.Compiled);

        #endregion

        #region Properties

        public string PhoneNo { get; } = default!;

        #endregion

        #region Ctor

        public PhoneVO() { } //For ORM

        private PhoneVO(string phoneNo)
        {
            PhoneNo = phoneNo.Trim();
        }

        #endregion

        #region Methods

        public static PhoneVO From(string phoneNo)
        {
            if (string.IsNullOrWhiteSpace(phoneNo))
            {
                throw new ArgumentNullException(nameof(phoneNo), "Input parameter cannot be null or whitespace.");
            }

            if (!_phoneRegex.IsMatch(phoneNo))
            {
                throw new ArgumentException("Invalid input parameter. It must be exactly 10 digits starting with 6-9.", nameof(phoneNo));
            }

            return new PhoneVO(phoneNo);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PhoneNo;
        }

        #endregion
    }
}