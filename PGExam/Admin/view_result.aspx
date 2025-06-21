<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="view_result.aspx.cs" Inherits="DesignTemplate1.Admin.view_result" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        * {
          box-sizing: border-box;
        }

        /* Create two equal columns that floats next to each other */
        .column1 {
          float: left;
          width: 20%;
          padding: 10px;
          text-align:center;
          background-color:cadetblue
        }
        .column2 {
          float: left;
          width: 80%;
          padding: 10px;
          text-align:center;
        }
        /* Clear floats after the columns */
        .row:after {
          content: "";
          display: table;
          clear: both;
        }
        
        .auto-style1 {
            float: left;
            width: 20%;
            padding: 10px;
            text-align: left;
            background-color: cadetblue;
        }
        .auto-style2 {
            width: 100%;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">
  
              <div class="auto-style1">
        
                  <table class="auto-style2">
                      <tr>
                          <td>&nbsp;</td>
                          <td>Session</td>
                          <td>&nbsp;</td>
                      </tr>
                      <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style28" style="width: 350px; height: 35px">
                                <asp:DropDownList ID="ddlLsession" runat="server" Height="20px">
                                </asp:DropDownList>
                                    &nbsp;<span class="auto-style27"><strong>/</strong></span>
                                <asp:DropDownList ID="ddlUsession" runat="server" Height="20px">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                      </tr>
                      <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style28" style="width: 350px; height: 35px">
                                Semester</td>
                            <td>&nbsp;</td>
                      </tr>
                      <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style28" style="width: 350px; height: 35px">
                                <asp:DropDownList ID="ddlSemester" runat="server" Height="23px">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                      </tr>
                      <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style28" style="width: 350px; height: 35px">
                                Programme</td>
                            <td>&nbsp;</td>
                      </tr>
                      <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style28" style="width: 350px; height: 35px">
                                <asp:DropDownList ID="ddlProgram" runat="server" Height="23px">
                                    <asp:ListItem>PGD</asp:ListItem>
                                    <asp:ListItem>MSc</asp:ListItem>
                                    <asp:ListItem>PhD</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                      </tr>
                      <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style28" style="width: 350px; height: 35px">
                                Course Option</td>
                            <td>&nbsp;</td>
                      </tr>
                      <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style28" style="width: 350px; height: 35px">
                                <asp:DropDownList ID="ddlCourse_Option" runat="server"  Height="18px"  Width="182px">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                      </tr>
                      <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style28" style="width: 350px; height: 35px">
                                <asp:Button ID="btnRetrieve" runat="server" Font-Size="Medium" Text="Retrieve" Width="110px" OnClick="btnRetrieve_Click" />
                            </td>
                            <td>&nbsp;</td>
                      </tr>
                  </table>
        
              </div>
              <div class="column2" ;">
                  <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
              </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
