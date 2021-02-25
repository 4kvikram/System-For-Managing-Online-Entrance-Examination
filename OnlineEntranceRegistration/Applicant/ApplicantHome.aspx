<%@ Page Title="" Language="C#" MasterPageFile="~/Applicant/MasterPageApplicant.Master" AutoEventWireup="true" CodeBehind="ApplicantHome.aspx.cs" Inherits="OnlineEntranceRegistration.Applicant.ApplicantHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <br />
        <div class="col-md-12 sub-head">
            <h4 align="center">Notice</h4>
        </div>
        <div>
            <br />
            <br />
            <br />
            <br />
            <h1> Welcome To The Online Entrance Exam Portal</h1>
              <br />
            <br />
            <h3> Last date of form fillup is 31 July</h3>
            <h2> With Late fee last date of form fillup is 5 August</h2>
            <asp:Label  runat="server" Id="txtnotice"></asp:Label>
        </div>
    </div>
</asp:Content>
