<%@ Control Language="C#" AutoEventWireup="true" CodeFile="calendarUserCtrl.ascx.cs" Inherits="Usercontrols_calendarUserCtrl" EnableViewState="true" %>
<style type="text/css">
    th{width: 350px; text-align: center}
    td{width: 300px; text-align: center}

</style>
<div>
    <table>
        <tr><th>From</th><th>To</th></tr>
        <tr><td><asp:Calendar ID="fromCalendar" runat="server" Width=" 180px"></asp:Calendar></td><td><asp:Calendar ID="toCalendar" runat="server" Width=" 200px"></asp:Calendar></td></tr>
         <tr><td style="text-align: left">&nbsp;</td><td></td></tr>
    </table>
</div>