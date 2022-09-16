<%@ Page Title="Payment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Pay.aspx.cs" Inherits="Pay" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID = "MainContent" runat="server">
       <h2><%: Title%></h2>
    <div class="row">
        <div class="col-md-10">
            <section id="paymentform">
                <div class="form-horizental">
                    <hr/>
                    <h4>Choose a payment method</h4>
                    <br/>
                        <div>
                        <table><tr>
                        <td><a href=""><img src="" class="image-thumbnail"/></a><br/>
                        </td>
                        <td><a href=""><img src="" class="image-thumbnail"/></a><br/>
                       </td>
                            <td><a href=""><img src="" class="image-thumbnail"/></a><br/>
                    </td></tr></table></div></div>
                </section>
                </div>
      </div>
    </asp:Content>