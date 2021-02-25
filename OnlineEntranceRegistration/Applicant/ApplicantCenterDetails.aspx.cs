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
    public partial class ApplicantCenterDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] CurrentUser = (string[])Session["currentuser"];
                if (CurrentUser!=null )
                {
                    int userId = Convert.ToInt32(CurrentUser[SessionConstant.Id]);
                    MailService mail = new MailService();
                    checkStatus();
                    if (mail.checkUserFillExamCenterOrNot(userId))
                    {
                        Response.Redirect("AlreadyRegistredPage.aspx");
                    }
                    bindState();
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
            SqlCommand cmd = new SqlCommand("USP_GetStateByExamCenter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            ddlstate.DataValueField = "id";
            ddlstate.DataTextField = "name";
            ddlstate.DataSource = ds;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("-select-", "0"));
            //------------------
            ddlstate2.DataValueField = "id";
            ddlstate2.DataTextField = "name";
            ddlstate2.DataSource = ds;
            ddlstate2.DataBind();
            ddlstate2.Items.Insert(0, new ListItem("-select-", "0"));
            //--------------
            ddlstate3.DataValueField = "id";
            ddlstate3.DataTextField = "name";
            ddlstate3.DataSource = ds;
            ddlstate3.DataBind();
            ddlstate3.Items.Insert(0, new ListItem("-select-", "0"));
        }
        public void bindcity(int SID, int ddlno)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_getCityByExamCenter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@stateid", SID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            if (ddlno == 1)
            {
                ddlcity.DataValueField = "id";
                ddlcity.DataTextField = "name";
                ddlcity.DataSource = ds;
                ddlcity.DataBind();
                ddlcity.Items.Insert(0, new ListItem("-select-", "0"));
            }
            else if (ddlno == 2)
            {
                ddlcity2.DataValueField = "id";
                ddlcity2.DataTextField = "name";
                ddlcity2.DataSource = ds;
                ddlcity2.DataBind();
                ddlcity2.Items.Insert(0, new ListItem("-select-", "0"));
            }
            else if (ddlno == 3)
            {
                ddlcity3.DataValueField = "id";
                ddlcity3.DataTextField = "name";
                ddlcity3.DataSource = ds;
                ddlcity3.DataBind();
                ddlcity3.Items.Insert(0, new ListItem("-select-", "0"));
            }
        }
        public void bindCenterNames(int cid, int ddlno)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_getcenterBycity", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cityid", cid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            if (ddlno == 1)
            {
                ddlCenter1.DataValueField = "id";
                ddlCenter1.DataTextField = "ExamCenterName";
                ddlCenter1.DataSource = ds;
                ddlCenter1.DataBind();
                ddlCenter1.Items.Insert(0, new ListItem("-select-", "0"));
            }
            else if (ddlno == 2)
            {
                ddlcenter2.DataValueField = "id";
                ddlcenter2.DataTextField = "ExamCenterName";
                ddlcenter2.DataSource = ds;
                ddlcenter2.DataBind();
                ddlcenter2.Items.Insert(0, new ListItem("-select-", "0"));
            }
            else if (ddlno == 3)
            {
                ddlcenter3.DataValueField = "id";
                ddlcenter3.DataTextField = "ExamCenterName";
                ddlcenter3.DataSource = ds;
                ddlcenter3.DataBind();
                ddlcenter3.Items.Insert(0, new ListItem("-select-", "0"));
            }
        }
        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SID = Convert.ToInt32(ddlstate.SelectedValue);
            bindcity(SID, 1);
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string[] CurrentUser = (string[])Session["currentuser"];
                string userId = CurrentUser[SessionConstant.Id];
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_ApplicantSelectedCenter_with_AllotedCenter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@center1", ddlCenter1.SelectedValue);
                cmd.Parameters.AddWithValue("@center2", ddlcenter2.SelectedValue);
                cmd.Parameters.AddWithValue("@center3", ddlcenter3.SelectedValue);
                cmd.Parameters.AddWithValue("@paperlanguage", ddlmedium.SelectedValue);
                cmd.Parameters.AddWithValue("@status", statusConstant.Active);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Response.Redirect("uploadFiles.aspx");
                    lblMessage.Text = "Data Saved";
                }
                else
                {
                    lblMessage.Text = "Data Not saved Saved";
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

        protected void ddlcity_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CID = Convert.ToInt32(ddlcity.SelectedValue);
            bindCenterNames(CID, 1);
        }

        protected void ddlstate2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SID = Convert.ToInt32(ddlstate2.SelectedValue);
            bindcity(SID, 2);
        }

        protected void ddlstate3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SID = Convert.ToInt32(ddlstate3.SelectedValue);
            bindcity(SID, 3);
        }

        protected void ddlcity2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CID = Convert.ToInt32(ddlcity2.SelectedValue);
            bindCenterNames(CID, 2);
        }

        protected void ddlcity3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CID = Convert.ToInt32(ddlcity3.SelectedValue);
            bindCenterNames(CID, 3);
        }
    }
}