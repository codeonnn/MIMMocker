using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMMocker.Common.Model
{
    public class CachedResponse
    {
        public string ResponseString { get; set; }
        public string ContentType { get; set; }
        public List<Header> Headers { get; set; }
    }
}
