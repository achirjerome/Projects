<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="StaffPromotion.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.StaffPromotion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style16">
                <tr>
                    <td style="width: 240px">&nbsp;</td>
                    <td style="width: 547px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 240px">&nbsp;</td>
                    <td style="width: 547px">
                        <asp:RadioButton ID="rbtLGEA" runat="server" Checked="True" GroupName="db" Text="LGEA" AutoPostBack="True" OnCheckedChanged="rbtLGEA_CheckedChanged" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="rbtHqtrs" runat="server" GroupName="db" Text="Hqtrs" AutoPostBack="True" OnCheckedChanged="rbtHqtrs_CheckedChanged" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 240px; height: 33px;"></td>
                    <td style="width: 547px; height: 33px; color: #006600; text-align: center; font-size: large; font-weight: 700; background-color: #FFCCFF;">Staff Promotion</td>
                    <td style="height: 33px"></td>
                </tr>
                <tr>
                    <td style="width: 240px">&nbsp;</td>
                    <td style="width: 547px">
                        <asp:Label ID="Label4" runat="server" style="color: #FF3300; font-size: medium"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 240px">&nbsp;</td>
                    <td style="width: 547px">
                        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderWidth="2px">
                            <table class="style16">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td style="width: 264px">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="height: 35px"></td>
                                    <td style="font-size: medium; height: 35px; width: 264px;">Staff Number</td>
                                    <td style="height: 35px">
                                        <asp:TextBox ID="txtStaffNo" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="height: 35px">
                                        <asp:Button ID="btnView" runat="server" Font-Bold="True" Font-Size="Small" OnClick="btnView_Click" Text="View" Width="81px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 35px"><span style="font-size: medium"></span></td>
                                    <td style="height: 35px; width: 264px; font-size: medium;">Promotion Date (dd/mm/yyyy)</td>
                                    <td style="height: 35px">
                                        <asp:TextBox ID="txtDate" runat="server" TextMode="Date" Width="164px"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="txtDate_CalendarExtender" runat="server" BehaviorID="TextBox1_CalendarExtender" TargetControlID="txtDate" />
                                    </td>
                                    <td style="height: 35px"></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td style="width: 264px">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 240px">&nbsp;</td>
                    <td style="width: 547px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            &nbsp;
    <br />
            <table class="style16">
                <tr>
                    <td class="style4" style="width: 86px">&nbsp;</td>
                    <td style="width: 1074px">
                        <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" BorderWidth="2px" Width="1001px">
                            <table class="style16">
                                <tr>
                                    <td style="width: 664px">
                                        <asp:GridView ID="GridView1" runat="server" CellPadding="5" CellSpacing="10" Font-Size="Medium" GridLines="Horizontal">
                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                                            <RowStyle BorderStyle="Solid" />
                                        </asp:GridView>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="New Grade Level"></asp:Label>
                                <br />
                                        <asp:DropDownList ID="ddlGradeLevel" runat="server" style="font-size: medium">
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                            <asp:ListItem>14</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                            <asp:ListItem>16</asp:ListItem>
                                            <asp:ListItem>17</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 92px">&nbsp;</td>
                                    <td style="width: 92px">
                                        <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="New Step"></asp:Label>
                                        <br />
                                        <asp:DropDownList ID="ddlSteps" runat="server" style="font-size: medium">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                            <asp:ListItem>14</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 92px"><strong>New Rank<br /> </strong>
                                        <asp:TextBox ID="txtRank" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 664px">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td style="width: 92px">&nbsp;</td>
                                    <td style="width: 92px">&nbsp;</td>
                                    <td style="width: 92px">&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                    <td style="width: 30px">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style4" style="width: 86px">&nbsp;</td>
                    <td style="width: 1074px">&nbsp;</td>
                    <td style="width: 30px">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style4" style="width: 86px">&nbsp;</td>
                    <td style="width: 1074px">
                        <asp:Button ID="btnPromote" runat="server" Font-Size="Medium" onclick="btnPromote_Click" Text="Promote" />
                    </td>
                    <td style="width: 30px">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style4" style="width: 86px">&nbsp;</td>
                    <td style="width: 1074px">&nbsp;</td>
                    <td style="width: 30px">&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
