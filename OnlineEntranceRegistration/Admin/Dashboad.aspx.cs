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
    public partial class Dashboad : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            getAllTableDetais();
        }

        public void getAllTableDetais()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("getAllTableDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            lblTotalCenter.Text = ds.Rows[0]["TotalExamCenter"].ToString();
            lblActiveCenter.Text = ds.Rows[0]["ActiveExamCenter"].ToString();
            lblDeactiveCenter.Text = ds.Rows[0]["DeactiveExamCenter"].ToString();

            lbltotalcourse.Text = ds.Rows[0]["TotalCourseCenter"].ToString();
            lblactiveCourse.Text = ds.Rows[0]["ActiveCourseCenter"].ToString();
            lblDactiveCourse.Text = ds.Rows[0]["DeactiveCourseCenter"].ToString();

            lblapplicant.Text = ds.Rows[0]["TotalApplicant"].ToString();
        }
    }
}