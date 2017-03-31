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
        public async Task<MockResponse> ProcessAsync(SessionEventArgs rq)
        {
            Dictionary<string, HttpHeader> dic = new Dictionary<string, HttpHeader>();
            dic.Add("Content-Type", new HttpHeader("Content-Type", "application/json"));

            MockResponse res = new MockResponse();
            res.ResponseString = "{\"name\" : \"testname\"}";
            res.Headers = dic;

            return res;
        }

    }
}
