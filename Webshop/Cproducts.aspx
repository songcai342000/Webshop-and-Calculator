<%@ Page Title="Cosmetic" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Cproducts.aspx.cs" Inherits="Cproducts" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID = "MainContent" runat="server">
 <style type="text/css">
     td{width:175px;padding-left:3px;padding-right:5px;}
</style>    <br>
    <h5><a href="Sproducts.aspx">Skin Care</a>&nbsp; &nbsp; &nbsp; &nbsp; <a href="Pproducts.aspx">Perfume</a>&nbsp; &nbsp; &nbsp; &nbsp;<a href="Hproducts.aspx">Haircare</a></h5> 
    <h2><%: Title%></h2> 
<div class="row">
  
    <div class="form-group">
     <section id="skincareproducts">
         <div class="form-horizental">
             <hr/>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <headertemplate>
                      <table class="table">
                       
                          <thead>
                                         <tr class="active">
                        <td  class="td"> <asp:Literal ID="image" runat="server" Text="Picture"></asp:Literal></td>
                        <td  class="td"> <asp:Literal runat="server" ID="nameLabl1" Text="Name"></asp:Literal></td>
                        <td  class="td"> <asp:Literal runat="server" ID="sizeLabl1" Text="Size"></asp:Literal></td>
                        <td  class="td"> <asp:Literal runat="server" ID="weightLabl1" Text="Weight"></asp:Literal></td>
                        <td  class="td"> <asp:Literal runat="server" ID="priceLabl1" Text="Price"></asp:Literal></td>
                        <td  class="td"><asp:Literal runat="server" ID="chooseLabl1" Text="Choose"></asp:Literal> </td>
                                             <td class="td"><asp:Literal runat="server" ID="removeLabl1" Text="Remove"></asp:Literal> </td>
                      </tr>
                              </thead>
                    </headertemplate>

                    <itemtemplate>
                        <tbody>
                      <tr class="success" id="goodstr">
                        <td class="td"> <asp:ImageButton ID="image" runat="server" src='<%# Eval("Picture") %>'></asp:ImageButton></td>
                        <td class="td"> <asp:Literal runat="server" ID="nameLabl" Text='<%# Eval("Goodsname") %>'></asp:Literal></td>
                        <td class="td"> <asp:Literal runat="server" ID="sizeLabl" Text='<%# Eval("Size") %>'></asp:Literal></td>
                        <td class="td"> <asp:Literal runat="server" ID="weightLabl" Text='<%# Eval("Weight") %>'></asp:Literal>g</td>
                        <td class="td"> <asp:Literal runat="server" ID="priceLabl" Text='<%# Eval("Price") %>'></asp:Literal>$</td>
                        <td class="td"> <asp:LinkButton runat="server" autopostback="true" ID="chooseBtn" CommandName="chooseitem" Text="Choose"></asp:LinkButton></td>
                        <td class="td"> <asp:LinkButton runat="server" ID="removeBtn" autopostback="true" CommandName="removeitem" Text="Remove"></asp:LinkButton></td>
                      </tr>
                            </tbody>
                    </itemtemplate>
                    
                    <footertemplate>
                        <tfoot>
                        </tfoot>
                      </table>
                    </footertemplate>
        </asp:Repeater>
             </div>
        </section>
        </div>     
  
    </div>
   </asp:Content>
