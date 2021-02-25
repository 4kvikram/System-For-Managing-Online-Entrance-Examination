<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="OnlineEntranceRegistration.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Modal login -->
    <div>
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header bg-info">
                    <h5 class="modal-title" id="">LogIn</h5>
                </div>
                <form id="loginform" class="jumbotron">
                    <div class="modal-body">
                        <form method="post" action="/action_page.php">
                            <div class="form-group">
                                <label for="loginemail">Email address:</label>
                                <asp:TextBox ID="loginemail" class="form-control" placeholder="Enter Email " runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="loginpwd">Password:</label>
                                <asp:TextBox ID="loginpwd" class="form-control" placeholder=" Enter Password" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group form-check">
                                <label class="form-check-label">
                                    <input class="form-check-input" type="checkbox">
                                    Remember me
                                </label>
                            </div>
                            <div class="form-group form-check">
                                <label class="form-check-label">
                                    <a href="SignupPage.aspx" class="text-success">Not Registred !  Signup Now </a>
                                </label>
                                <br />
                                <label class="form-check-label">
                                    <a href="ForgetPassword.aspx">Forget Password</a>
                                </label>
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <asp:Label ID="txtmessage" runat="server" CssClass="text-danger"></asp:Label>
                        <asp:Button runat="server" OnClick="Button1_Click" OnClientClick="return loginvalidateForm()" ID="Button1" Text="Login" class="btn btn-primary" />
                    </div>
                </form>
            </div>
        </div>
    </div>

    <!--end Models -->
    <script src="Static/jquery-3.1.0.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            console.log("ready master page!");
        });

        function loginvalidateForm() {
            var email = document.getElementById('<%=loginemail.ClientID%>').value;
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

            var loginpwd = document.getElementById('<%=loginpwd.ClientID%>').value;
            
            if (loginpwd == "") {
                alert("Password cannot be empty");
                return false;
            }
            return true;
        }

        function check() {
            var v = document.getElementById('<%=loginemail.ClientID%>').value;
            console.log(v);
            return false;
        }

    </script>
    <!--end Models -->
</asp:Content>
