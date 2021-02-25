<%@ Page Title="" Language="C#" MasterPageFile="~/CommonPages/MasterPageCommon.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="OnlineEntranceRegistration.CommonPages.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h4 align="center" class="text-white">Change Password</h4>
        <div class="container">
            <div class="row jumbotron">
                <div id="changepasswordform" class="col-12">
                    <div id="div_id_oldPassword" class="form-group">
                        <label for="id_oldPassword" class=" requiredField">
                            Old Password<span class="asteriskField">*</span>
                        </label>
                        <div class="">
                            <asp:TextBox ID="txtoldPassword" class="textinput textInput form-control" placeholder=" Enter Password" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div id="div_id_newPassword" class="form-group">
                        <label for="id_newPassword" class=" requiredField">
                            New Password<span class="asteriskField">*</span>
                        </label>
                        <div class="">
                            <asp:TextBox ID="txtnewPassword" class="textinput textInput form-control" placeholder=" Enter New Password" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div id="div_id_ConfirmPassword" class="form-group">
                        <label for="id_ConfirmPassword" class=" requiredField">
                            Confirm Password<span class="asteriskField">*</span>
                        </label>
                        <div class="">
                            <asp:TextBox ID="txtConfirmPassword" class="textinput textInput form-control" placeholder=" Confirm New Password" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button Text="Save Changes" runat="server" class="btn-primary" ID="txtsaveChangePass" OnClick="txtsaveChangePass_Click" />
                    <div>
                        <asp:Label ID="lblMessage" runat="server" class="text-success" Text=""></asp:Label>
                    </div>
                </div>
                <div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
