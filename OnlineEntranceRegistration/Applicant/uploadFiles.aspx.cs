using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using OnlineEntranceRegistration.Static;
using System.Data;

namespace OnlineEntranceRegistration.Applicant
{
    public partial class uploadFiles : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] CurrentUser = (string[])Session["currentuser"];
                if (CurrentUser != null)
                {
                    checkStatus();
                    int userId = Convert.ToInt32(CurrentUser[SessionConstant.Id]);
                    MailService mail = new MailService();
                    if (mail.checkUserUploadDocumentOrNot(userId))
                    {
                        Response.Redirect("AlreadyRegistredPage.aspx");
                    }
                }
                else
                {
                    Response.Redirect("../LoginPage.aspx");
                }
            }
        }
        public void checkStatus()
        {
            MailService mailService = new MailService();
            int i = mailService.checkApplicationAvailableORNot();
            if (i == ApplicationStatusConstant.Application_Will_Available)
            {
                Response.Redirect("ApplicationStatus.aspx");
            }
            else if (i == ApplicationStatusConstant.Application_Closed)
            {
                Response.Redirect("ApplicationStatus.aspx");
            }
        }
        protected void Upload(object sender, EventArgs e)
        {
            try
            {
                if (FileUploadPhoto.HasFile && FileUploadsign.HasFile && FileUploadID.HasFile)
                {
                    string fileName = Path.GetFileName(FileUploadPhoto.PostedFile.FileName);
                    string NamewithoutExt = new String(Path.GetFileNameWithoutExtension(fileName).Take(10).ToArray()).Replace(" ", "-");
                    string finalName = NamewithoutExt + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(fileName);
                    FileUploadPhoto.PostedFile.SaveAs(Server.MapPath("~/uploads/Photo/") + finalName);
                    string imagePath = "/uploads/Photo/" + finalName;
                    //--------------------------------------------------------------
                    string signName = Path.GetFileName(FileUploadsign.PostedFile.FileName);
                    string signNamewithoutExt = new String(Path.GetFileNameWithoutExtension(signName).Take(10).ToArray()).Replace(" ", "-");
                    string finalSignName = signNamewithoutExt + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(signName);
                    FileUploadsign.PostedFile.SaveAs(Server.MapPath("~/uploads/sign/") + finalSignName);
                    string signPath = "/uploads/sign/" + finalSignName;
                    //----------------------------------------------------------------
                    string docName = Path.GetFileName(FileUploadID.PostedFile.FileName);
                    string docNamewithoutExt = new String(Path.GetFileNameWithoutExtension(docName).Take(10).ToArray()).Replace(" ", "-");
                    string finalDocName = docNamewithoutExt + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(docName);
                    FileUploadID.PostedFile.SaveAs(Server.MapPath("~/uploads/document/") + finalDocName);
                    string docPath = "/uploads/document/" + finalDocName;
                    //--------------------------------------------------------------------
                    string[] CurrentUser = (string[])Session["currentuser"];
                    string userId = CurrentUser[SessionConstant.Id];
                    con.Open();
                    SqlCommand cmd = new SqlCommand("USP_ApplicantDocuments_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@photo", finalName);
                    cmd.Parameters.AddWithValue("@signature", finalSignName);
                    cmd.Parameters.AddWithValue("@IdProff", finalDocName);
                    cmd.Parameters.AddWithValue("@status", statusConstant.Active);
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Response.Redirect("../CommonPages/ApplicantForm.aspx");
                        lblMessage.Text = "Data Saved";
                    }
                    else
                    {
                        lblMessage.Text = "Data Not saved Saved";
                    }
                    con.Close();
                }
                else
                {
                    lblMessage.Text = "Please upload All documents";
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}