using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIMMocker.Common.Model;
using System.Collections.Concurrent;
using System.Runtime.Caching;

namespace MIM_Mocker.Implementation
{
    public class InMemoryRepository : IMockerRepository
    {
        private static MemoryCache CachedResponse = new MemoryCache("ResponseCaching");
        private static Dictionary<string, RuleRequest> CachedRules = new Dictionary<string, RuleRequest>();
        public async Task<string> SaveRules(RuleRequest ruleRequest)
        {
            var id = Guid.NewGuid().ToString();
            CachedRules.Add(id, ruleRequest);
            return await Task.FromResult(id);
        }
        public async Task<List<RuleRequest>> GetRules()
        {
            return await Task.FromResult(CachedRules.Values.ToList());
        }

        public async Task SaveResponse(string hashCode, MockResponse response, TimeSpan timeSpan)
        {
            CachedResponse.Add(hashCode, response, new CacheItemPolicy() { AbsoluteExpiration = new DateTimeOffset(DateTime.Now.Add(timeSpan)) });
            await Task.Delay(0);
        }

        public async Task<MockResponse> GetResponse(string hashCode)
        {
            var cachedResponse = CachedResponse.Get(hashCode);
            if (cachedResponse != null)
                return await Task.FromResult(cachedResponse as MockResponse);
            return null;
        }
    }
}
