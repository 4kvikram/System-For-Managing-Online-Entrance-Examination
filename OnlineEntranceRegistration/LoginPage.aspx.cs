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
    public partial class LoginPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //MailService mailService = new MailService();
            //mailService.checkApplicationAvailableORNot();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Usp_userDetails_login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", loginemail.Text);
                cmd.Parameters.AddWithValue("@password", loginpwd.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    string id = dt.Rows[0]["id"].ToString();
                    string name = dt.Rows[0]["fname"].ToString() + " " + dt.Rows[0]["lname"].ToString();
                    string email = dt.Rows[0]["email"].ToString();
                    string role = dt.Rows[0]["role"].ToString();
                    string[] currentuser = new string[4];
                    currentuser[SessionConstant.Id] = id;
                    currentuser[SessionConstant.Name] = name;
                    currentuser[SessionConstant.Email] = email;
                    currentuser[SessionConstant.Role] = role;

                    Session["currentuser"] = currentuser;
                    if (dt.Rows[0]["role"].ToString() == RoleConstant.Admin.ToString())
                    {
                        Response.Redirect("~\\Admin\\Dashboad.aspx");
                    }
                    else if(dt.Rows[0]["role"].ToString() == RoleConstant.Applicant.ToString())
                    {
                        Response.Redirect("Applicant/ApplicantHome.aspx");
                    }
                }
                else
                {
                    txtmessage.Text = "Invalid Input";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}