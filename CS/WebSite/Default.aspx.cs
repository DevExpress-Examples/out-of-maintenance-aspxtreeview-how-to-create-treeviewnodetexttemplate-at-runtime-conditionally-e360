using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxTreeView;
using System.Xml;
using DevExpress.Web.ASPxEditors;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load (object sender, EventArgs e) {
        if (!IsPostBack) {
            treeView.DataBind();
            treeView.ExpandToDepth(0);
        }
    }

    protected void treeView_NodeDataBound (object sender, TreeViewNodeEventArgs e) {
        TreeViewNode node = e.Node as TreeViewNode;
        XmlNode dataNode = ((e.Node.DataItem as IHierarchyData).Item as XmlNode);
        if (dataNode.Name == "class")
            node.TextTemplate = new TextColorItemTemplate();
        else
            node.TextTemplate = new TextItemTemplate();
    }

    class TextItemTemplate : ITemplate {
        public void InstantiateIn (Control container) {
            TreeViewNodeTemplateContainer nodeContainer = container as TreeViewNodeTemplateContainer;
            ASPxLabel lb = new ASPxLabel();
            lb.ID = lb.ClientID;
            lb.Text = nodeContainer.Node.Text;

            container.Controls.Add(lb);
        }
    }

    class TextColorItemTemplate : ITemplate {
        public void InstantiateIn (Control container) {
            TreeViewNodeTemplateContainer nodeContainer = container as TreeViewNodeTemplateContainer;
            ASPxLabel lb = new ASPxLabel();
            lb.ID = lb.ClientID;

            lb.Text = nodeContainer.Node.Text;
            lb.ForeColor = System.Drawing.Color.Blue;

            container.Controls.Add(lb);
        }
    }
}
