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
    public partial class AdmitCard : System.Web.UI.Page
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
                    setIMages();
                    setApplicantCenterDetails();
                    setExamDate();
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
            int id =Convert.ToInt16(CurrentUser[SessionConstant.Id]);
            
            con.Open();
            SqlCommand cmd = new SqlCommand("USPGetUserPersonalDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
  
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            lblRoll.Text = ds.Rows[0]["applicationno"].ToString();
            lblname.Text = ds.Rows[0]["fname"].ToString()+" "+ ds.Rows[0]["lname"].ToString();
            lblfatherName.Text = ds.Rows[0]["fathersName"].ToString();
            lbldob.Text = ds.Rows[0]["dob"].ToString();
            int gender = Convert.ToInt32(ds.Rows[0]["gender"].ToString());
            lblgender.Text = gender == 1 ? "Male" : (gender == 2 ? "Female" : "Other");
            lbladdress.Text = ds.Rows[0]["address"].ToString() + ",\n " + ds.Rows[0]["city"].ToString() + ",\n " + ds.Rows[0]["state"].ToString();
            lblcourse.Text = ds.Rows[0]["CourseCode"].ToString();
            int cat = Convert.ToInt32(ds.Rows[0]["catagory"].ToString());
            //lblcourse.Text= ds.Rows[0]["CourseName"].ToString();
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
        }
        public void setApplicantCenterDetails()
        {
            string[] CurrentUser = (string[])Session["currentuser"];
            int id = Convert.ToInt16(CurrentUser[SessionConstant.Id]);
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_allotedCenter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            lblcenteradderss.Text = ds.Rows[0]["Cenrter"].ToString();
        }

        public void setExamDate()
        {
            string[] CurrentUser = (string[])Session["currentuser"];
            int id = Convert.ToInt16(CurrentUser[SessionConstant.Id]);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from EntranceSetting where status=1", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            lblexamdate.Text = ds.Rows[0]["ExamDate"].ToString();
        }
    }
}