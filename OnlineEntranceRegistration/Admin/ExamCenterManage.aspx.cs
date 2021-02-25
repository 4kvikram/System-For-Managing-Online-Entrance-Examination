using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineEntranceRegistration.Admin
{
    public partial class ExamCenterManage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindState();
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
                {
                    displayData();
                }
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

        protected void displayData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_ExamCenterGetById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            txtexamcentername.Text = ds.Rows[0]["ExamCenterName"].ToString();
            txtincharge.Text = ds.Rows[0]["Incharge"].ToString();
            txtaddress.Text = ds.Rows[0]["address"].ToString();
            txtseat.Text = ds.Rows[0]["noOfSeats"].ToString();
            txtCenterCode.Text = ds.Rows[0]["centerCode"].ToString();
            ddlstate.SelectedValue = ds.Rows[0]["state"].ToString();
            bindcity();
            ddlcity.SelectedValue = ds.Rows[0]["city"].ToString();

            btnsave.Text = "Update";

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnsave.Text == "Submit")
                {
                    con.Open();
                    //@ExamCenterName,@Incharge,@state,@city,@address,@noOfSeats
                    SqlCommand cmd = new SqlCommand("Usp_examCenter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ExamCenterName", txtexamcentername.Text);
                    cmd.Parameters.AddWithValue("@Incharge", txtincharge.Text);
                    cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                    cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
                    cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                    cmd.Parameters.AddWithValue("@noOfSeats", txtseat.Text);
                    cmd.Parameters.AddWithValue("@centerCode", txtCenterCode.Text);
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
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
                    con.Open();
                    
                    SqlCommand cmd = new SqlCommand("Usp_examCenterUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
                    cmd.Parameters.AddWithValue("@ExamCenterName", txtexamcentername.Text);
                    cmd.Parameters.AddWithValue("@Incharge", txtincharge.Text);
                    cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                    cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
                    cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                    cmd.Parameters.AddWithValue("@noOfSeats", txtseat.Text);
                    cmd.Parameters.AddWithValue("@centerCode", txtCenterCode.Text);
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        lblMessage.Text = "Data Updated";
                    }
                    else
                    {
                        lblMessage.Text = "Data Not saved Saved";
                    }

                    con.Close();
                }
                Response.Redirect("ExamCenterList.aspx");
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }

        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindcity();
        }
    }
}