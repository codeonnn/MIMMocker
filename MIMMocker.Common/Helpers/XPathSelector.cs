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
        public static string GetNodeStringByXpath(string xpath, string xmlString)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            var xmlNode = doc.DocumentElement.SelectSingleNode(xpath);
            return xmlNode.ToString();
        }

    }
}
