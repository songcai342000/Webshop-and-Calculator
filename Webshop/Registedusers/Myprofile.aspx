<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/Site.Master" EnableViewState="true" AutoEventWireup="true" CodeFile="Myprofile.aspx.cs" Inherits="Myprofile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID = "MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="row">
        <div class="col-md-10">
            <section id="profileform">
                <div class="form-horizental">
                    <hr/>
                    <div class="form-group">
                            <asp:Label runat="server" ID="usernameLabl" CssClass="col-md-2 control-label">User Name</asp:Label>
        <div class="col-md-10"><asp:TextBox ID="usernameTxt" runat="server" CssClass="form-control" OnTextChanged="usernameTxt_TextChanged1"></asp:TextBox><asp:RequiredFieldValidator runat="server" ControlToValidate="UsernameTxt" ErrorMessage="This field can't be empty." CssClass="text-danger"/><asp:Label runat="server" ID="Label1" Visible="false"/></div>
          </div>
<div class="form-group">
    <asp:Label runat="server" ID="nameLabl" CssClass="col-md-2 control-label">Name</asp:Label>
        <div class="col-md-10"><asp:TextBox ID="nameTxt" runat="server" CssClass="form-control" OnTextChanged="nameTxt_TextChanged" ></asp:TextBox><asp:RequiredFieldValidator runat="server" ID="namerequired" ControlToValidate="nameTxt" ErrorMessage="This field can't be empty." CssClass="text-danger" /></div>
          </div>
            <div class="form-group"><asp:Label runat="server" ID="genderLabl" CssClass="col-md-2 control-label" >Gender</asp:Label>
                <div class="col-md-10"><asp:DropdownList ID="genderList" runat="server" CssClass="form-control" OnSelectedIndexChanged="genderList_SelectedIndexChanged">
            
            <asp:ListItem value=""></asp:ListItem>
             <asp:ListItem value="Female">Female</asp:ListItem>
             <asp:ListItem value="Male">Male</asp:ListItem></asp:DropDownList><asp:RequiredFieldValidator runat="server" ErrorMessage="This field can't be empty" ControlToValidate="genderList" CssClass="text-danger"/></div></div>
           
            <div class="form-group">
        <asp:Label runat="server" ID="telLabl" CssClass="col-md-2 control-label">Telephone</asp:Label><div class="col-md-10"><asp:TextBox ID="telephoneTxt" runat="server" CssClass="form-control" OnTextChanged="telephoneTxt_TextChanged" ></asp:TextBox><asp:RequiredFieldValidator runat="server" ID="telephonerequired" ErrorMessage="This field can't be empty." ControlToValidate="telephoneTxt" CssClass="text-danger" /></div>
            </div>
        <div class="form-group"><asp:Label runat="server" ID="addressLabl" CssClass="col-md-2 control-label">Address</asp:Label><div class="col-md-10"><asp:TextBox ID="billingTxt" runat="server" CssClass="form-control" OnTextChanged="billingTxt_TextChanged"></asp:TextBox><asp:RequiredFieldValidator runat="server" id="billingrequired" ErrorMessage="This field can't be empty." ControlToValidate="billingTxt" CssClass="text-danger" /></div>
            </div>
        <div class="form-group">
            <asp:Label runat="server" ID="emailLabl" CssClass="col-md-2 control-label">Email</asp:Label><div class="col-md-10"><asp:TextBox ID="emailTxt" runat="server" CssClass="form-control" OnTextChanged="emailTxt_TextChanged" ></asp:TextBox><asp:RequiredFieldValidator runat="server" ControlToValidate="emailTxt" ErrorMessage="This field can't be empty." CssClass="text-danger" /></div>
            </div>
      
        <div class="form-group">
            <asp:Label runat="server" ID="pointsLabl" CssClass="col-md-2 control-label">Points</asp:Label><div class="col-md-10"><asp:TextBox ID="pointsTxt" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox></div>
            </div>
          <div class="form-group">          
         <div class="col-md-offset-2 col-md-10"><asp:Button ID="saveBtn" runat="server" Text="Save profile" OnClick="saveBtn_Click1" CssClass="form-control"/></div></div>
       <div class="form-group"><div class="col-md-offset-2 col-md-10">
                     <asp:Button ID="deleteBtn" runat="server" Text="Delete profile" OnClick="deleteBtn_Click" CssClass="form-control"/>
                </div></div>
                    </div>
        </section>
        </div>
    
          
      
    <div class="col-md-10">
         
        <section id="changepassword">
         <div class="form-horizental"> 
             <h4>Change Password</h4>
             <hr/> 
        <div class="form-group">
            <asp:Label runat="server" ID="passwordLabl" CssClass="col-md-2 control-label" >Present Password</asp:Label><div class="col-md-10"><asp:TextBox ID="oldpass" runat="server" CssClass="form-control"></asp:TextBox></div>
            
            </div>
        <div class="form-group">
            <asp:Label runat="server" ID="newpasswordLabl" CssClass="col-md-2 control-label" >New Password</asp:Label><div class="col-md-10"><asp:TextBox ID="newpassword" runat="server" CssClass="form-control"></asp:TextBox></div>
            
            </div>
              <div class="form-group">
            <asp:Label runat="server" ID="repeatLabl" CssClass="col-md-2 control-label" >Repeat <br/>New Password</asp:Label><div class="col-md-10"><asp:TextBox ID="repeaterpassword" runat="server" CssClass="form-control"></asp:TextBox></div>
           
            </div>
            <div class="form-group">
             <div class="col-md-offset-2 col-md-10"><asp:Button runat="server" ID="savenewpassBtn" CssClass="form-control" Text="Save" OnClick="savenewpassBtn_Click"></asp:Button></div></div>
               </div>
    </section>
      </div>
        </div>
      
</asp:Content>