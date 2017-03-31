using MIMMocker.Common.Helpers;
using MIMMocker.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titanium.Web.Proxy.EventArguments;

namespace MIM_Mocker
{
    public class DynamicRequestProcessor
    {
        public async Task<MockResponse> ProcessAsync(RuleRequest rule, SessionEventArgs request)
        {
            if (request.WebSession.Request.ContentLength > 0)
            {
                string requestBody = await request.GetRequestBodyAsString();
                var hashKey = SHAGenerator.GenerateSHA256String(requestBody);
                var response = await new Implementation.InMemoryRepository().GetResponse(hashKey);
                if (response == null && request.WebSession.Response.ResponseStatusCode != null)
                {
                    string body = await request.GetResponseBodyAsString();
                    var mockResponse = new MockResponse() { ResponseString = body, ContentType = request.WebSession.Response.ContentType };
                    mockResponse.Headers = request.WebSession.Response.ResponseHeaders;
                    await new Implementation.InMemoryRepository().SaveResponse(hashKey, mockResponse, rule.TTL == default(TimeSpan) ? TimeSpan.FromHours(2) : rule.TTL);
                }
                return response;
            }
            return null;

        }
    }
}
