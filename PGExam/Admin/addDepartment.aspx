<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="addDepartment.aspx.cs" Inherits="DesignTemplate1.Admin.addDepartment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            text-align: center;
        }
        .auto-style11 {
            width: 552px;
        }
        .auto-style16 {
            color: #FF3300;
            font-size: small;
        }
        .auto-style17 {
            font-size: small;
        }
        .auto-style20 {
            width: 151px;
            height: 45px;
        }
        .auto-style22 {
            height: 45px;
        }
        .auto-style27 {
            width: 151px;
        }
        .auto-style28 {
            width: 532px;
        }
        .auto-style29 {
            width: 153px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style4">
        <strong>
        <br />Add New Department<br />
&nbsp;</strong></div>
    <div class="auto-style4">
        <asp:Label ID="lblUni" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#006600">Joseph Sarwuan Tarka University Makurdi</asp:Label>
&nbsp;</div>
    <div>
        <br />
        <hr />
    </div>

    <div class="auto-style4">
        <strong><em><span class="auto-style16">
        <br />
        (Enter correctly but without the DEPARTMENT key word please )</span></em></strong></div>

    <div>
        <table >
            <tr>
                <td class="auto-style29">&nbsp;</td>
                <td class="auto-style11">
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid">
                        <table class="auto-style28">
                            <tr>
                                <td class="auto-style22"></td>
                                <td class="auto-style20">College</td>
                                <td class="auto-style22">
                                    <asp:DropDownList ID="ddlCollege" runat="server" Font-Size="Medium" Height="25px">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style22"></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td >
                                    <asp:Label ID="Label1" runat="server" Text="Department of" Width="100px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDeptName" runat="server" Font-Size="Medium" Height="23px" Width="313px" CssClass="auto-style6" style="margin-left: 41"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td class="auto-style27">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style29">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style29">&nbsp;</td>
                <td class="auto-style11">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="auto-style17" Font-Size="Medium" Height="29px" Text="Submit" Width="130px" OnClick="btnSubmit_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style29">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

        <div>
            <hr />
        </div>
    </div>
</asp:Content>
