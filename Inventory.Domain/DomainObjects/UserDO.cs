using Inventory.Domain.Enums;
using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using Inventory.Domain.ValueObjects;

namespace Inventory.Domain.DomainObjects
{
    public sealed class UserDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public string Name { get; private set; } = default!;
        public PhoneVO PhoneNo { get; private set; } = default!;
        public EmailVO EmailId { get; private set; } = default!;
        public DateOnly DateOfBirth { get; private set; } = default;
        public Gender Gender { get; private set; } = default!;
        public bool IsActive { get; private set; } = default;

        #endregion

        #region Ctor

        private UserDO() { } //For ORM

        private UserDO(
            string name,
            PhoneVO phoneNo,
            EmailVO emailId,
            DateOnly dateOfBirth,
            Gender gender)
        {
            Name = name.Trim();
            PhoneNo = phoneNo;
            EmailId = emailId;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            IsActive = true;
        }

        #endregion

        #region Methods

        public static UserDO Create(
           string name,
           PhoneVO phoneNo,
           EmailVO emailId,
           DateOnly dateOfBirth,
           Gender gender,
           string createdBy)
        {
            var user = new UserDO(name, phoneNo, emailId, dateOfBirth, gender);

            user.MarkCreated(createdBy);

            return user;
        }

        public void Update(
            string name,
            PhoneVO phoneNo,
            EmailVO emailId,
            DateOnly dateOfBirth,
            Gender gender,
            string updatedBy)
        {
            Name = name.Trim();
            PhoneNo = phoneNo;
            EmailId = emailId;
            DateOfBirth = dateOfBirth;
            Gender = gender;

            MarkUpdated(updatedBy);
        }

        public void Activate(string updatedBy)
        {
            IsActive = true;

            MarkUpdated(updatedBy);
        }

        public void Deactivate(string updatedBy)
        {
            IsActive = false;

            MarkUpdated(updatedBy);
        }

        public void SoftDelete(Guid deletedBy)
        {
            if (!IsDeleted)
            {
                MarkDeleted(deletedBy.ToString());
            }
        }

        #endregion
    }
}