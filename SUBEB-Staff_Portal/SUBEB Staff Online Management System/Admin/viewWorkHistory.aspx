<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="viewWorkHistory.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.viewWorkHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style16">
        <tr>
            <td style="width: 341px">
                &nbsp;</td>
            <td style="width: 751px">
                &nbsp;</td>
            <td style="width: 306px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 341px">
                &nbsp;</td>
            <td style="width: 751px">
                <asp:RadioButton ID="rbtLGEA" runat="server" Checked="True" GroupName="db" Text="LGEA" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rbtHqtrs" runat="server" GroupName="db" Text="Hqtrs" />
            </td>
            <td style="width: 306px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 40px; width: 341px;">
                </td>
            <td style="width: 751px; color: #006600; font-size: large; font-weight: 700; height: 40px; background-color: #FFCCFF;">
                Work History</td>
            <td style="height: 40px; width: 306px;">
                </td>
        </tr>
        <tr>
            <td style="width: 341px">
                &nbsp;</td>
            <td style="width: 751px">
                <asp:Label ID="Label2" runat="server" style="color: #FF3300"></asp:Label>
            </td>
            <td style="width: 306px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 341px">
                &nbsp;</td>
            <td style="width: 751px">
                <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderWidth="2px" 
                    GroupingText="Work History" Width="726px">
                    <table class="style16" style="font-size: medium">
                        <tr>
                            <td style="width: 241px; height: 24px">
                                </td>
                            <td style="width: 170px; height: 24px">
                                </td>
                            <td style="width: 626px; height: 24px">
                                </td>
                            <td style="width: 480px; height: 24px">
                                </td>
                        </tr>
                        <tr>
                            <td style="height: 37px; width: 241px;">
                                </td>
                            <td style="height: 37px; width: 170px;">
                                Staff Number</td>
                            <td style="height: 37px; width: 626px;">
                                <asp:TextBox ID="txtStaffNo" runat="server"></asp:TextBox>
                            </td>
                            <td style="height: 37px; width: 480px;">
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 241px">
                                &nbsp;</td>
                            <td style="width: 170px">
                                Name</td>
                            <td style="width: 626px">
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </td>
                            <td style="width: 480px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 241px">
                                &nbsp;</td>
                            <td style="width: 170px">
                                Workstation</td>
                            <td style="width: 626px">
                                <asp:Label ID="lblWorkstation" runat="server"></asp:Label>
                            </td>
                            <td style="width: 480px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 241px">
                                &nbsp;</td>
                            <td style="width: 170px">
                                &nbsp;</td>
                            <td style="width: 626px">
                                <asp:Button ID="btnView" runat="server" onclick="btnView_Click" 
                                    style="font-size: medium" Text="View " Width="93px" />
                            </td>
                            <td style="width: 480px">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td style="width: 306px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 341px">
                &nbsp;</td>
            <td style="width: 751px">
                &nbsp;</td>
            <td style="width: 306px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 341px">
                &nbsp;</td>
            <td style="width: 751px">
                <asp:Image ID="Image2" runat="server" Height="118px" Width="126px" />
            </td>
            <td style="width: 306px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 341px">
                &nbsp;</td>
            <td style="width: 751px">
                &nbsp;</td>
            <td style="width: 306px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 341px">
                &nbsp;</td>
            <td style="width: 751px">
                <asp:Panel ID="Panel4" runat="server">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="5" 
                        style="font-size: medium">
                        <HeaderStyle BackColor="#CCCCCC" ForeColor="#003366" />
                    </asp:GridView>
                </asp:Panel>
            </td>
            <td style="width: 306px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 341px">
                &nbsp;</td>
            <td style="width: 751px">
                &nbsp;</td>
            <td style="width: 306px">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
