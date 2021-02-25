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
    public partial class ApplicantForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] CurrentUser = (string[])Session["currentuser"];
            if (CurrentUser != null)
            {
                int userId = Convert.ToInt32(CurrentUser[SessionConstant.Id]);

                MailService mail = new MailService();

                if (mail.checkUserFillPersnolDetailsOrNot(userId) && mail.checkUserUploadDocumentOrNot(userId) && mail.checkUserFillExamCenterOrNot(userId))
                {
                    setApplicantPersionalDetails();
                    setApplicantCenterDetails();
                    setIMages();
                }
                else
                {
                    Response.Redirect("../LoginPage.aspx");
                }
            }
            else
            {
                Response.Redirect("../LoginPage.aspx");
            }

        }
        public void setApplicantPersionalDetails()
        {
            string[] CurrentUser = (string[])Session["currentuser"];
            int id = Convert.ToInt16(CurrentUser[SessionConstant.Id]);

            con.Open();
            SqlCommand cmd = new SqlCommand("USPGetUserPersonalDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            lblApno.Text = ds.Rows[0]["applicationno"].ToString();
            lblFname.Text = ds.Rows[0]["fname"].ToString();
            lblLname.Text = ds.Rows[0]["lname"].ToString();
            lblfatherName.Text = ds.Rows[0]["fathersName"].ToString();
            lblMotherName.Text = ds.Rows[0]["mothersName"].ToString();

            lbldob.Text = ds.Rows[0]["dob"].ToString();
            int gender = Convert.ToInt32(ds.Rows[0]["gender"].ToString());
            lblgender.Text = gender == 1 ? "Male" : (gender == 2 ? "Female" : "Other");

            lbladdress.Text = ds.Rows[0]["address"].ToString() + ",\n " + ds.Rows[0]["city"].ToString() + ",\n " + ds.Rows[0]["state"].ToString();
            lblcourse.Text = ds.Rows[0]["CourseName"].ToString();
            int cat = Convert.ToInt32(ds.Rows[0]["catagory"].ToString());
            lblCategory.Text = cat == 1 ? "General" : (cat == 2 ? "OBC" : "ST/SC");
            int phy = Convert.ToInt32(ds.Rows[0]["physicallyChallanged"].ToString());
            lblphyChal.Text = phy == 1 ? "Yes" : "No";
        }
        public void setApplicantCenterDetails()
        {
            string[] CurrentUser = (string[])Session["currentuser"];
            int id = Convert.ToInt16(CurrentUser[SessionConstant.Id]);
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_GetUsercenterDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            lblfirstcenter.Text = ds.Rows[0]["Cenrter1"].ToString();
            lblsecondcenter.Text = ds.Rows[0]["Cenrter2"].ToString();
            lblthirdcenter.Text = ds.Rows[0]["Cenrter3"].ToString();

        }
        public void setIMages()
        {
            string[] CurrentUser = (string[])Session["currentuser"];
            int id = Convert.ToInt16(CurrentUser[SessionConstant.Id]);
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_getIMagesPath", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();

            imgphoto.ImageUrl = "~/uploads/Photo/" + ds.Rows[0]["photo"].ToString();
            Imgsignature.ImageUrl = "~/uploads/sign/" + ds.Rows[0]["signature"].ToString();
            //~uploads/Photo/
        }

    }
}