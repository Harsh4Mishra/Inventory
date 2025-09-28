using Inventory.Domain.Primitives;
using System.Text.RegularExpressions;

namespace Inventory.Domain.ValueObjects
{
    public sealed class EmailVO
        : BaseVO
    {
        #region Fields

        private static readonly Regex _emailRegex = new(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        #endregion

        #region Properties

        public string EmailId { get; } = default!;

        #endregion

        #region Ctor

        public EmailVO() { } //For ORM

        private EmailVO(string emailId)
        {
            EmailId = emailId.Trim();
        }

        #endregion

        #region Methods

        public static EmailVO From(string emailId)
        {
            if (string.IsNullOrWhiteSpace(emailId))
            {
                throw new ArgumentNullException(nameof(emailId), "Input parameter cannot be null or whitespace.");
            }

            if (!_emailRegex.IsMatch(emailId))
            {
                throw new ArgumentException("Invalid input parameter. It must be exactly 10 digits starting with 6-9.", nameof(emailId));
            }

            return new EmailVO(emailId);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EmailId;
        }

        #endregion
    }
}