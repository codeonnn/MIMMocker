using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Titanium.Web.Proxy.Models;

namespace MIM_Mocker
{
    public class MockResponse
    {
        public string ResponseString { get; set; }

        public Dictionary<string, HttpHeader> Headers { get; set; }

    }
}
