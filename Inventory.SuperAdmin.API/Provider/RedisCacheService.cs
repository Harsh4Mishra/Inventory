using Inventory.SuperAdmin.API.Interface;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Inventory.SuperAdmin.API.Provider
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var cached = await _cache.GetStringAsync(key);

            if (string.IsNullOrEmpty(cached))
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(cached);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
        {
            var serialized = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync(key, serialized, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = expiration });
        }

        public async Task RemoveAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}
