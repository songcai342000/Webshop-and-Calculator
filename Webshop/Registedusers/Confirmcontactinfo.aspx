<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Confirmcontactinfo.aspx.cs" Inherits="Confirmcontactinfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID = "MainContent" runat="server">
    <div>
    <table ><caption>Your Shipping Address</caption>
        <tr>
            <td>Name</td><td><asp:TextBox ID="nameTxt" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ErrorMessage="The field can not be empty" ControlToValidate="nameTxt"></asp:RequiredFieldValidator></td></tr>
        
        <tr>
            <td>Telephone</td><td><asp:TextBox ID="telephoneTxt" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" ErrorMessage="The field can not be empty" ControlToValidate="telephoneTxt"></asp:RequiredFieldValidator></td>
            </tr>
        <tr>
            <td>Address</td><td><asp:TextBox ID="billingTxt" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="*" ErrorMessage="The field can not be empty" ControlToValidate="billingTxt"></asp:RequiredFieldValidator></td>
            </tr>
        <tr>
            <td>Email</td><td><asp:TextBox ID="emailTxt" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="*" ErrorMessage="The field can not be empty" ControlToValidate="emailTxt"></asp:RequiredFieldValidator></td>
            </tr>
     
         <tr>
            <td></td><td><asp:Button ID="ConfirmBtn" runat="server" Text="Confirm" OnClick="ConfirmBtn_Click" /></td>
            </tr>
       
        </table>
    </div>
</asp:Content>