using Microsoft.Extensions.Caching.Distributed;
using SharedAPI.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SharedAPI.Helpers
{
    public sealed class RedisCacheProvider : IRedisCacheProvider
    {
        private readonly IDistributedCache _cache;
        private readonly IConnectionMultiplexer _redis;
        //private readonly IDatabase _database;

        public RedisCacheProvider(IDistributedCache cache, IConnectionMultiplexer redis)
        {
            _cache = cache;
            _redis = redis;
            //_database = _redis.GetDatabase();
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

        public async Task RemoveByPrefixAsync(string prefix)
        {
            var endpoints = _redis.GetEndPoints();

            foreach (var endpoint in endpoints)
            {
                var server = _redis.GetServer(endpoint);

                if (!server.IsConnected || server.IsSlave) // skip disconnected or read-only replicas
                    continue;

                var keys = server.Keys(pattern: $"*{prefix}*").ToArray();

                foreach (var key in keys)
                {
                    await _cache.RemoveAsync(key);
                }
            }
        }
    }
}
