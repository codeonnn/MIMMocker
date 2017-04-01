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
                if (matchingRule.IsDynamic)
                {
                    return await new DynamicRequestProcessor().ProcessAsync(matchingRule, request);
                }
                else
                {
                    var response = new MockResponse()
                    {
                        ResponseString = matchingRule.ResponseString
                    };
                    response.Headers.Add("IsMockResponse", new HttpHeader("IsMockResponse", "true"));
                    if (response != null)
                    {
                        if (matchingRule.Latency != default(TimeSpan))
                            await Task.Delay(matchingRule.Latency);
                    }
                    return await Task.FromResult(response);
                }
            }
            return null;
        }
    }

}

