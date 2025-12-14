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
        public DateTime DateOfBirth { get; private set; } = default;
        public int Gender { get; private set; } = default!;
        public bool IsActive { get; private set; } = default;
        public string? PasswordHashKey { get; private set; }
        public string? PasswordSaltKey { get; private set; }
        public int NumberOfAttempts { get; private set; } = default;
        public bool IsPasswordSet { get; private set; } = default;
        public bool IsPasswordLinkVisited { get; private set; } = default;

        #endregion

        #region Ctor

        private UserDO() { } //For ORM

        private UserDO(
            string name,
            PhoneVO phoneNo,
            EmailVO emailId,
            DateTime dateOfBirth,
            int gender,
            string? passwordHashKey = null,
            string? passwordSaltKey = null,
            int numberOfAttempts = 0,
            bool isPasswordSet = false,
            bool isPasswordLinkVisited = false)
        {
            Name = name.Trim();
            PhoneNo = phoneNo;
            EmailId = emailId;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            IsActive = true;

            // Initialize new fields with parameters
            PasswordHashKey = passwordHashKey;
            PasswordSaltKey = passwordSaltKey;
            NumberOfAttempts = numberOfAttempts;
            IsPasswordSet = isPasswordSet;
            IsPasswordLinkVisited=isPasswordLinkVisited;
        }

        #endregion

        #region Methods

        public static UserDO Create(
           string name,
           PhoneVO phoneNo,
           EmailVO emailId,
           DateTime dateOfBirth,
           int gender,
           string createdBy,
           string? passwordHashKey = null,
           string? passwordSaltKey = null,
           int numberOfAttempts = 0,
           bool isPasswordSet = false,
           bool isPasswordLinkVisited=false)
        {
            var user = new UserDO(
                name: name,
                phoneNo: phoneNo,
                emailId: emailId,
                dateOfBirth: dateOfBirth,
                gender: gender,
                passwordHashKey: passwordHashKey,
                passwordSaltKey: passwordSaltKey,
                numberOfAttempts: numberOfAttempts,
                isPasswordSet: isPasswordSet,
                isPasswordLinkVisited:isPasswordLinkVisited);

            user.MarkCreated(createdBy);

            return user;
        }

        public void Update(
            string name,
            PhoneVO phoneNo,
            EmailVO emailId,
            DateTime dateOfBirth,
            int gender,
            string updatedBy,
            string? passwordHashKey = null,
            string? passwordSaltKey = null,
            int? numberOfAttempts = null,
            bool? isPasswordSet = null,
           bool? isPasswordLinkVisited = null)
        {
            Name = name.Trim();
            PhoneNo = phoneNo;
            EmailId = emailId;
            DateOfBirth = dateOfBirth;
            Gender = gender;

            // Update password fields only if provided
            if (passwordHashKey != null)
                PasswordHashKey = passwordHashKey;

            if (passwordSaltKey != null)
                PasswordSaltKey = passwordSaltKey;

            if (numberOfAttempts.HasValue)
                NumberOfAttempts = numberOfAttempts.Value;

            if (isPasswordSet.HasValue)
                IsPasswordSet = isPasswordSet.Value;

            if (isPasswordLinkVisited.HasValue)
                IsPasswordLinkVisited = isPasswordLinkVisited.Value;

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
        public void SetPassword(string passwordHashKey, string passwordSaltKey, string updatedBy)
        {
            PasswordHashKey = passwordHashKey;
            PasswordSaltKey = passwordSaltKey;
            IsPasswordSet = true;
            NumberOfAttempts = 0; // Reset attempts when password is set

            MarkUpdated(updatedBy);
        }

        public void UpdatePassword(string newPasswordHashKey, string newPasswordSaltKey, string updatedBy)
        {
            PasswordHashKey = newPasswordHashKey;
            PasswordSaltKey = newPasswordSaltKey;
            NumberOfAttempts = 0; // Reset attempts when password is updated
            IsPasswordSet = true;

            MarkUpdated(updatedBy);
        }

        public void UpdateNumberOfAttempts(int numberOfAttempts, string updatedBy)
        {
            NumberOfAttempts = numberOfAttempts;
            IsPasswordSet = true;

            MarkUpdated(updatedBy);
        }

        public void ClearPassword(string updatedBy)
        {
            PasswordHashKey = null;
            PasswordSaltKey = null;
            IsPasswordSet = false;
            NumberOfAttempts = 0;

            MarkUpdated(updatedBy);
        }

        public void IncrementAttempts(string updatedBy)
        {
            NumberOfAttempts++;
            MarkUpdated(updatedBy);
        }

        public void ResetAttempts(string updatedBy)
        {
            NumberOfAttempts = 0;
            IsPasswordLinkVisited = false;
            MarkUpdated(updatedBy);
        }

        #endregion
    }
}