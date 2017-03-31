using MIMMocker.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIM_Mocker
{
    public interface IMockerRepository
    {
        Task<string> SaveRules(RuleRequest ruleRequest);
        Task SaveResponse(string hashCode, MockResponse response,TimeSpan expiryDuration);
        Task<MockResponse> GetResponse(string hashCode);
    }
}
