<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to create TreeViewNode.TextTemplate at runtime</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxTreeView ID="treeView" runat="server" DataSourceID="XmlDataSource1" AllowSelectNode="true"
            OnNodeDataBound="treeView_NodeDataBound" TextField="Title" 
            ImageUrlField="NodeTypeImage">
            <Images>
                <NodeImage Width="16px" Height="16px">
                </NodeImage>
            </Images>
            <Styles>
                <NodeImage Paddings-PaddingTop="3px">
                </NodeImage>
            </Styles>
        </dx:ASPxTreeView>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/HelpNav.xml"
            XPath="/namespace/*"></asp:XmlDataSource>
    </div>
    </form>
</body>
</html>
