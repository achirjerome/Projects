<%@ Page Title="" Language="C#" MasterPageFile="~/Chairman/Chairman.master" AutoEventWireup="true" CodeBehind="StaffCount.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Chairman.StaffCount" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
    <tr>
        <td style="width: 123px">&nbsp;</td>
        <td style="width: 1014px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 123px">&nbsp;</td>
        <td class="text-center" style="font-size: medium; width: 1014px; background-color: #FFCCCC"><strong>Current Staff Strength</strong></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 123px">&nbsp;</td>
        <td style="width: 1014px">
            &nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 123px">&nbsp;</td>
        <td style="width: 1014px; background-color: #CCCCCC;">
            <asp:RadioButton ID="rbtLGEA" runat="server" Checked="True" GroupName="staffcount" Text="LGEA" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="rbtHqtrs" runat="server" GroupName="staffcount" Text="Hqtrs" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnView" runat="server" Height="33px" OnClick="btnView_Click" Text="View" Width="127px" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 123px">&nbsp;</td>
        <td style="width: 1014px">
            &nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 123px">&nbsp;</td>
        <td style="width: 1014px">
            <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" BorderWidth="2px">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </asp:Panel>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 123px">&nbsp;</td>
        <td style="width: 1014px">
            <asp:Label ID="lblHqtrsStaffCount" runat="server" style="font-size: medium"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
