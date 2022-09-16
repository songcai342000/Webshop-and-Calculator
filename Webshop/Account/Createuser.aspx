<%@ Page Title="Create Account" Language="C#" MasterPageFile="/Site.Master" AutoEventWireup="true" CodeFile="Createuser.aspx.cs" Inherits="Createuser" EnableViewState="true"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID = "MainContent" runat="server">
     <h2><%: Title %>.</h2>
    <div class="row">
     <div class="col-md-8">
      <section id="createuserForm">
        <div class="form-horizontal">
             <hr />
           <div class="form-group">
              <asp:Label runat="server" ID="userLabl" CssClass="col-md-2 control-label">User Name</asp:Label>
                <div class="col-md-10">
                <asp:TextBox runat="server" ID="UserTxt" OnTextChanged="UserTxt_TextChanged" AutoPostBack="true" CssClass="form-control" /><asp:Label ID="Label1" runat="server" Visible="false"/><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserTxt" ErrorMessage="This field can't be empty" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div></div>
            <div class="form-group">
                <asp:Label ID="genderLabl" runat="server" CssClass="col-md-2 control-label">Gender</asp:Label>
            <div class="col-md-10">
            <asp:DropDownList runat="server" ID="genderList" AutoPostBack="true" OnSelectedIndexChanged="genderTxt_SelectedIndexChanged" EnableViewState="true" CssClass="form-control">
         
                  <asp:ListItem Value=""> </asp:ListItem>
                 <asp:ListItem Value="Female"> Female </asp:ListItem>
                  <asp:ListItem Value="Male"> Male </asp:ListItem>

                                   </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="UserTxt" ErrorMessage="This field can't be empty" CssClass="text-danger" ></asp:RequiredFieldValidator>
                </div></div>
            <div class="form-group">
                <asp:Label runat="server" ID="emailLabl" CssClass="col-md-2 control-label">Email</asp:Label>
    <div class="col-md-10">
    <asp:TextBox runat="server" ID="EmailTxt" CssClass="form-control"/><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="EmailTxt" ErrorMessage="This field can't be empty" CssClass="text-danger" ></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ErrorMessage="Email address must be in correct format." ControlToValidate="EmailTxt" ValidationExpression="^((([0-9a-z])*@[0-9a-z]*.)+[a-z0-9][-a-z0-9]{0,22}[a-z0-9])$"></asp:RegularExpressionValidator></div></div>
            <div class="form-group">
                <asp:Label ID="passLabl" runat="server" CssClass="col-md-2 control-label">Password</asp:Label>
    <div class="col-md-10"><asp:TextBox runat="server" ID="PasswrdTxt" TextMode="Password" CssClass="form-control"/><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="PasswrdTxt" ErrorMessage="This field can't be empty" CssClass="text-danger" ></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic" ErrorMessage="The password must contain 8 - 12 numbers or letters." ControlToValidate="PasswrdTxt" ValidationExpression="^(([A-Za-z0-9]+){8})$"></asp:RegularExpressionValidator></div></div>
            <div class="form-group">
                <asp:Label runat="server" ID="confirLabl" CssClass="col-md-2 control-label">Repeat Password</asp:Label>
    <div class="col-md-10"><asp:TextBox runat="server" ID="ConfirPasswrdTxt" TextMode="Password" CssClass="form-control"/><asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="The passwords must be same" ControlToCompare="PasswrdTxt" ControlToValidate="ConfirPasswrdTxt" CssClass="text-danger" ></asp:CompareValidator></div></div>
            <div class="form-group">
                <asp:Label runat="server" ID="empty" CssClass="col-md-2 control-label"></asp:Label><div class="col-md-10"><asp:Button runat="server" ID="registerBtn" CssClass="btn btn-default" Text="Register" OnClick="registerBtn_Click"></asp:Button></div>
        </div> </div>
        </section>
         </div></div>

    <div class="col-md-4">
        </div>
</asp:Content>