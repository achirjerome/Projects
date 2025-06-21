<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="StaffReg.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.StaffReg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 127%;
        }
        .auto-style5 {
            background-color: #00CC99;
        }
        .auto-style6 {
            width: 100%;
        }
        .auto-style8 {
            width: 735px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <table class="auto-style4">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style5">
                    <table class="auto-style6">
                        <tr>
                            <td></td>
                            <td>
                                <asp:RadioButton ID="rbtLGEA" runat="server" Text="LGEA" />
                            </td>
                            <td>
                                <asp:RadioButton ID="rbtHqtrs" runat="server" GroupName="category" Text="Hqtrs" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>  
    <div>
    <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="5" Font-Size="Medium" OnFinishButtonClick="Wizard1_FinishButtonClick" OnNextButtonClick="Wizard1_NextButtonClick" >
            <HeaderTemplate>
            <table style="width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="wizardTitle">
                        <%= Wizard1.ActiveStep.Title%>
                    </td>
                    <td>
                        <table style="width: 100%; border-collapse: collapse;">
                            <tr>
                                <td style="text-align: right">
                                    <span class="wizardProgress">Steps:</span>
                                </td>
                                <asp:Repeater ID="SideBarList" runat="server">
                                    <ItemTemplate>
                                        <td class="stepBreak">&nbsp;</td>
                                        <td class="<%# GetClassForWizardStep(Container.DataItem) %>" title="<%# DataBinder.Eval(Container, "DataItem.Name")%>">
                                            <%# Wizard1.WizardSteps.IndexOf(Container.DataItem as WizardStep) + 1 %>
                                        </td>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </HeaderTemplate>
            <WizardSteps>
                <asp:WizardStep ID="details" runat="server" title="Staff Bio Data">
                    
                    <div class="row">
                      <%--<div class="column left" style="background-color:#fff;">
                       
                      </div>--%>
                      <div class="column middle" style="background-color:#bbb;">
                          <hr />
                          Firstname<br />
                          <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox>
                          <hr />
                          
                          Middlename<br />
                          <asp:TextBox ID="txtMiddlename" runat="server"></asp:TextBox>
                          <hr />
                          
                          Surname <br />
                          <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
                          <hr />
                          Sex <br />
                           <asp:RadioButton ID="rbtMale" runat="server" Checked="True" GroupName="Sex"  Text="Male" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:RadioButton ID="rbtFemale" runat="server" CssClass="style27" GroupName="Sex"  Text="Female" />
                          <hr />
                          Marrital Status <br />
                          <asp:DropDownList ID="ddlMaritalStatus" runat="server" Height="26px"  Width="127px">
                                                        <asp:ListItem>Single</asp:ListItem>
                                                        <asp:ListItem>Married</asp:ListItem>
                                                        <asp:ListItem>Divorced </asp:ListItem>
                                                        <asp:ListItem>Widow</asp:ListItem>
                                                    </asp:DropDownList>
                          <hr />
                          Date of Birth <br />
                          <asp:TextBox ID="txtDateofBirth" runat="server"></asp:TextBox>
                                                    
                          <ajaxToolkit:CalendarExtender ID="txtDateofBirth_CalendarExtender" runat="server" BehaviorID="txtDateofBirth_CalendarExtender" TargetControlID="txtDateofBirth" />
                                                    
                          <hr />
                          Home town <br />
                          <asp:TextBox ID="txtHometown" runat="server"></asp:TextBox>
                          <hr />

                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                              <ContentTemplate>
                                  Nationality<br />
                                  <asp:DropDownList ID="ddlNationality" runat="server" AutoPostBack="True" CssClass="style27" Height="25px" OnSelectedIndexChanged="ddlNationality_SelectedIndexChanged" style="font-size: medium">
                                                                            <asp:ListItem>Nigeria</asp:ListItem>
                                                                        </asp:DropDownList>
                                  <hr />                                  
                                  State of Origin<br />
                                  <asp:DropDownList ID="ddlSOO" runat="server" AutoPostBack="True" CssClass="style27" Height="26px" onselectedindexchanged="ddlSOO_SelectedIndexChanged" style="font-size: medium">
                                                                       </asp:DropDownList>
                                 
                                  <hr />
                                  LGA<br />
                                  <asp:DropDownList ID="ddlLGA" runat="server" CssClass="style27" Height="26px" style="font-size: medium">
                                                                        </asp:DropDownList>
                                  <hr />
                                  
                              </ContentTemplate>

                          </asp:UpdatePanel>   
                         
                      </div>
                        
                      <div class="column right" style="background-color:#bbb;">
                          
                          Religion <br />
                          <asp:DropDownList ID="ddlReligion" runat="server" Height="20px" OnSelectedIndexChanged="ddlReligion_SelectedIndexChanged" style="font-size: medium" Width="161px">
                                                        <asp:ListItem>Christianity</asp:ListItem>
                                                        <asp:ListItem>Islam</asp:ListItem>
                                                        <asp:ListItem>Atheist</asp:ListItem>
                                                        <asp:ListItem>Judaism</asp:ListItem>
                                                        <asp:ListItem>Hundaism</asp:ListItem>
                                                        <asp:ListItem>Other</asp:ListItem>
                                                    </asp:DropDownList>
                          <hr />
                          
                          Contact Address <br />
                          <asp:TextBox ID="txtContactAddress" runat="server" CssClass="style27" Height="39px" style="font-size: medium" TextMode="MultiLine" Width="296px"></asp:TextBox>
                          <hr />

                          Permanent Address <br />
                          <asp:TextBox ID="txtPermanentAddress" runat="server" Height="39px" TextMode="MultiLine" Width="297px"></asp:TextBox>
                          <hr />
                          Phone Number <br />
                          <asp:TextBox ID="txtPhoneNo" runat="server" TextMode="Number"></asp:TextBox>
                          <hr />

                          Email <br />
                          <asp:TextBox ID="txtemail" runat="server" TextMode="Email"></asp:TextBox>
                          <hr />
                          Blood Group <br />
                          <asp:DropDownList ID="ddlBloodGroup" runat="server">
                                                        <asp:ListItem>A</asp:ListItem>
                                                        <asp:ListItem>AB</asp:ListItem>
                                                        <asp:ListItem>B</asp:ListItem>
                                                        <asp:ListItem>O+</asp:ListItem>
                                                        <asp:ListItem>O-</asp:ListItem>
                                                    </asp:DropDownList>
                          <hr />
                      </div>
                    </div>

                </asp:WizardStep>
                <asp:WizardStep ID="Education" runat="server" title="Staff Education">
                    <div class="row">
                      <div class="column middle" style="background-color:#aaa;">
                        <br />
                        <hr />
                        Highest Qualification <br />
                        <asp:DropDownList ID="ddlQualification" runat="server" Height="26px" style="font-size: medium" Width="113px">
                                    <asp:ListItem>FSLC</asp:ListItem>
                                    <asp:ListItem>ND</asp:ListItem>
                                    <asp:ListItem>NCE</asp:ListItem>
                                    <asp:ListItem>PGD</asp:ListItem>
                                    <asp:ListItem>PGDE</asp:ListItem>
                                    <asp:ListItem>B Sc</asp:ListItem>
                                    <asp:ListItem>B Sc(ED)</asp:ListItem>
                                    <asp:ListItem>B Tech</asp:ListItem>
                                    <asp:ListItem>M Sc</asp:ListItem>
                                    <asp:ListItem>PhD</asp:ListItem>
                                    <asp:ListItem>M Ed</asp:ListItem>
                                    <asp:ListItem>SSCE</asp:ListItem>
                                    <asp:ListItem>BA</asp:ListItem>
                                    <asp:ListItem>MA</asp:ListItem>
                                    <asp:ListItem>B Agric</asp:ListItem>
                                    <asp:ListItem>B Eng</asp:ListItem>
                                    <asp:ListItem>M Eng</asp:ListItem>
                                    <asp:ListItem>M Tech</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                        <hr />
                        <br />
                         Field of Study <br />
                        <asp:TextBox ID="txtSpeciaty" runat="server" Height="27px" style="font-size: medium" Width="270px"></asp:TextBox>
                        <hr />
                                                   
                      </div>
                     
                    </div>
                </asp:WizardStep>
                <asp:WizardStep runat="server" Title="Employment">
                    <div class="row">
                      <div class="column middle" style="background-color:#aaa;">
                        <hr />
                        Staff Number <br />
                        <asp:TextBox ID="TextBox7" runat="server" ></asp:TextBox>
                        <hr />
                        Date of Appointment <br />
                        <asp:TextBox ID="TextBox8" runat="server" ></asp:TextBox>
                          <ajaxToolkit:CalendarExtender ID="TextBox8_CalendarExtender" runat="server" BehaviorID="TextBox8_CalendarExtender" TargetControlID="TextBox8" />
                        <hr />  
                          
                         Date of Last Promotion <br />
                        <asp:TextBox ID="TextBox9" runat="server" ></asp:TextBox>
                        <hr />
                         Job Type <br />
                        <asp:TextBox ID="TextBox10" runat="server" ></asp:TextBox>
                       
                        <hr />
                        Grade Level /Steps <br />
                        <asp:DropDownList ID="ddlCurrentGradeLevel" runat="server" Height="25px" style="font-size: medium">
                                    <asp:ListItem>Grade Level</asp:ListItem>
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
                          <asp:DropDownList ID="ddlCurrentStep" runat="server" Height="25px" style="font-size: medium">
                                    <asp:ListItem>Step</asp:ListItem>
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
                                </asp:DropDownList>
                        <hr />
                        Rank <br />
                        <asp:TextBox ID="TextBox12" runat="server" ></asp:TextBox>
                        <hr />

                          <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                              <ContentTemplate>
                                  Work LGEA<br />
                                  <asp:DropDownList ID="ddlWorkLGEA" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlWorkLGEA_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                  <hr />                                  
                                  Workstation<br />
                                  <asp:DropDownList ID="ddlWorkStation" runat="server">
                                                        </asp:DropDownList>
                                  <hr />                                                             
                                  
                              </ContentTemplate>

                          </asp:UpdatePanel>   
                      </div>
                     
                    </div>
                </asp:WizardStep>
                <asp:WizardStep runat="server" Title="Payment Details">
                    <div class="row">
                      <div class="column middle" style="background-color:#aaa;">
                        <hr />
                        Bank Name <br />
                          <asp:DropDownList ID="ddlBankName" runat="server" AutoPostBack="False" Width="214px">
                                                        </asp:DropDownList>
                        <hr />
                        Account Number <br />
                        <asp:TextBox ID="TextBox11" runat="server" MaxLength="10" TextMode="Number" ></asp:TextBox>
                        <hr />  
                      </div>
                     
                    </div>
                </asp:WizardStep>
                <asp:WizardStep runat="server" Title="Passport">
                    <div class="row">
                      <div class="column middle" style="background-color:#aaa;">
                        <hr />
                        Passport <br />
                        <asp:FileUpload ID="fuPassport" runat="server" CssClass="style27" style="font-size: medium" />
                        <hr />
                     </div>
                    </div>
                    
                </asp:WizardStep>
                <asp:WizardStep ID="summary" runat="server" Title="Summary">
                    <div class="row">
                      <div class="column summary1" style="background-color:#aaa;">
                          <h2> Bio Data</h2>
                            <hr />
                          Firstname<br />
                          <asp:Label ID="lblFirstname" runat="server" Text="Label"></asp:Label>
                          <hr />
                          
                          Middlename<br />
                          <asp:Label ID="lblMiddlename" runat="server" Text="Label"></asp:Label>
                          <hr />
                          
                          Surname <br />
                          <asp:Label ID="lblSurname" runat="server" Text="Label"></asp:Label>
                          <hr />
                          Sex <br />
                          <asp:Label ID="lblSex" runat="server" Text="Label"></asp:Label>
                          <hr />
                          Marrital Status <br />
                           <asp:Label ID="lblMarritalStatus" runat="server" Text="Label"></asp:Label>
                          <hr />
                          Date of Birth <br />
                           <asp:Label ID="lblDOB" runat="server" Text="Label"></asp:Label>                                          
                          <hr />
                          Home town <br />
                           <asp:Label ID="lblHometown" runat="server" Text="Label"></asp:Label>
                          <hr />

                        Nationality<br />
                            <asp:Label ID="lblNationality" runat="server" Text="Label"></asp:Label>
                        <hr />                                  
                        State of Origin<br />
                            <asp:Label ID="lblSOO" runat="server" Text="Label"></asp:Label>
                        <hr />   
                               
                      </div>
                      <div class="column summary2" style="background-color:#bbb;">
                          LGA<br />
                                    <asp:Label ID="lblLGA" runat="server" Text="Label"></asp:Label>
                          <hr />
                          Religion <br />
                          <asp:Label ID="lblReligion" runat="server" Text="Label"></asp:Label>
                          <hr />
                          
                          Contact Address <br />
                          <asp:Label ID="lblContactAddress" runat="server" Text="Label"></asp:Label>
                          <hr />

                          Permanent Address <br />
                          <asp:Label ID="lblPermanentAddress" runat="server" Text="Label"></asp:Label>
                          <hr />
                          Phone Number <br />
                          <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                          <hr />

                          Email <br />
                          <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                          <hr />
                          Blood Group <br />
                          <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                          <hr />   
                          <h2>Education</h2>
                          <hr />
                          Highest Qualification <br />
                          <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                          <hr />
                          Field of Study <br />
                          <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
                          <hr />   
                      </div>

                        <div class="column summary3" style="background-color:#bbb;">
                            <h2>Employment</h2>
                          <hr />
                        Staff Number <br />
                        <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                        <hr />
                        Date of Appointment <br />
                        <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
                        <hr />  
                          
                         Date of Last Promotion <br />
                        <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
                        <hr />
                         Job Type <br />
                        <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
                       
                        <hr />
                        Grade Level /Steps <br />
                        <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
                        <hr />
                        Rank <br />
                        <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
                        <hr />
                        Work LGEA<br />
                        <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label>
                        <hr />                                  
                        Workstation<br />
                        <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>          
                        <hr />    
                      </div>

                        <div class="column summary3" style="background-color:#bbb;">
                            <h2>Employment</h2>
                          <hr />
                        Staff Number <br />
                        <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
                        <hr />
                        Date of Appointment <br />
                        <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label>
                        <hr />  
                          
                         Date of Last Promotion <br />
                        <asp:Label ID="Label29" runat="server" Text="Label"></asp:Label>
                        <hr />
                         Job Type <br />
                        <asp:Label ID="Label30" runat="server" Text="Label"></asp:Label>
                       
                        <hr />
                          
                            <br />
                            <asp:Image ID="Image1" runat="server" Height="128px" Width="123px" />
                          
                      </div>
                    </div>  
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
    </div>
</asp:Content>
