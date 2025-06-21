<%@ Page Title="" Language="C#" MasterPageFile="~/Lecturer/LecturerMaster.Master" AutoEventWireup="true" CodeBehind="exam_upload.aspx.cs" Inherits="DesignTemplate1.Lecturer.exam_upload" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3" style="width: 297px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style4" style="width: 297px; color: #006600;"><strong>Upload Examination Scores</strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style4" style="width: 297px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style9" style="width: 552px">
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" CssClass="auto-style10">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table class="auto-style1">
                                    <tr>
                                        <td class="auto-style17" style="height: 22px; width: 59px;"></td>
                                        <td class="auto-style41" style="height: 22px; width: 201px"></td>
                                        <td class="auto-style15" style="width: 350px; height: 22px"></td>
                                        <td class="auto-style6" style="height: 22px"></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style23" style="height: 35px; width: 59px;"></td>
                                        <td class="auto-style39" style="height: 35px; width: 201px">Session</td>
                                        <td class="auto-style28" style="width: 350px; height: 35px">
                                            <asp:DropDownList ID="ddlLsession" runat="server" Height="20px">
                                            </asp:DropDownList>
                                            &nbsp;<span class="auto-style27"><strong>/</strong></span>
                                            <asp:DropDownList ID="ddlUsession" runat="server" Height="20px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style29" style="height: 35px"></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style31" style="height: 33px; width: 59px;"></td>
                                        <td class="auto-style37" style="height: 33px; width: 201px">Semester</td>
                                        <td class="auto-style16" style="width: 350px; height: 33px">
                                            <asp:DropDownList ID="ddlSemester" runat="server" Height="23px">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style8" style="height: 33px"></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style36" style="height: 36px; width: 59px;"></td>
                                        <td class="auto-style33" style="height: 36px; width: 201px">Program</td>
                                        <td class="auto-style34" style="width: 350px; height: 36px">
                                            <asp:DropDownList ID="ddlProgram" runat="server" Height="23px">
                                                <asp:ListItem>PGD</asp:ListItem>
                                                <asp:ListItem>MSc</asp:ListItem>
                                                <asp:ListItem>PhD</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style35" style="height: 36px"></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style17" style="height: 33px; width: 59px;"></td>
                                        <td class="auto-style40" style="height: 33px; width: 201px">Course Option</td>
                                        <td class="auto-style25" style="width: 350px; height: 33px">
                                            <asp:DropDownList ID="ddlCourse_Option" runat="server" AutoPostBack="True" Height="23px" OnSelectedIndexChanged="ddlCourse_Option_SelectedIndexChanged" Width="250px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style26" style="height: 33px"></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style18" style="width: 59px; height: 31px"></td>
                                        <td class="auto-style19" style="width: 201px; height: 31px;">Course Code</td>
                                        <td class="auto-style18" style="width: 350px; height: 31px;">
                                            <asp:DropDownList ID="ddlCourseCode" runat="server" Height="25px" Width="132px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style20" style="height: 31px"></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style18" style="width: 59px"></td>
                                        <td class="auto-style19" style="width: 201px"></td>
                                        <td class="auto-style18" style="width: 350px"></td>
                                        <td class="auto-style20"></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style17" style="height: 29px; width: 59px;"></td>
                                        <td class="auto-style41" style="height: 29px; width: 201px">File</td>
                                        <td class="auto-style18" style="width: 350px; height: 29px">
                                            <asp:FileUpload ID="fulExam" runat="server" />
                                        </td>
                                        <td style="height: 29px"></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style17" style="width: 59px">&nbsp;</td>
                                        <td class="auto-style41" style="width: 201px">&nbsp;</td>
                                        <td class="auto-style18" style="width: 350px">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                       
                    </asp:Panel>
                </td>
                <td style="width: 251px">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21" style="height: 22px"></td>
                <td class="auto-style22" style="width: 552px; height: 22px;"></td>
                <td class="auto-style20" style="width: 251px; height: 22px;"></td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style9" style="width: 552px">
                    <asp:Button ID="btnUpload" runat="server" Font-Size="Medium" Height="31px" Text="Upload" Width="119px" OnClick="btnUpload_Click" />
                </td>
                <td style="width: 251px">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style9" style="width: 552px">
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </td>
                <td style="width: 251px">&nbsp;</td>
            </tr>
        </table>
        <hr />
    </div>
</asp:Content>
