<%@ Page Title="Goods Supplement" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Autoorder.aspx.cs" Inherits="Administ_Autoorder" EnableViewState="true" %>
<asp:Content ContentPlaceHolderID = "MainContent" Id = "BodyContent" runat="server">
    <meta http-equiv="refresh" content="216000" >
    <h2><%: Title%></h2>
    <div class="row">
    <div class="form-group">
    <section id="supplementform">
    <div class="form-horizental">
        <hr/>
    <asp:Repeater runat="server" ID="shortageRep" OnItemCommand="shortageRep_ItemCommand" >
    <HeaderTemplate>
        <table class="table">
            <caption>The goods must be complemented</caption>
            <thead>
        <tr class="active">
            <th>ID</th><th>Goodsname</th><th>Quantity</th><th>Vendor</th><th>Price</th><th>Supplement</th><th></th>
        </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>        
        <tbody>
        <tr class="danger">
            <td>'<%# Eval("ID") %>'</td><td>'<%# Eval("Goodsname") %>'</td><td>'<%# Eval("Vendorname") %>'</td><td>'<%# Eval("Price") %>'</td><td>'<%# Eval("Price") %>'</td><td><asp:TextBox runat="server" ID="orderamountTxt" /></td><td><asp:LinkButton id="OrderLink" runat="server" CommandName="Order" Text="Order"></asp:LinkButton></td>
        </tr>
        </tbody>
    </ItemTemplate>
    <FooterTemplate>
    <tfoot>
    </tfoot>
    </table>
   </FooterTemplate>
   </asp:Repeater>
    </div>
    </section>
     </div>
    </div>
</asp:Content>
