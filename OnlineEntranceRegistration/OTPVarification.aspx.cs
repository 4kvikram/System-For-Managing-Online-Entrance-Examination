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
    public partial class OTPVarification : System.Web.UI.Page
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void checkOtpValidOrNot()
        {
            
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (Session["email"].ToString() != "")
            {
                string email = Session["email"].ToString();
                
                int otp = Convert.ToInt32(txtotp.Text);
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_UserDetails_CheckOtp_For_signup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@otp", otp);
                cmd.Parameters.AddWithValue("@email", Session["Email"].ToString());
                cmd.Parameters.AddWithValue("@status",statusConstant.Active);
                int j = cmd.ExecuteNonQuery();
                con.Close();
                if (j > 0)
                {
                    Session["email"] = "";
                    lblMessage.Text = "signUp successfull";
                    Response.Redirect("LoginPage.aspx");
                }
                else
                {
                    lblMessage.Text = "OTP is not Valid";
                }

            }
        }
    }
}