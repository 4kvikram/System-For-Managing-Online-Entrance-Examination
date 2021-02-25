<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SignupPage.aspx.cs" Inherits="OnlineEntranceRegistration.SignupPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="Static/jquery-3.1.0.min.js"></script>
    <script>
        $(document).ready(function () {
            console.log("ready master page!");
        });
        function checkPassword() {
            pwd = document.getElementById('<%=signupPwd.ClientID%>').value;
            cpwd = document.getElementById('<%=signupConfPwd.ClientID%>').value;
            if (pwd==cpwd) {
                return true;
            }
            else {
                return false;
            }
        }
        function signupvalidateForm() {
            var fname = document.getElementById('<%=signupFirstName.ClientID%>').value; 
            if (fname == "") {
                alert("First name cannot be empty");
                return false;
            }
            var lname = document.getElementById('<%=signupLastName.ClientID%>').value; 
            if (lname == "") {
                alert("Last name cannot be empty");
                return false;
            }

            var email = document.getElementById('<%=signupemail.ClientID%>').value;
            if (email == "") {
                alert("Email cannot be empty");
                return false;
            } else {
                var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                if (!re.test(email)) {
                    alert("Email format invalid");
                    return false;
                }
            }
            var Phone = document.getElementById('<%=signupphone.ClientID%>').value;
            if (Phone == "") {
                alert("Phone cannot be empty");
                return false;
            }
            else {
                var reg = /^\d+$/;
                if (!reg.test(Phone)) {
                    alert("Phone no. invalid");
                    return false;
                }
            }
            var signupPwd = document.getElementById('<%=signupPwd.ClientID%>').value;
            if (signupPwd == "") {
                alert("Password cannot be empty");
                return false;
            }
            var signupConfPwd = document.getElementById('<%=signupConfPwd.ClientID%>').value;
            if (signupConfPwd == "") {
                alert("Confirm Password cannot be empty");
                return false;
            }
            else {
                if (!checkPassword()) {
                    alert("Password and Confirm Password did not match !!!")
                    return false;
                }
            }
            return true;
        }
        function check() {
            return true;
        }
    </script>
    <!--end Models -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
      <div >
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                   <div class="modal-header bg-info">
                    <h5 class="modal-title" id="">SignUp</h5>
                </div>
                    <div class="modal-body">                        
                        <div class="row justify-content-center">
                            <div class="col-6">
                                <label for="signupFirstName">First Name:</label>
                                <asp:TextBox ID="signupFirstName" class="form-control" placeholder=" Enter First Name " runat="server"></asp:TextBox>
                            </div>
                            <div class="col-6">
                                <label for="signupLastName">Last Name:</label>
                                <asp:TextBox ID="signupLastName" class="form-control" placeholder=" Enter Last Name " runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="signupemail">Email address:</label>
                            <asp:TextBox ID="signupemail" class="form-control" placeholder="Email " runat="server"></asp:TextBox>
                            <small id="signupEmailValidation" class="text-danger"></small>
                        </div>
                        <div class="form-group">
                            <label for="signupphone">Mobile:</label>
                            <asp:TextBox ID="signupphone" class="form-control" placeholder=" Enter Mobile " runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="signupPwd">Password:</label>
                            <asp:TextBox ID="signupPwd" class="form-control" placeholder=" Enter Password" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="signupPwd">Confirm Password:</label>
                            <asp:TextBox ID="signupConfPwd" class="form-control" placeholder=" Confirm Password" TextMode="Password" runat="server"></asp:TextBox>
                            <small id="signupPwdValidation" class="text-danger"></small>
                        </div>
                        <asp:Button Text="Sign In"  runat="server" OnClick="Unnamed_Click" CssClass="btn btn-primary" ID="signupSubmitButton" OnClientClick="return signupvalidateForm()" /> 
                       <asp:Label runat="server" ID="lblmessage" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
