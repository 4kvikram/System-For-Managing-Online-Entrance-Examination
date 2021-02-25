using OnlineEntranceRegistration.Static;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineEntranceRegistration
{
    public partial class SignupPage : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        public void signUp()
        {
            try
            {
                MailService mailService = new MailService();
                int otp = mailService.GenerateOtp();
                con.Open();
                TextBox firstName = (TextBox)Master.FindControl("signupFirstName");
                //values(@fname,@lname,@email,@phone,@password,@role,@otp,@status,GETDATE())
                SqlCommand cmd = new SqlCommand("Usp_signIn", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fname", signupFirstName.Text);
                cmd.Parameters.AddWithValue("@lname", signupLastName.Text);
                cmd.Parameters.AddWithValue("@email", signupemail.Text);
                cmd.Parameters.AddWithValue("@phone", signupphone.Text);
                cmd.Parameters.AddWithValue("@password", signupPwd.Text);
                cmd.Parameters.AddWithValue("@role", RoleConstant.Applicant);
                cmd.Parameters.AddWithValue("@otp", otp);
                cmd.Parameters.AddWithValue("@status", statusConstant.DeActive);

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    EmailModel emailModel = new EmailModel();
                    emailModel.To = signupemail.Text;
                    emailModel.Subject = "OTP for Sign Up";
                    emailModel.Body = "Your OTP For Sign up  is "  + otp + "";
                    MailService mail = new MailService();
                    bool flag = mail.SendEmail(emailModel);
                    if(flag)
                    {
                        Session["email"] = signupemail.Text;
                        Response.Redirect("OTPVarification.aspx");
                    }
                    else
                    {
                        lblmessage.Text = "Email is not Correct";
                    }
                }
                else
                {
                    lblmessage.Text = "Something Went Worng";
                }

                con.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void Unnamed_Click(object sender, EventArgs e)
        {

           
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_UserDetails_emailExistOrNot", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", signupemail.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    lblmessage.Text = "Email Exist";
                }
                else
                {
                    signUp();
                    lblmessage.Text = "Email not exist";
                }

                con.Close();
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

        protected void btnsubmit_Click(object sender, EventArgs e)
        {

        }
    }
}