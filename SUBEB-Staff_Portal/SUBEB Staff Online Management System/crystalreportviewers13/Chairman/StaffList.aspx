<%@ Page Title="" Language="C#" MasterPageFile="~/Chairman/Chairman.master" AutoEventWireup="true" CodeBehind="StaffList.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Chairman.StaffList" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style16" style="width: 1033px">
        <tr>
            <td style="width: 84px">&nbsp;</td>
            <td class="style7" style="text-align: center; color: #006600; font-size: x-large; background-color: #FFCCFF; " colspan="2"><strong>SUBEB Staff List </strong></td>
            <td style="width: 324px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 84px">&nbsp;</td>
            <td colspan="2">&nbsp;</td>
            <td style="width: 324px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 84px">&nbsp;</td>
            <td style="width: 232px">
                <asp:RadioButton ID="rbtLGEA" runat="server" AutoPostBack="True" Checked="True" GroupName="stafflist" OnCheckedChanged="rbtLGEA_CheckedChanged" Text="LGEA" />
            </td>
            <td style="width: 229px">
                <asp:RadioButton ID="rbtHqtrs" runat="server" AutoPostBack="True" GroupName="stafflist" OnCheckedChanged="rbtHqtrs_CheckedChanged" Text="Headquarters" />
            </td>
            <td style="width: 324px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 84px; height: 23px;"></td>
            <td style="height: 23px;" colspan="2"></td>
            <td style="width: 324px; height: 23px;"></td>
        </tr>
        <tr>
            <td style="width: 84px">&nbsp;</td>
            <td colspan="2">
                <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" BorderWidth="2px" Width="661px">
                    <table class="style16">
                        <tr>
                            <td style="width: 89px; height: 22px;"></td>
                            <td style="height: 22px"></td>
                            <td style="height: 22px"></td>
                        </tr>
                        <tr>
                            <td style="width: 89px">&nbsp;</td>
                            <td><strong>
                                <asp:RadioButton ID="rbtStaffByWorkStation" runat="server" Checked="True" GroupName="Staff" style="font-size: medium" Text="Staff By Work Station" />
                                <br />
                                <asp:RadioButton ID="rbtAllStaff" runat="server" GroupName="Staff" style="font-size: medium" Text="All Staff" />
                                <br />
                                <asp:RadioButton ID="rbtLGEANames" runat="server" GroupName="Staff" style="font-size: medium" Text="LGEA" />
                                </strong></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 89px">&nbsp;</td>
                            <td>
                                <table class="style16">
                                    <tr>
                                        <td style="width: 27px; height: 38px;"></td>
                                        <td style="height: 38px">
                                            <asp:DropDownList ID="ddlLGEA" runat="server" style="font-size: small" OnSelectedIndexChanged="ddlLGEA_SelectedIndexChanged1">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 27px; height: 27px;"></td>
                                        <td style="height: 27px">
                                            <asp:DropDownList ID="ddlSchools" runat="server" Height="39px" OnSelectedIndexChanged="ddlSchools_SelectedIndexChanged" style="font-size: small" Width="547px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 27px">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 89px">&nbsp;</td>
                            <td>
                                <asp:Button ID="btnRetrieve" runat="server" OnClick="btnRetrieve_Click" style="font-size: medium" Text="Retrieve" Width="103px" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 89px">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td style="width: 324px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 84px">&nbsp;</td>
            <td colspan="2">&nbsp;</td>
            <td style="width: 324px">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="height: 78px">
                <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid" BorderWidth="2px">
                </asp:Panel>
                <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true" />
            </td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
