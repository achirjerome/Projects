<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="staffPromotionHistory.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.staffPromotionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style16">
                <tr>
                    <td>&nbsp;</td>
                    <td style="width: 634px">&nbsp;</td>
                    <td style="width: 4px">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="style7" style="width: 634px; color: #006600; background-color: #FFCCFF;"><strong>Staff Promotion History</strong></td>
                    <td style="width: 4px">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="style7" style="width: 634px; color: #006600; background-color: #FFFFFF;">
                        <asp:Label ID="Label2" runat="server" style="color: #FF3300"></asp:Label>
                    </td>
                    <td style="width: 4px">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td style="width: 634px">
                        <asp:Panel ID="Panel4" runat="server" BackColor="#FFCCCC" BorderStyle="Solid" BorderWidth="2px">
                            <table class="nav-justified">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td style="width: 161px">
                                        <asp:RadioButton ID="rbtLGEA" runat="server" Checked="True" GroupName="section" Text="LGEA" />
                                    </td>
                                    <td style="width: 384px">
                                        <asp:RadioButton ID="rbtHqtrs" runat="server" GroupName="section" Text="Hqtrs" />
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td style="width: 161px">&nbsp;</td>
                                    <td style="width: 384px">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="height: 50px"></td>
                                    <td style="height: 50px; width: 161px;">Staff No</td>
                                    <td style="height: 50px; width: 384px;">
                                        <asp:TextBox ID="txtStaffNo" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="height: 50px">
                                        <asp:Button ID="btnViewCert" runat="server" Height="24px" OnClick="btnViewCert_Click" Text="View" Width="67px" />
                                    </td>
                                    <td style="height: 50px"></td>
                                </tr>
                                <tr>
                                    <td style="height: 32px"></td>
                                    <td style="height: 32px; width: 161px">Name</td>
                                    <td style="height: 32px; width: 384px">
                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                    </td>
                                    <td style="height: 32px"></td>
                                    <td style="height: 32px"></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td style="width: 161px">Current Level</td>
                                    <td style="width: 384px">
                                        <asp:Label ID="lblLevel" runat="server"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td style="width: 161px">&nbsp;</td>
                                    <td style="width: 384px">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                    <td style="width: 4px">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td style="width: 634px">&nbsp;</td>
                    <td style="width: 4px">&nbsp;</td>
                </tr>
            </table>
    <br />
            <table class="style16">
                <tr>
                    <td class="style18" style="width: 307px">&nbsp;</td>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" CellPadding="5" onselectedindexchanged="GridView1_SelectedIndexChanged" style="font-size: medium">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="#FFCCFF" ForeColor="#006600" />
                        </asp:GridView>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="style18" style="width: 307px">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
    <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
