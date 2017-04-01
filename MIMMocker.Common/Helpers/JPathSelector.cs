using MIMMocker.Common.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMMocker.Common.Helpers
{
    public class JPathSelector
    {
        public static string GetNodeStringByJpath(List<XPath> jpaths, string jsonString)
        {
            var jObject = JObject.Parse(jsonString);
            var stringBuilder = new StringBuilder();
            foreach (var jPath in jpaths)
            {
                var jtoken = jObject.SelectToken(jPath.PathName);
                stringBuilder.Append(jtoken.ToString());
            }
            return stringBuilder.ToString();
        }
        
    }
}
