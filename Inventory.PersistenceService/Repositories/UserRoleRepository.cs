using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using Inventory.PersistenceService.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Inventory.PersistenceService.Repositories
{
    public sealed class UserRoleRepository : IUserRoleRepository
    {
        #region Fields

        private readonly InventoryDBContext _dbContext;

        #endregion

        #region Ctor

        public UserRoleRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<UserRoleDO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.UserRoles
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all user-role assignments: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<UserRoleDO>> GetAllToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.UserRoles
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all user-role assignments: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<UserRoleDO>> GetAllActiveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.UserRoles
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active user-role assignments: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<UserRoleDO>> GetAllActiveToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.UserRoles
                    .Where(e => e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all active user-role assignments: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<UserRoleDO>> GetAllUndeletedAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.UserRoles
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all undeleted user-role assignments: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<UserRoleDO>> GetAllUndeletedToMutateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.UserRoles
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching all undeleted user-role assignments: {ex.Message}");
            }
        }

        public async Task<UserRoleDO?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.UserRoles
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching user-role assignment by id: {ex.Message}");
            }
        }

        public async Task<UserRoleDO?> GetByIdToMutateAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.UserRoles
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching user-role assignment by id: {ex.Message}");
            }
        }

        public async Task<UserRoleDO?> GetActiveByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.UserRoles
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active user-role assignment by id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<UserRoleDO>> GetByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (userId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid user id provided");
                }

                return await _dbContext.UserRoles
                    .AsNoTracking()
                    .Where(e => e.UserId == userId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching user-role assignments by user id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<UserRoleDO>> GetByUserIdToMutateAsync(
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (userId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid user id provided");
                }

                return await _dbContext.UserRoles
                    .Where(e => e.UserId == userId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching user-role assignments by user id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<UserRoleDO>> GetActiveByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (userId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid user id provided");
                }

                return await _dbContext.UserRoles
                    .AsNoTracking()
                    .Where(e => e.UserId == userId && e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active user-role assignments by user id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<UserRoleDO>> GetByRoleIdAsync(
            Guid roleId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (roleId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid role id provided");
                }

                return await _dbContext.UserRoles
                    .AsNoTracking()
                    .Where(e => e.RoleId == roleId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching user-role assignments by role id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<UserRoleDO>> GetByRoleIdToMutateAsync(
            Guid roleId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (roleId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid role id provided");
                }

                return await _dbContext.UserRoles
                    .Where(e => e.RoleId == roleId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching user-role assignments by role id: {ex.Message}");
            }
        }

        public async Task<IReadOnlyCollection<UserRoleDO>> GetActiveByRoleIdAsync(
            Guid roleId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (roleId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid role id provided");
                }

                return await _dbContext.UserRoles
                    .AsNoTracking()
                    .Where(e => e.RoleId == roleId && e.IsActive)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active user-role assignments by role id: {ex.Message}");
            }
        }

        public async Task<UserRoleDO?> GetByUserAndRoleAsync(
            Guid userId,
            Guid roleId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (userId == Guid.Empty || roleId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid user id or role id provided");
                }

                return await _dbContext.UserRoles
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.UserId == userId && e.RoleId == roleId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching user-role assignment by user and role: {ex.Message}");
            }
        }

        public async Task<UserRoleDO?> GetByUserAndRoleToMutateAsync(
            Guid userId,
            Guid roleId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (userId == Guid.Empty || roleId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid user id or role id provided");
                }

                return await _dbContext.UserRoles
                    .FirstOrDefaultAsync(e => e.UserId == userId && e.RoleId == roleId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching user-role assignment by user and role: {ex.Message}");
            }
        }

        public async Task<UserRoleDO?> GetActiveByUserAndRoleAsync(
            Guid userId,
            Guid roleId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (userId == Guid.Empty || roleId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid user id or role id provided");
                }

                return await _dbContext.UserRoles
                    .AsNoTracking()
                    .Where(e => e.IsActive)
                    .FirstOrDefaultAsync(e => e.UserId == userId && e.RoleId == roleId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while fetching active user-role assignment by user and role: {ex.Message}");
            }
        }

        public void Add(UserRoleDO userRole)
        {
            if (userRole is null)
            {
                throw new ArgumentNullException(nameof(userRole));
            }

            _dbContext.UserRoles.Add(userRole);
        }

        public void Update(UserRoleDO userRole)
        {
            if (userRole is null)
            {
                throw new ArgumentNullException(nameof(userRole));
            }

            _dbContext.UserRoles.Update(userRole);
        }

        public void Remove(UserRoleDO userRole)
        {
            if (userRole is null)
            {
                throw new ArgumentException(nameof(userRole));
            }

            _dbContext.UserRoles.Remove(userRole);
        }

        public async Task<bool> ExistsByUserAndRoleAsync(
            Guid userId,
            Guid roleId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (userId == Guid.Empty || roleId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid user id or role id provided");
                }

                return await _dbContext.UserRoles.AnyAsync(
                    e => e.UserId == userId && e.RoleId == roleId,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking user-role assignment by user and role: {ex.Message}");
            }
        }

        public async Task<bool> ActiveExistsByUserAndRoleAsync(
            Guid userId,
            Guid roleId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (userId == Guid.Empty || roleId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid user id or role id provided");
                }

                return await _dbContext.UserRoles.AnyAsync(
                    e => e.UserId == userId && e.RoleId == roleId && e.IsActive,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking active user-role assignment by user and role: {ex.Message}");
            }
        }

        public async Task<bool> ExistsByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (userId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid user id provided");
                }

                return await _dbContext.UserRoles.AnyAsync(e => e.UserId == userId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking user-role assignments by user id: {ex.Message}");
            }
        }

        public async Task<bool> ActiveExistsByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (userId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid user id provided");
                }

                return await _dbContext.UserRoles.AnyAsync(
                    e => e.UserId == userId && e.IsActive,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking active user-role assignments by user id: {ex.Message}");
            }
        }

        public async Task<bool> ExistsByRoleIdAsync(
            Guid roleId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (roleId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid role id provided");
                }

                return await _dbContext.UserRoles.AnyAsync(e => e.RoleId == roleId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking user-role assignments by role id: {ex.Message}");
            }
        }

        public async Task<bool> ActiveExistsByRoleIdAsync(
            Guid roleId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (roleId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid role id provided");
                }

                return await _dbContext.UserRoles.AnyAsync(
                    e => e.RoleId == roleId && e.IsActive,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking active user-role assignments by role id: {ex.Message}");
            }
        }

        public async Task<bool> ExistsByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.UserRoles.AnyAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking user-role assignment by id: {ex.Message}");
            }
        }

        public async Task<bool> ActiveExistsByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid id provided");
                }

                return await _dbContext.UserRoles.AnyAsync(
                    e => e.Id == id && e.IsActive,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"EFCore error while checking active user-role assignment by id: {ex.Message}");
            }
        }

        #endregion
    }
}
