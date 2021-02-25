<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplicantForm.aspx.cs" Inherits="OnlineEntranceRegistration.CommonPages.ApplicantForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Application form</title>
    <style type="text/css">
        td {
            padding: 10px;
        }

        table {
            margin-left: auto;
            margin-right: auto;
            
            width: 100%;
        }
    </style>

</head>
<body>

    <div class="container-fluid " style="border: 4px solid; min-height:1000px">
        <div>
            <table>
                <tr>
                     <td><b>Application No. :</b><asp:Label runat="server" ID="lblApno"></asp:Label></td>
                    <td>
                        
                    </td>
                  
                </tr>
            </table>
        </div>
        <div>
        <h3 align="center" class="text-white">Applicant Personal Details</h3>
            <table border="1">
                <tr>
                    <td><b>First Name :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblFname"></asp:Label>
                    </td>
                    <td><b>Last Name :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblLname"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><b>Father's Name :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblfatherName"></asp:Label>
                    </td>
                    <td><b>Mother's Name :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblMotherName"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><b>DOB :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lbldob"></asp:Label>
                    </td>

                    <td><b>Gender</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblgender"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><b>Address :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lbladdress"></asp:Label>
                    </td>
                    <td><b>Course Applyed For :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblcourse"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><b>Physically Challanged :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblphyChal"></asp:Label>
                    </td>
                    <td><b>Category :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblCategory"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <h3 align="center">Center Details </h3>
            <table border="1">
                <tr>
                    <td><b>First Selected Center :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblfirstcenter"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><b>Second Selected Center :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblsecondcenter"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><b>Third Selected Center :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblthirdcenter"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <h3 align="center">Images Uploaded by Candidate     </h3>
            <table>
                <tr>
                    <td><b>Photo </b></td>
                    <td>
                        <b>Signature </b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image runat="server" ImageUrl="../StaticImages/pro.jpg" ID="imgphoto" Height="120px" Width="100px" />
                    </td>
                    <td>
                        <asp:Image runat="server" ImageUrl="../StaticImages/pro.jpg" ID="Imgsignature" Height="120px" Width="100px" />
                    </td>
                </tr>
            </table>

        </div>
        <button margin="center" onclick="window.print()">Print</button>
    </div>


</body>
</html>


