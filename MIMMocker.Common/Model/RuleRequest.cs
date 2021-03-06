﻿using MIMMocker.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Extensions;
using Titanium.Web.Proxy.Http.Responses;

namespace MIMMocker.Common.Model
{
    public class RuleRequest
    {
        public string Origin { get; set; }
        public string Domain { get; set; }
        public string RequestUrl { get; set; }
        public string RequestType { get; set; }
        public List<Header> Headers { get; set; }
        public List<XPath> XPaths { get; set; }
        public List<XPath> JPaths { get; set; }
        public Header MockIdentifier { get; set; }
        public TimeSpan Latency { get; set; }
        public bool IsDynamic { get; set; }
        public string ResponseString { get; set; }
        public TimeSpan TTL { get; set; }
       
    }
}
