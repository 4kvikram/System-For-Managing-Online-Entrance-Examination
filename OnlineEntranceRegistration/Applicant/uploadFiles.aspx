<%@ Page Title="" Language="C#" MasterPageFile="~/Applicant/MasterPageApplicant.Master" AutoEventWireup="true" CodeBehind="uploadFiles.aspx.cs" Inherits="OnlineEntranceRegistration.Applicant.uploadFiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin: 12px;">
        <div class="col-md-12 sub-head">
            <h4 align="center">Upload Documents  </h4>
        </div>
        <div class="col-md-12 jumbotron">
            <div class="form-group col-md-12">
                <label for="" class="">Upload Photo  </label>
                <asp:FileUpload CssClass="form-control" ID="FileUploadPhoto" runat="server" />
            </div>
             <div class="form-group col-md-12">
                <label for="" class="">Upload Signature  </label>
                <asp:FileUpload CssClass="form-control" ID="FileUploadsign" runat="server" />
            </div>
             <div class="form-group col-md-12">
                <label for="" class="">Upload ID   </label>
                <asp:FileUpload CssClass="form-control" ID="FileUploadID" runat="server" />
            </div>
            <div>
                <asp:Button ID="btnUpload" runat="server" CssClass="col-md-12 btn btn-primary" Text="Upload" OnClick="Upload" />
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
