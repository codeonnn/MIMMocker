using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jsontree
{
    public partial class _Default : Page
    {
        private static HashSet<string> SelectedPaths = new HashSet<string>();
        private static bool loaded;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private List<TreeNode> GetNodes(TreeNodeCollection nodes)
        {
            var nodeList = new List<TreeNode>();
            foreach (var checkedNode in nodes)
            {
                if (((TreeNode)checkedNode).Checked)
                    nodeList.Add((TreeNode)checkedNode);
                nodeList.AddRange(GetNodes(((TreeNode)checkedNode).ChildNodes));
            }
            return nodeList;

        }
        protected void TreeView1_Load(object sender, EventArgs e)
        {

            if (loaded)
            {
                var nodes = GetNodes(TreeView1.Nodes);
                
                if (SelectedPaths.Contains(TreeView1.SelectedValue))
                {
                    TreeView1.SelectedNode.ShowCheckBox = true;
                    TreeView1.SelectedNode.Checked = false;
                    SelectedPaths.Remove(TreeView1.SelectedValue);
                }
                else
                {
                    TreeView1.SelectedNode.ShowCheckBox = true;
                    TreeView1.SelectedNode.Checked = true;
                    SelectedPaths.Add(TreeView1.SelectedValue);
                }
            }
            if (!loaded)
            {
                using (var reader = new StreamReader(@"C:\Code\C#\data-apis-sdk\Tavisca.DataApis.Sdk.Tests\Test.json"))
                using (var jsonReader = new JsonTextReader(reader))
                {
                    var root = JToken.Load(jsonReader);
                    DisplayTreeView(root, Path.GetFileNameWithoutExtension(@"C:\Code\C#\data-apis-sdk\Tavisca.DataApis.Sdk.Tests\Test.json"));
                }
            }
            loaded = true;
        }
        private void DisplayTreeView(JToken root, string rootName)
        {
            try
            {
                TreeView1.Nodes.Clear();
                var tNode = new TreeNode(rootName);
                tNode.ShowCheckBox = true;
                TreeView1.Nodes.Add(tNode);
                AddNode(root, tNode);
                TreeView1.ExpandAll();
            }
            finally
            {

            }
        }

        private void AddNode(JToken token, TreeNode inTreeNode)
        {
            if (token == null)
                return;
            if (token is JValue)
            {
                var node = new TreeNode(token.ToString(), inTreeNode.Value + "." + token.ToString());
                node.ShowCheckBox = true;
                inTreeNode.ChildNodes.Add(node);
            }
            else if (token is JObject)
            {
                var obj = (JObject)token;
                foreach (var property in obj.Properties())
                {
                    var childNode = new TreeNode(property.Name, inTreeNode.Value + "." + property.Name);
                    childNode.ShowCheckBox = true;
                    inTreeNode.ChildNodes.Add(childNode);

                    AddNode(property.Value, childNode);
                }
            }
            else if (token is JArray)
            {
                var array = (JArray)token;
                for (int i = 0; i < array.Count; i++)
                {
                    var childNode = new TreeNode(i.ToString(), inTreeNode.Value + "." + i.ToString());
                    childNode.ShowCheckBox = true;
                    inTreeNode.ChildNodes.Add(childNode);
                    AddNode(array[i], childNode);
                }
            }

        }
    }
}