<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    
   
    <table class="auto-style1">
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
            <td class="auto-style21"><strong>Staff</strong></td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style3">
                <asp:Panel ID="Panel1" runat="server" BackColor="#006600" ForeColor="White" Height="70px" HorizontalAlign="Center" Width="121px">
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="True" ForeColor="White">Registration</asp:LinkButton>
                </asp:Panel>
            </td>
            <td class="auto-style16">&nbsp;</td>
            <td class="auto-style5">
                <asp:Panel ID="Panel2" runat="server" BackColor="#FF0066" Height="70px" HorizontalAlign="Center" Width="121px">
                    <br />
                    <asp:LinkButton ID="LinkButton2" runat="server" Font-Underline="True" ForeColor="White" OnClick="LinkButton2_Click">Transfer</asp:LinkButton>
                </asp:Panel>
            </td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style7">
                <asp:Panel ID="Panel3" runat="server" BackColor="#FFCC66" Height="70px" HorizontalAlign="Center" Width="121px">
                    <br />
                    <asp:LinkButton ID="LinkButton3" runat="server" Font-Underline="True" ForeColor="White" OnClick="LinkButton3_Click">Promotion</asp:LinkButton>
                </asp:Panel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style20">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19"></td>
            <td class="auto-style10"></td>
            <td class="auto-style17"></td>
            <td class="auto-style12"><strong>View</strong></td>
            <td class="auto-style13"></td>
            <td class="auto-style14"></td>
            <td class="auto-style20"></td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style3">
                <asp:Panel ID="Panel4" runat="server" BackColor="#33CCFF" Height="70px" HorizontalAlign="Center" Width="121px">
                    <br />
                    <asp:LinkButton ID="LinkButton4" runat="server" Font-Underline="True" ForeColor="White" OnClick="LinkButton3_Click">Staff List</asp:LinkButton>
                </asp:Panel>
            </td>
            <td class="auto-style16">&nbsp;</td>
            <td class="auto-style5">
                <asp:Panel ID="Panel5" runat="server" BackColor="#006600" Height="70px" Width="121px">
                </asp:Panel>
            </td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style7">
                <asp:Panel ID="Panel6" runat="server" BackColor="#FF0066" Height="70px" Width="121px">
                </asp:Panel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
   
    
   
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style3 {
            width: 125px;
        }
        .auto-style5 {
            width: 129px;
        }
        .auto-style7 {
            width: 130px;
        }
        .auto-style8 {
            width: 26px;
        }
        .auto-style10 {
            width: 125px;
            height: 25px;
        }
        .auto-style12 {
            width: 129px;
            height: 25px;
            text-align: center;
        }
        .auto-style13 {
            width: 26px;
            height: 25px;
        }
        .auto-style14 {
            width: 130px;
            height: 25px;
        }
        .auto-style16 {
            width: 29px;
        }
        .auto-style17 {
            width: 29px;
            height: 25px;
        }
        .auto-style18 {
            width: 33px;
        }
        .auto-style19 {
            width: 33px;
            height: 25px;
        }
        .auto-style20 {
            height: 25px;
        }
        .auto-style21 {
            width: 129px;
            text-align: center;
            font-size: large;
        }
    </style>
</asp:Content>

