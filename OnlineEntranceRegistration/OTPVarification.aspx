<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OTPVarification.aspx.cs" Inherits="OnlineEntranceRegistration.OTPVarification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <br />
        <div class="col-md-12 sub-head">
            <h4 align="center">OTP Varification </h4>
        </div>
        <div class="col-md-12 jumbotron">
            <div id="" class="form-group">
                <label for="id_oldPassword" class=" requiredField">
                    Enter OTP<span class="asteriskField">*</span>
                </label>
                <div class="">
                    <asp:TextBox ID="txtotp" class="textinput textInput form-control" placeholder=" Enter OTP"  runat="server"></asp:TextBox>
                </div>
                <br />
                <br />
                <div>
                     <asp:Button runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" CssClass="btn btn-primary col-md-12" Text="Submit" />
                    <asp:Label runat="server" ID="Label1" CssClass="text-danger"></asp:Label>
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
