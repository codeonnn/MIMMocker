using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMMocker.Common.Model
{
    public class RuleRequest
    {
        public string Domain { get; set; }
        public string RequestUrl { get; set; }
        public string RequestType { get; set; }
        public List<Header> Headers { get; set; }
        public List<XPath> XPaths { get; set; }
        public Header MockIdentifier { get; set; }
        public TimeSpan Latency { get; set; }
        public string ResponseString { get; set; }
    }
}
