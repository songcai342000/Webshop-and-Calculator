<%@ Page Language="C#" MasterPageFile="~/Site.Master" EnableViewState="true" AutoEventWireup="true" CodeFile="Resetpasswrd.aspx.cs" Inherits="Resetpasswrd" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID = "MainContent" runat="server">
    <h2><%: Title%></h2>
    <div class="row">
        <div class="col-md-8">
           <section id="resetpasswordform">
               <div class="form-horizontal">
                   <h4>Reset Your Password</h4>
                   <hr/>
    <div class="form-group">
            <asp:Label runat="server" ID="newpassword" CssClass="col-md-2 control-label">New Password:</asp:Label>
        <div class="col-md-8"><asp:TextBox runat="server" ID="passwrdTxt" ViewStateMode="Enabled" CssClass="form-control" TextMode="Password"/><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="PasswrdTxt" ErrorMessage="This field can't be empty" CssClass="text-danger" ></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic" ErrorMessage="The password must contain 6-12 letters and numbers, including at least one upper-case letter, one lower-case and one number." ControlToValidate="PasswrdTxt" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,12}$"></asp:RegularExpressionValidator></div></div>
            <div class="form-group">
                <asp:Label runat="server" ID="repeatnewpassword" CssClass="col-md-2 control-label">Repeat Password:</asp:Label>
                    <div class="col-md-8"><asp:TextBox runat="server" ID="repeatTxt" CssClass="form-control" TextMode="Password"/><asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="The passwords must be same" ControlToCompare="PasswrdTxt" ControlToValidate="repeatTxt" CssClass="text-danger" ></asp:CompareValidator></div></div>
            <div class="form-group"><asp:Label runat="server" ID="sendLabl" CssClass="col-md-2 control-label"/>
                <div class="col-md-8"><asp:Button runat="server" ID="saveBtn" Text="Save" OnClick="saveBtn_Click"/></div></div>
                   <div style="color:red"><asp:Literal runat="server" ID="warning"/></div>
    </div>
               </section>
        </div>
        </div>
  </asp:Content>