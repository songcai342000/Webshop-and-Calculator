<%@ Page Title="Blueberrynet - a leading cosmatic online store" Language="C#" MasterPageFile="~/Site.Master" EnableViewState="true" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        window.onload = Init();
        function Init()
        {
            i = 0;
            window.setInterval("setPictureInOrder()", 5000);
        }
        function setPictureInOrder()
        {
            i++;
            var imgObj = document.getElementById("presentation");
            var path = "background-color: lightskyblue; background-image: url('/Images/" + "image" + i.toString() + ".jpg');";
            imgObj.setAttribute("style", path);
            if (i == 3)
            {
                i = 0;
            }
        }
    </script>
    <div id="presentation" class="jumbotron" style="background-color: lightskyblue; background-image: url('/Images/image1.jpg');"> 
        <h1>Blueberrynet</h1>
        <h1>Discounted skin care, cosmetic, perfume and hair care products on Blueberrynet</h1>
        
    </div>

    <div class="row">
        <div class="col-md-6">
            <h2>Getting started</h2>
            <p>
                Blueberrynet gives you discounts to all products of the most famous brands.<a href="#">Know more</a>
            </p>
          
        </div>
        <div class="col-md-6">
            <h2>Our products</h2>
            
             
                 <table><tr>
                     <td><a href="/Sproducts.aspx">Skin care</a></td></tr>
                     <tr><td><a href="/Cproducts.aspx">Cosmetic</a></td></tr>
                     <tr><td><a href="/Pproducts.aspx">Perfume</a></td></tr>
                     <tr><td><a href="/Hproducts.aspx">Hair care</a></td></tr>
                 </table>
            
        </div>
        
    </div>
</asp:Content>
