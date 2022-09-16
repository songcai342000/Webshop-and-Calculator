<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Counter.aspx.cs" Inherits="Counter" EnableViewState="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID = "MainContent" runat="server">    
    <div class="row">
        <div class="col-md-8">
            <section id="counterform">
                <div class="form-horizental">
                    <hr/>
                    <h4>Your items</h4>
    <div class="form-group">
        <asp:Literal runat="server" ID="literal1"></asp:Literal></div>
                    <div class="form-group"><asp:Label runat="server" ID="returnlabl" CssClass="col-md-2 control-label"/><div class= "col-md-10">
            <asp:Button runat="server" id="return" Text="Return to shopping" CssClass="form-control" OnClick="return_Click"></asp:Button></div></div>
      </div>
        </section>
            </div>
        <div class="col-md-8">
            <section id="addressform">
                <div class="form-horizental">
         
                    <hr/>
                     
                    <h4>Your address and telephone number</h4>
                   <br/>
         
<div class="form-group">
    <asp:Label runat="server" ID="nameLabl" CssClass="col-md-2 control-label">Name</asp:Label>
        <div class="col-md-10"><asp:TextBox ID="nameTxt" runat="server" CssClass="form-control" ></asp:TextBox><asp:RequiredFieldValidator runat="server" ControlToValidate="nameTxt" ErrorMessage="This field can't be empty." CssClass="text-danger"/></div>
          </div>
            
            <div class="form-group">
        <asp:Label runat="server" ID="telLabl" CssClass="col-md-2 control-label">Telephone</asp:Label><div class="col-md-10"><asp:TextBox ID="telephoneTxt" runat="server" CssClass="form-control" ></asp:TextBox><asp:RequiredFieldValidator runat="server" ControlToValidate="telephoneTxt" ErrorMessage="This field can't be empty." CssClass="text-danger"/></div>
            </div>
        <div class="form-group"><asp:Label runat="server" ID="addressLabl" CssClass="col-md-2 control-label">Address</asp:Label><div class="col-md-10"><asp:TextBox ID="billingTxt" runat="server" CssClass="form-control" ></asp:TextBox><asp:RequiredFieldValidator runat="server" ControlToValidate="billingTxt" ErrorMessage="This field can't be empty." CssClass="text-danger"/></div>
            </div>
                       <div class="form-group">
            <asp:Label runat="server" ID="emailLabl" CssClass="col-md-2 control-label">Email</asp:Label><div class="col-md-10"><asp:TextBox ID="emailTxt" runat="server" CssClass="form-control" ></asp:TextBox><asp:RequiredFieldValidator runat="server" ControlToValidate="emailTxt" ErrorMessage="This field can't be empty." CssClass="text-danger"/></div>
            </div>
        <div class="form-group">
            <asp:Label runat="server" ID="buttonLabl" CssClass="col-md-2 control-label"></asp:Label>
        <div class="col-md-10">          
        <asp:Button ID="confirm" runat="server" OnClick="confirm_Click" CssClass="form-control" Text="Confirm" ></asp:Button>
    </div></div> 
          </div>               

                </section>
            </div>
  
            </div>
</asp:Content>
