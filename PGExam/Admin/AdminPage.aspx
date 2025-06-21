<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="DesignTemplate1.Admin.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        * {
          box-sizing: border-box;
        }

        /* Create two equal columns that floats next to each other */
        .column {
          float: left;
          width: 19%;
          padding: 10px;
          text-align:center;
        }
        .column_small {
          float: left;
          width: 1%;   
          background-color:white;
        }

        img{
          
          opacity: 0.5;
        }

        /* Clear floats after the columns */
        .row:after {
          content: "";
          display: table;
          clear: both;
        }
        .auto-style1 {
            color: #006600;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Main Menu</h1>
    <div>
        <p>&nbsp</p>
        <h3 class="auto-style1">Registrations</h3>
    </div>
    <hr />
    <div class="row">
        &nbsp;
    </div>
    <div class="row">
        <div class="column img" style="background-color:cyan; /*opacity:0.2; background-image:url('admin_images/Reg.jpg'); background-repeat: no-repeat;background-size: cover;*/">
        <p>&nbsp;</p>
            <p><i class="fas fa-user-edit"><a href="StudentReg.aspx"> Student</a></i> </p>
            <p>&nbsp;</p>
        </div>

        <div class="column_small">
            <p>&nbsp;</p>
        </div>

        <div class="column" style="background-color:coral ;">
            <p>&nbsp;</p>
            <p><i class="fas fa-user-edit"><a href="addCourses.aspx">Course </a></i></p>
            <p>&nbsp;</p>
        </div>

        <div class="column_small">
            <p>&nbsp;</p>
        </div>

        <div class="column" style="background-color: violet;">
            <p>&nbsp;</p>
            <p><i class="fas fa-user-edit"><a href="addCourseofStudy.aspx">Course of Study</a></i></p>
            <p>&nbsp;</p>
        </div>

        <div class="column_small">
            <p>&nbsp;</p>
        </div>

        <div class="column" style="background-color:#bbb;">
            <p> &nbsp </p>
            <p><i class="fas fa-user-edit"><a href="add_semester_courses">Semester </a></i></p>
            <p> &nbsp </p>
        </div>
    </div>   

    <div class="row">
        &nbsp;
    </div>

    <hr />
   
    <div> 
        <p> &nbsp </p> 
        <h3 class="auto-style1"> Examination</h3>
    </div>    
    <hr /> 
    
    <div class="row">
      <div class="column" style="background-color:cyan;">
        <p> &nbsp </p>
        <p><i class="fas fa-keyboard"><a href="exam_compute">Compute  </a></i></p>
        <p> &nbsp </p>
      </div>  
      
    </div>
    <div class="row">
        &nbsp;
    </div>
    <hr />
    <div>
        <p> &nbsp </p> 
        <h3 class="auto-style1"> Views</h3>
    </div>  
    <hr />
    <div class="row">
        &nbsp;
    </div>
    <div class="row">
        <div class="column" style="background-color:cyan;">
            <p> &nbsp </p>
            <p><i class="fas fa-eye"><a href="view_result">View Student  </a></i></p>
            <p> &nbsp </p>
        </div>
  
        <div class="column_small">
            <p>&nbsp;</p>
        </div>
        <div class="column" style="background-color:coral;">
            <p> &nbsp </p>
            <p><i class="fas fa-eye"><a href="view_result">View Result </a></i></p>
            <p> &nbsp </p>
        </div>
        
    </div>

    <div class="row">
        &nbsp;
    </div>
    <hr />
</asp:Content>
