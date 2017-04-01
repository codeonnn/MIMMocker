using MIMMocker.Common.Helpers;
using MIMMocker.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;

namespace MIM_Mocker
{
    public class DynamicRequestProcessor
    {
        public async Task<MockResponse> ProcessAsync(RuleRequest rule, SessionEventArgs request)
        {
            if (request.WebSession.Request.ContentLength > 0)
            {
                string requestBodyMatch = null;

                if (request.WebSession.Request.ContentType.ToLower() == "application/json" && rule.JPaths != null && rule.JPaths.Count > 0)
                    requestBodyMatch = JPathSelector.GetNodeStringByJpath(rule.JPaths, await request.GetRequestBodyAsString());

                else if (request.WebSession.Request.ContentType.ToLower() == "application/xml" && rule.JPaths != null && rule.JPaths.Count > 0)
                    requestBodyMatch = XPathSelector.GetNodeStringByXpath(rule.XPaths, await request.GetRequestBodyAsString());
                else
                    requestBodyMatch = await request.GetRequestBodyAsString();
                if (rule.Headers != null && rule.Headers.Count > 0)
                {
                    rule.Headers.ForEach(h =>
                    {
                        HttpHeader header;
                        if (request.WebSession.Request.RequestHeaders.TryGetValue(h.Name, out header))
                            requestBodyMatch += header.Value;
                    });
                }
                var hashKey = SHAGenerator.GenerateSHA256String(requestBodyMatch);
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

