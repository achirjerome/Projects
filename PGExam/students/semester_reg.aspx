<%@ Page Title="" Language="C#" MasterPageFile="~/students/studentsMaster.Master" AutoEventWireup="true" CodeBehind="semester_reg.aspx.cs" Inherits="DesignTemplate1.students.semester_reg" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
       
        .tbl
        {
            width: 100%;
            height:100%;*/
            font-family: tahoma;
        }
       .panelWidth
        {
            width: 70%;
            font-family: tahoma;
        }
        .mGrid1
        {
            width: 60%;
            font-family: tahoma;
        }

        .mGrid1 td   /* this applies to the Gridviews Data fileds */
        {
            padding: 1px;
            text-align:left;
            /*width: 3%;*/
            border: none;
            border-collapse: collapse;
            height:30px;
        }
        .mGrid1 th   /* this applies to the Gridviews Headers */
        {
             padding: 0px 0px;
             border-width: 1px;
             text-align:left;
        }
        
        .auto-style1 {
            height: 20px;
        }
        .auto-style3 {
            font-size: medium;
        }
        .auto-style5 {
            height: 31px;
            font-size: medium;
        }
                                
        .auto-style23 {
            width: 100%;
        }
        .auto-style24 {
            width: 22px;
        }
        
        .auto-style25 {
            height: 20px;
            width: 23px;
        }
        .auto-style26 {
            width: 23px;
        }
        
        .auto-style28 {
            color: #006600;
        }
        .auto-style29 {
            color: #990000;
        }
        .auto-style30 {
            font-family: tahoma;
        }
        .auto-style31 {
            height: 28px;
        }
        .auto-style32 {
            height: 10px;
        }
        
        .auto-style33 {
            text-align: center;
        }
        
        .Background  
        {  
            background-color:aqua;  
            filter: alpha(opacity=90);  
            opacity: 0.3;  
        }  
        .Popup  
        {  
            background-color: #FFFFFF;  
            border-width: 3px;  
            border-style: solid;  
            border-color: black;  
            padding-top: 10px;  
            padding-left: 10px;  
            height: 60%; 
            width: 40%;
            position: absolute;
            right: 0;
        }  

        .auto-style34 {
            width: 385px;
        }
        .auto-style35 {
            width: 22px;
            height: 19px;
        }
        .auto-style36 {
            height: 19px;
        }

    </style>
     <script type="text/javascript">
         var id = null;
         function movePanel() 
         {
            var pnl = $get("Panel4");
            if (pnl != null) 
            {
                //pnl.style.left = "1000px";
                //pnl.style.top = "200px";
                pnl.set_X(2000);
                pnl.set_Y(100);
                pnl.show();
            }
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table class="auto-style23">
            <tr>
                <td class="auto-style35"></td>
                <td class="auto-style36"></td>
                <td class="auto-style36"></td>
            </tr>
            <tr>
                <td class="auto-style24">&nbsp;</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid" BorderWidth="2px" Width="642px">
                                <table class="tbl">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td class="auto-style5">Programme</td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlProgram" runat="server" AutoPostBack="True">
                                                <asp:ListItem>PGD</asp:ListItem>
                                                <asp:ListItem>MSc</asp:ListItem>
                                                <asp:ListItem>PhD</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>Course Option</td>
                                        <td>
                                            <asp:DropDownList ID="ddlCourse_option" runat="server" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style8"></td>
                                        <td class="auto-style27">Session</td>
                                        <td class="auto-style8">
                                            <asp:DropDownList ID="ddlLsession" runat="server" AutoPostBack="True" Height="20px" OnSelectedIndexChanged="ddlLsession_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            &nbsp;<span class="auto-style27"><strong>/</strong></span>
                                            <asp:DropDownList ID="ddlUsession" runat="server" AutoPostBack="True" Height="20px" OnSelectedIndexChanged="ddlUsession_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style8" colspan="2">Semester</td>
                                        <td class="auto-style8">
                                            <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSemester_SelectedIndexChanged">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="title"></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br />
                            <asp:GridView ID="gvCOs" runat="server" BorderStyle="None" CellPadding="5" CellSpacing="5" CssClass="mGrid1" GridLines="Horizontal">
                                <AlternatingRowStyle BackColor="#CCCCCC" BorderStyle="None" />
                                <HeaderStyle BackColor="#FF9999" BorderStyle="Solid" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <div>
        <table class="auto-style23">
            <tr>
                <td class="auto-style25"></td>
                <td class="auto-style1">
                                        &nbsp;</td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style26">&nbsp;</td>
                <td>
                    <asp:UpdatePanel ID="udpsemester" runat="server">
                        <ContentTemplate>
                            <table class="auto-style23">
                                <tr>
                                    <td colspan="2">
                                        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderWidth="2px" Height="130px" Width="573px" CssClass="auto-style30" BackColor="#CCCCCC">
                                            <table class="tbl">
                                                <tr>
                                                    <td class="auto-style32"></td>
                                                    <td class="auto-style32"></td>
                                                    <td class="auto-style32"></td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style31"></td>
                                                    <td class="auto-style31">Course</td>
                                                    <td class="auto-style31">
                                                        <asp:DropDownList ID="ddlCourses" runat="server" CssClass="auto-style3">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style5"></td>
                                                    <td class="auto-style22">
                                                        <asp:Button ID="btnAdd" runat="server" CssClass="auto-style3" OnClick="btnAdd_Click" Text="Add" Width="95px" />
                                                    </td>
                                                    <td class="auto-style7">
                                                        <asp:Button ID="btnRemove" runat="server" CssClass="auto-style3" Text="Remove" OnClick="btnRemove_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1" colspan="2">
                                        <asp:Panel ID="Panel4" CssClass="Popup" runat="server" align="center" style = "display:none">
                                            <iframe style=" width: 100%; height: 100%;" id="irm1" Src="view_reg_courses.aspx" runat="server"></iframe>
                                            <br/>
                                            <asp:Button ID="Button2" runat="server" Text="Close" />
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="GridView1" runat="server" BorderStyle="None" CellPadding="5" CellSpacing="5" CssClass="mGrid1" GridLines="Horizontal">
                                            <AlternatingRowStyle BackColor="#CCCCCC" BorderStyle="None" />
                                            <HeaderStyle BackColor="#FF9999" BorderStyle="Solid" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style33" colspan="2">
                                        <asp:Label ID="Label2" runat="server" Font-Size="Small" ForeColor="#FF3300"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><span class="auto-style28"><strong>Total units:</strong></span> <strong>
                                        <asp:Label ID="Label1" runat="server" CssClass="auto-style29">0</asp:Label>
                                        </strong></td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnRegister" runat="server" Text="Register" Width="127px" OnClick="btnRegister_Click" Height="22px" />
                                    </td>
                                    <td class="auto-style34">
                                        <asp:Button ID="btnView_courses" runat="server" OnClick="btnView_courses_Click" Text="View Registered Courses" />
                                        <cc1:ModalPopupExtender ID="mp2" BackgroundCssClass="Background" runat="server" PopupControlID="Panel4" TargetControlID="btnView_courses" CancelControlID="Button2" X="800" Y="100" >
                                        </cc1:ModalPopupExtender>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style26">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <hr />
</asp:Content>
