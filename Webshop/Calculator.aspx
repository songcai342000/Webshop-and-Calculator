<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Calculator.aspx.cs" Inherits="_Calculator" EnableViewState="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 100px">
      
    </div>
    <div id="showResults">
      
    </div>
   <div>
       <asp:Panel ID="ctrlPanel" runat="server" >
           <asp:TextBox runat="server" ID="inputBox" OnTextChanged="inputBox_TextChanged"></asp:TextBox>
           <br/>
           <asp:Label runat="server" ID="resultLab" Visible="false"></asp:Label>

        </asp:Panel>
      
    </div>
</asp:Content>
