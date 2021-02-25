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

namespace OnlineEntranceRegistration.Admin
{
    public partial class EntranceSetting : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
                {
                    displayData();
                }
            }
        }
        public void displayData()
        {
            int id = Convert.ToInt16(Request.QueryString["id"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from EntranceSetting where id='"+id+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();      
            txtstartdate.Text = String.Format("{0:dd/MM/yyyy}" ,ds.Rows[0]["startDate"].ToString());
            //txtLastdate.Text = DateTime.ParseExact(ds.Rows[0]["endDate"].ToString(),"d", provider);
            txtadmit.Text = ds.Rows[0]["AdmitCardDate"].ToString();
            txtExamDate.Text = ds.Rows[0]["ExamDate"].ToString();
            txtResDate.Text = ds.Rows[0]["resultDate"].ToString();
            txtnotification.Text = ds.Rows[0]["notification"].ToString();
            txtnotice.Text = ds.Rows[0]["notice"].ToString();
            btnsave.Text = "Update";
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnsave.Text == "Submit")
                {
                    con.Open();
                    //(@startDate,@endDate,@notification,@notice,@status,GETDATE())
                    //AdmitCardDate,ExamDate,resultDate
                    SqlCommand cmd = new SqlCommand("USP_EntranceSetting_ADD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@startDate", txtstartdate.Text);
                    cmd.Parameters.AddWithValue("@endDate", txtLastdate.Text);
                    cmd.Parameters.AddWithValue("@AdmitCardDate", txtadmit.Text);
                    cmd.Parameters.AddWithValue("@ExamDate", txtExamDate.Text);
                    cmd.Parameters.AddWithValue("@resultDate", txtResDate.Text);
                    cmd.Parameters.AddWithValue("@notification", txtnotification.Text);
                    cmd.Parameters.AddWithValue("@notice", txtnotice.Text);
                    cmd.Parameters.AddWithValue("@status", statusConstant.Active);
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        lblMessage.Text = "Data Save";
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
                    //(@startDate,@endDate,@notification,@notice,@status,GETDATE())
                    //AdmitCardDate,ExamDate,resultDate
                    SqlCommand cmd = new SqlCommand("USP_EntranceSetting_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
                    cmd.Parameters.AddWithValue("@startDate", txtstartdate.Text);
                    cmd.Parameters.AddWithValue("@endDate", txtLastdate.Text);
                    cmd.Parameters.AddWithValue("@AdmitCardDate", txtadmit.Text);
                    cmd.Parameters.AddWithValue("@ExamDate", txtExamDate.Text);
                    cmd.Parameters.AddWithValue("@resultDate", txtResDate.Text);
                    cmd.Parameters.AddWithValue("@notification", txtnotification.Text);
                    cmd.Parameters.AddWithValue("@notice", txtnotice.Text);
                    cmd.Parameters.AddWithValue("@status", statusConstant.Active);
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        lblMessage.Text = "Data Updated";
                    }
                    else
                    {
                        lblMessage.Text = "Data Not Updated";
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }
    }
}