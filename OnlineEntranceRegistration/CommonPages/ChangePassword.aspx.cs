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

namespace OnlineEntranceRegistration.CommonPages
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtsaveChangePass_Click(object sender, EventArgs e)
        {
            try
            {
                string[] CurrentUser = (string[])Session["currentuser"];
                string userid = CurrentUser[SessionConstant.Id];
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_UserDetailsChangePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", userid);
                cmd.Parameters.AddWithValue("@oldPassword", txtoldPassword.Text);
                cmd.Parameters.AddWithValue("@newPassword", txtnewPassword.Text);
                
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    lblMessage.Text = "Password Changed Successfully ";
                }
                else
                {
                    lblMessage.Text = "Password Not changed";
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
    }
}