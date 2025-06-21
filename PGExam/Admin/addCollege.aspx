<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="addCollege.aspx.cs" Inherits="DesignTemplate1.Admin.addCollege" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            text-align: center;
            color: #006600;
        }
        .auto-style6 {
            text-align: center;
            color: #FF0000;
            font-size: small;
        }
        .auto-style7 {
            width: 515px;
        }
        .auto-style8 {
            height: 40px;
        }
        .auto-style9 {
            width: 515px;
            height: 40px;
        }
        .auto-style10 {
            height: 30px;
        }
        .auto-style11 {
            text-align: center;
        }
        .auto-style12 {
            height: 40px;
            width: 243px;
        }
        .auto-style15 {
            width: 124px;
        }
        .auto-style16 {
            margin-left: 34;
        }
        .auto-style17 {
            width: 243px;
            height: 31px;
        }
        .auto-style18 {
            width: 515px;
            height: 31px;
        }
        .auto-style19 {
            height: 31px;
        }
        .auto-style20 {
            width: 243px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style5">
        <strong>
        <br />
        Add New College
    </strong>

    </div>
    <div class="auto-style6">

        <strong><em>(Enter Correctlty but without the COLLEGE key word please)</em></strong></div>
    <div class="auto-style10">
    </div>
    <div class="auto-style11">
        
        <asp:Label ID="lblUni" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#006600"></asp:Label>
&nbsp;</div>
    <div>
        <br />
    </div>
    <div>

        <table class="auto-style1">
            <tr>
                <td class="auto-style12"></td>
                <td class="auto-style9">
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid">
                        <table class="auto-style1">
                            <tr>
                                <td>&nbsp;</td>
                                <td class="auto-style15">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td class="auto-style15">College of</td>
                                <td>
                                    <asp:TextBox ID="txtCollegeName" runat="server" Font-Size="Medium" Height="29px" Width="321px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td class="auto-style15">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17"></td>
                <td class="auto-style18">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="auto-style16" Font-Size="Medium" Height="29px" Text="Submit" Width="130px" OnClick="btnSubmit_Click" />
                </td>
                <td class="auto-style19"></td>
            </tr>
            <tr>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>
</asp:Content>
