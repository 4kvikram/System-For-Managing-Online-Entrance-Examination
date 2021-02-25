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

namespace OnlineEntranceRegistration.Applicant
{
    public partial class ApplicantPersnolDetails : System.Web.UI.Page
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
                    if (mail.checkUserFillPersnolDetailsOrNot(userId))
                    {
                        Response.Redirect("AlreadyRegistredPage.aspx");
                    }
                    bindState();
                    bindCourse();
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
        public void bindState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from states", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            ddlstate.DataValueField = "id";
            ddlstate.DataTextField = "name";
            ddlstate.DataSource = ds;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("-select-", "0"));
        }

        public void bindcity()
        {
            int SID = Convert.ToInt32(ddlstate.SelectedValue);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from cities where state_id='" + SID + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            ddlcity.DataValueField = "id";
            ddlcity.DataTextField = "name";
            ddlcity.DataSource = ds;
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, new ListItem("-select-", "0"));
        }
        public void bindCourse()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select id,name+'('+code+')' name from courseDetails where status=1", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            ddlcourse.DataValueField = "id";
            ddlcourse.DataTextField = "name";
            ddlcourse.DataSource = ds;
            ddlcourse.DataBind();
            ddlcourse.Items.Insert(0, new ListItem("-select-", "0"));
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindcity();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                MailService mail = new MailService();
                string[] CurrentUser = (string[])Session["currentuser"];
                string userId = CurrentUser[SessionConstant.Id];
                con.Open();

                //values(@applicationno,@fname,@lname,@UserID,@mothersName,@fathersName,
                //@dob,@gender,@courseApplyfor,@physicallyChallanged,@catagory,@address,@state,@city,@status)
                SqlCommand cmd = new SqlCommand("USP_ApplicantPersionalDetails_Add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@applicationno", mail.GenetateApplicationNO());
                cmd.Parameters.AddWithValue("@fname", txtfname.Text);
                cmd.Parameters.AddWithValue("@lname", txtlname.Text);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@mothersName", txtmothersname.Text);
                cmd.Parameters.AddWithValue("@fathersName", txtfatherName.Text);
                cmd.Parameters.AddWithValue("@dob", txtdob.Text);
                cmd.Parameters.AddWithValue("@gender", rdoGender.SelectedValue);
                cmd.Parameters.AddWithValue("@courseApplyfor", 1);
                cmd.Parameters.AddWithValue("@physicallyChallanged", rdbphys.SelectedValue);
                cmd.Parameters.AddWithValue("@catagory", ddlcatagory.SelectedValue);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
                cmd.Parameters.AddWithValue("@status", statusConstant.Active);

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    lblMessage.Text = "Data Saved";
                    Response.Redirect("ApplicantCenterDetails.aspx");
                }
                else
                {
                    lblMessage.Text = "Data Not saved ";
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