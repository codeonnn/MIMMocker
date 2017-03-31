using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIMMocker.Common.Model;

namespace MIM_Mocker.Implementation
{
    public class InMemoryRepository : IMockerRepository
    {
        private static Dictionary<string, RuleRequest> Cacheddata = new Dictionary<string, RuleRequest>();
        public async Task<string> SaveRules(RuleRequest ruleRequest)
        {
            var id = Guid.NewGuid().ToString();
            Cacheddata.Add(id, ruleRequest);
            return await Task.FromResult(id);
        }
        public async Task<List<RuleRequest>> GetRules()
        {
            return await Task.FromResult(Cacheddata.Values.ToList());
        }
    }
}
