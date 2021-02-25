<%@ Page Title="" Language="C#" MasterPageFile="~/Applicant/MasterPageApplicant.Master" AutoEventWireup="true" CodeBehind="ApplicationStatus.aspx.cs" Inherits="OnlineEntranceRegistration.Applicant.ApplicationStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <br />
        <div class="col-md-12 sub-head">
            <h4 align="center">Application Status</h4>
        </div>
        <div class="col-md-12 jumbotron">
            <h1 align="center" class="font-bold text-primary"><label id="lblmessage" runat="server"></label> </h1>
        </div>
    </div>
</asp:Content>
