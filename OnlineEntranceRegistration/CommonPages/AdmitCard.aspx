<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdmitCard.aspx.cs" Inherits="OnlineEntranceRegistration.CommonPages.AdmitCard" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admit Card</title>
    <style type="text/css">
        td {
            padding: 2px;
        }

        table {
            margin-left: auto;
            margin-right: auto;
            width: 100%;
        }
    </style>

</head>
<body>

    <div class="container-fluid " style="border: 4px solid; min-height: 950px">
        <div>
            <table class="tbl1">
                <tr>
                    <td align="center"><b>Entrance Name </b></td>
                    <td></td>
                </tr>
            </table>
        </div>
        <div>
            <h3 align="center" class="text-white">Applicant Personal Details</h3>
            <table border="0">
                <tr>
                    <td><b>Roll No. :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblRoll"></asp:Label>
                    </td>
                    <td rowspan="4" style="">
                        <asp:Image runat="server" ImageUrl="../StaticImages/pro.jpg" ID="imgphoto" Height="120px" Width="100px" Style="float: right;" />
                    </td>
                </tr>
                <tr>
                    <td><b>Name :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblname" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><b>Father's Name :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblfatherName"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><b>DOB :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lbldob"></asp:Label>
                    </td>
                </tr>
                <tr>
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
                </tr>
            </table>
        </div>
        <div>
            <h3 align="center">Center Details </h3>
            <table border="1">
                <tr>
                    <td><b>Center Code :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblcentercode">8769D</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><b>Course Code :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblcourse"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><b>Center Address :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblcenteradderss"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><b>Reporting Time at Centre :</b></td>
                    <td>9:00 AM</td>
                </tr>
                <tr>
                    <td><b>Gate Closing Time of Centre:</b></td>
                    <td>10:00 AM</td>
                </tr>
                <tr>
                    <td><b>Date of Examination  :</b></td>
                    <td>
                        <asp:Label runat="server" ID="lblexamdate"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <h3 align="center">IMPORTANT INSTRUCTIONS FOR CANDIDATES     </h3>
            <h6>1. The Admit Card is provisional, subject to the eligibility conditions given in the Information Bulletin</h6>
            <h6>2. Candidates are suggested to visit the examination venue, a day in advance, so that they can reach the venue on time on the day of examination</h6>
            <h6>3.  Candidates are NOT allowed to carry any personal belongings including electronic devices, mobile phone and other materials listed in the Information
Bulletin, to the Examination Centre. Examination Officials will not be responsible for safe keep of personal belongings.
Pen/ Pencil and blank paper sheets for rough work will be provided in the examination Hall/Room. Candidates must write their name and
Roll Number at the top of the sheet, and must return the sheet to the Invigilator, before leaving the examination Hall/Room</h6>
            <h6>4.  Candidates should take their seat immediately after opening of the Examination Hall. They can login and read instructions, before the
commencement of the examination</h6>
            <h6>5.  Candidates will NOT be permitted to leave the Examination Room/Hall before the end of examination. After the completion of the
examination, candidates should hand over their Admit Card, rough sheet and Pen/Pencil to the invigilator on duty.</h6>
            <h6>6.  Candidates must enter required details in the Attendance Sheet in legible handwriting, put their signature and paste the Photograph at the
appropriate place. They should ensure that their Left-Hand Thumb Impression is clear and not smudged.</h6>
            <h5 align="center">Candidates are advised to check updates on  website regularly. They may also check their mailbox on the registered-mail address and
SMS in their registered Mobile No. for latest updates and information</h5>
        </div>
        <button margin="center" onclick="window.print()">Print</button>
    </div>
</body>
</html>


