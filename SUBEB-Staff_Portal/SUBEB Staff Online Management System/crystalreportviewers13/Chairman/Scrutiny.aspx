<%@ Page Title="" Language="C#" MasterPageFile="~/Chairman/Chairman.master" AutoEventWireup="true" CodeBehind="Scrutiny.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Chairman.Scrutiny" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td style="width: 69px">&nbsp;</td>
            <td class="auto-style1" style="font-size: medium; width: 1092px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 69px">&nbsp;</td>
            <td class="auto-style1" style="font-size: medium; width: 1092px">
                <asp:RadioButton ID="rbtLGEA" runat="server" Checked="True" GroupName="db" style="font-size: small" Text="LGEA" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rbtHqtrs" runat="server" GroupName="db" style="font-size: small" Text="Hqtrs" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 69px"></td>
            <td class="text-center" style="font-size: medium; height: 30px; width: 1092px; background-color: #FFCCCC"><strong>Staff Scrutiny</strong></td>
            <td style="height: 30px"></td>
        </tr>
        <tr>
            <td style="width: 69px">&nbsp;</td>
            <td style="width: 1092px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table class="nav-justified">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" BorderWidth="2px">
                                        <table class="nav-justified">
                                            <tr>
                                                <td style="width: 79px">&nbsp;</td>
                                                <td style="width: 143px">&nbsp;</td>
                                                <td style="width: 437px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 79px">&nbsp;</td>
                                                <td style="width: 143px">&nbsp;</td>
                                                <td style="width: 437px">&nbsp;</td>
                                                <td>
                                                    <asp:Image ID="Image2" runat="server" Height="124px" style="margin-left: 0px" Width="143px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 79px">&nbsp;</td>
                                                <td style="font-size: medium; width: 143px">Staff Number</td>
                                                <td style="width: 437px">
                                                    <asp:TextBox ID="txtSTaffNo" runat="server" Height="21px" Width="145px"></asp:TextBox>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnView" runat="server" Height="30px" OnClick="btnView_Click" style="font-size: small" Text="View" Width="93px" />
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 79px">&nbsp;</td>
                                                <td style="font-size: medium; width: 143px">Name:</td>
                                                <td style="width: 437px">
                                                    <asp:Label ID="lblName" runat="server" Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderWidth="2px">
                                        <asp:GridView ID="GridView1" runat="server" CellPadding="6" CellSpacing="2" OnRowDataBound="GridView1_RowDataBound">
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 69px">&nbsp;</td>
            <td style="width: 1092px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
