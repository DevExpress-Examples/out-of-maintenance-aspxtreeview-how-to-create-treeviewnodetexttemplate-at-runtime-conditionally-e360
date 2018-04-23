Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxTreeView
Imports System.Xml
Imports DevExpress.Web.ASPxEditors

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not IsPostBack) Then
			treeView.DataBind()
			treeView.ExpandToDepth(0)
		End If
	End Sub

	Protected Sub treeView_NodeDataBound(ByVal sender As Object, ByVal e As TreeViewNodeEventArgs)
		Dim node As TreeViewNode = TryCast(e.Node, TreeViewNode)
		Dim dataNode As XmlNode = (TryCast((TryCast(e.Node.DataItem, IHierarchyData)).Item, XmlNode))
		If dataNode.Name = "class" Then
			node.TextTemplate = New TextColorItemTemplate()
		Else
			node.TextTemplate = New TextItemTemplate()
		End If
	End Sub

	Private Class TextItemTemplate
		Implements ITemplate
		Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
			Dim nodeContainer As TreeViewNodeTemplateContainer = TryCast(container, TreeViewNodeTemplateContainer)
			Dim lb As New ASPxLabel()
			lb.ID = lb.ClientID
			lb.Text = nodeContainer.Node.Text

			container.Controls.Add(lb)
		End Sub
	End Class

	Private Class TextColorItemTemplate
		Implements ITemplate
		Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
			Dim nodeContainer As TreeViewNodeTemplateContainer = TryCast(container, TreeViewNodeTemplateContainer)
			Dim lb As New ASPxLabel()
			lb.ID = lb.ClientID

			lb.Text = nodeContainer.Node.Text
			lb.ForeColor = System.Drawing.Color.Blue

			container.Controls.Add(lb)
		End Sub
	End Class
End Class
