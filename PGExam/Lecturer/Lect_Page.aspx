<%@ Page Title="" Language="C#" MasterPageFile="~/Lecturer/LecturerMaster.Master" AutoEventWireup="true" CodeBehind="Lect_Page.aspx.cs" Inherits="DesignTemplate1.Lecturer.Lect_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        * {
          box-sizing: border-box;
        }

        /* Create two equal columns that floats next to each other */
        .column {
          float: left;
          width: 25%;
          padding: 10px;
          text-align:center;
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
    </style>
    <h1>Upload Menus</h1>
    <hr />
    <div class="row">
        
        <div class="column" style="background-color:cyan;">
            <p>
                &nbsp 
            </p>
            <p>
                 <i class="fas fa-upload"><a href="exam_upload">Upload Result </a></i>
            </p>
            <p>
                &nbsp 
            </p>
        </div>
        
        <div class="column" style="background-color:coral;">
            <p>
                &nbsp 
            </p>
            <p>
                <i class="fas fa-eye"><a href="#">View Result Uploaded </a></i>
            </p>
            <p>
                &nbsp 
            </p>
        </div>

        <div class="column" style="background-color:violet;">
            <p>
                &nbsp 
            </p>
            <p>
                <i class="fas fa-eye"><a href="#">View Rejected Result </a></i>
            </p>
            <p>
                &nbsp 
            </p>
        </div>
    </div>
    <hr />
</asp:Content>
