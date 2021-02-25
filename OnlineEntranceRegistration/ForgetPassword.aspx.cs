using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using OnlineEntranceRegistration.Static;

namespace OnlineEntranceRegistration
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {


        }


        [WebMethod(EnableSession =true)]
        public static bool SendOtp(string email)
        {
            try
            {
                Random _rdm = new Random();
                int otp = _rdm.Next(1000, 9999);
                HttpContext.Current.Session["Email"] = email;
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_UserDetailsSaveOtp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@otp", otp);
                cmd.Parameters.AddWithValue("@email", email);
                int j = cmd.ExecuteNonQuery();
                con.Close();
                if (j > 0)
                {
                    EmailModel emailModel = new EmailModel();
                    emailModel.To = email;
                    emailModel.Subject = "OTP For Recover Password";
                    emailModel.Body = "Your OTP For Recover Password is " + otp + "";
                    MailService mailService = new MailService();
                    bool i = mailService.SendEmail(emailModel);
                    return i;
                }
                else
                {
                    return false;
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
            //string st = JsonConvert.SerializeObject(data);
        }

        protected void btnForgetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                string email = Session["Email"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_UserDetailsCheckOtpAndChangePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@otp", txtotp.Text);
                cmd.Parameters.AddWithValue("@email", Session["Email"].ToString());
                cmd.Parameters.AddWithValue("@password", txtnewPassword.Text);
                int j = cmd.ExecuteNonQuery();
                con.Close();
                if(j>0)
                {
                    lblmessage.Text = "Password changed successfully";
                }
                else
                {
                    lblmessage.Text = "OTP is not Valid";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}