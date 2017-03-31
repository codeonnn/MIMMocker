using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;

namespace MIM_Mocker
{
    public class RequestProcessor : IRequestProcessor
    {
        public async Task<MockResponse> ProcessAsync(SessionEventArgs request)
        {
            var rules = await new Implementation.InMemoryRepository().GetRules();
            var matchingRule = rules.Find(r => r.RequestUrl == request.WebSession.Request.Url);
            if (matchingRule != null)
            {
                var response = new MockResponse()
                {
                    ResponseString = matchingRule.ResponseString
                };
                return await Task.FromResult(response);
            }
            return null;
        }
    }

}

