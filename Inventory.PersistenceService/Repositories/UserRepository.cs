using Microsoft.EntityFrameworkCore;
using Inventory.PersistenceService.Configurations;
using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using Inventory.Domain.ValueObjects;

namespace Inventory.PersistenceService.Repositories
{
    public sealed class UserRepository
    : IUserRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public UserRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<UserDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Users
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all Users : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<UserDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Users
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all Users : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<UserDO>> GetAllActiveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Users
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active Users : {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<UserDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.Users
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active Users : {ex.Message}");
            }
        }

        public async Task<UserDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching user by id : {ex.Message}");
            }
        }

        public async Task<UserDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.Users
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching user by id : {ex.Message}");
            }
        }

        public async Task<UserDO?> GetByMobileNumberToMutateAsync(
            string mobileNumber,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(mobileNumber))
                {
                    throw new ArgumentException("Invalid mobile Number provided");
                }
                // Validate and wrap into PhoneVO
                PhoneVO phoneVO = PhoneVO.From(mobileNumber);

                return await _dbContext.Users
                    .FirstOrDefaultAsync(e => e.PhoneNo.PhoneNo == phoneVO.PhoneNo, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching user by id : {ex.Message}");
            }
        }

        public async Task<UserDO?> GetByEmailToMutateAsync(
            string emailId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emailId))
                {
                    throw new ArgumentException("Invalid emailId provided");
                }
                // Validate and wrap into EmailVO
                EmailVO emailIdVO = EmailVO.From(emailId);

                return await _dbContext.Users
                    .FirstOrDefaultAsync(e => e.PhoneNo.PhoneNo == emailIdVO.EmailId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching user by id : {ex.Message}");
            }
        }

        //public async Task<UserDO?> GetByNameAsync(
        //    string name,
        //    CancellationToken cancellationToken = default)
        //{
        //    try
        //    {
        //        if (name is null)
        //        {
        //            throw new ArgumentNullException("Invalid name provided");
        //        }

        //        return await _dbContext.Users
        //            .AsNoTracking()
        //            .FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"EFCore error while fetching user by name : {ex.Message}");
        //    }
        //}

        //public async Task<UserDO?> GetByNameToMutateAsync(
        //    string name,
        //    CancellationToken cancellationToken = default)
        //{
        //    try
        //    {
        //        if (name is null)
        //        {
        //            throw new ArgumentNullException("Invalid name provided");
        //        }

        //        return await _dbContext.Users
        //            .FirstOrDefaultAsync(e => e.Name == name, cancellationToken);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"EFCore error while fetching user by name : {ex.Message}");
        //    }
        //}

        public void Add(UserDO user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _dbContext.Users.Add(user);
        }

        public void Update(UserDO user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _dbContext.Users.Update(user);
        }

        public void Remove(UserDO user)
        {
            if (user is null)
            {
                throw new ArgumentException(nameof(user));
            }

            _dbContext.Users.Remove(user);
        }

        public async Task<bool> ExistsByMobileNumberAsync(
            string mobileNumber,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (mobileNumber is null)
                {
                    throw new ArgumentNullException("Invalid mobile number provided");
                }

                // Validate and wrap into PhoneVO
                PhoneVO phoneVO = PhoneVO.From(mobileNumber);

                return await _dbContext.Users.AnyAsync(i => i.PhoneNo.PhoneNo == mobileNumber, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking user by name : {ex.Message}");
            }
        }

        public async Task<bool> ExistsByEmailAsync(
            string emailid,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (emailid is null)
                {
                    throw new ArgumentNullException("Invalid emailid provided");
                }


                // Validate and wrap into EmailVO
                EmailVO emailVO = EmailVO.From(emailid);

                return await _dbContext.Users.AnyAsync(i => i.EmailId.EmailId == emailid, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking user by name : {ex.Message}");
            }
        }

        #endregion
    }
}
