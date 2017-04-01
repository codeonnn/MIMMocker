using MIMMocker.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MIMMocker.Common.Helpers
{
    public class XPathSelector
    {
        public static string GetNodeStringByXpath(List<XPath> xpaths, string xmlString)
        {
            var strBuilder = new StringBuilder();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            foreach (var xpath in xpaths)
            {
                var xmlNode = doc.DocumentElement.SelectSingleNode(xpath.PathName);
                strBuilder.Append(xmlNode.ToString());
            }
            return strBuilder.ToString();
        }

    }
}
