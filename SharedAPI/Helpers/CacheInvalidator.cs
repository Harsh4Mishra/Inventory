using Microsoft.AspNetCore.Http;
using SharedAPI.Interfaces;

namespace SharedAPI.Helpers
{
    public sealed class CacheInvalidator : ICacheInvalidator
    {
        private readonly IRedisCacheProvider _redisCacheService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CacheInvalidator(IRedisCacheProvider redisCacheService, IHttpContextAccessor httpContextAccessor)
        {
            _redisCacheService = redisCacheService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task InvalidateAsync()
        {
            var path = _httpContextAccessor.HttpContext?.Request?.Path.ToString();
            if (string.IsNullOrEmpty(path)) return;

            var segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var prefix = segments.Length >= 2 ? $"/{segments[0]}/{segments[1]}" : path;

            await _redisCacheService.RemoveByPrefixAsync(prefix);
        }
    }
}
