<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BinarySearch.aspx.cs" Inherits="algoritme_BinarySearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="binaryForm" runat="server">
    <div class="col-md-10">
    <div class="form-group">
        <asp:Label ID="arrayLbl" runat="server" CssClass="col-md-10 control-label" EnableViewState="false"></asp:Label>
    </div>
    <div class="form-group">
        <asp:TextBox ID="numberBox" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
         <div class="form-group">
        <asp:Button ID="submitBtn" runat="server" Text ="Find" CssClass="btn btn-default" OnClick="submitBtn_Click"></asp:Button>
    </div>
        <div class="form-group">
        <asp:Label ID="positionLbl" runat="server" CssClass="col-md-2 control-label" Visible="false"></asp:Label>
    </div>
    </div>
    </form>
</body>
</html>
