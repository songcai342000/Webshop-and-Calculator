<%@ Page Title="Recover Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Recoverpassword.aspx.cs" Inherits="Recoverpassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID = "MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="row">
        <div class="col-md-8">
            <section id="recoverpasswordform">
                <div class="form-horizontal">
                    <hr/>
    <div class="form-group">
    <asp:Label runat="server" ID="emailLabl" CssClass="col-md-2 control-label">Email Address:</asp:Label>
        <div class="col-md-8"><asp:TextBox runat="server" ID="emailTxt" CssClass="form-control"/></div>
    </div>
                    <div class="form-group">
    <asp:Label runat="server" ID="sendLabl" CssClass="col-md-2 control-label"></asp:Label>
        <div class="col-md-8"><asp:Button runat="server" ID="SendBtn" CssClass="btn btn-default" Text="Send" OnClick="SendBtn_Click"/></div>
    </div>
                    <div style="color: red"><asp:Literal runat="server" ID="warning" /></div>
                    </div>
                </section>
            </div>
        </div>

</asp:Content>