using Inventory.Domain.Primitives;
using System.Text.RegularExpressions;

namespace Inventory.Domain.ValueObjects
{
    public sealed class PinCodeVO
        : BaseVO
    {
        #region Fields

        private static readonly Regex _pinRegex = new("^\\d{6}$", RegexOptions.Compiled);

        #endregion

        #region Properties

        public string PinCode { get; } = default!;

        #endregion

        #region Ctor

        public PinCodeVO() { } //For ORM

        private PinCodeVO(string pinCode)
        {
            PinCode = pinCode.Trim();
        }

        #endregion

        #region Methods

        public static PinCodeVO From(string pinCode)
        {
            if (string.IsNullOrWhiteSpace(pinCode))
            {
                throw new ArgumentNullException(nameof(pinCode), "Input parameter cannot be null or whitespace.");
            }

            if (!_pinRegex.IsMatch(pinCode))
            {
                throw new ArgumentException("Invalid input parameter. It must be exactly 6 digits.", nameof(pinCode));
            }

            return new PinCodeVO(pinCode);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PinCode;
        }

        #endregion
    }
}   