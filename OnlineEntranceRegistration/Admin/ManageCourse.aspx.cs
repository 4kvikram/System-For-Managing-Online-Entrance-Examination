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
    public partial class ManageCourse : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            bindGrid();
        }
        public void bindGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from courseDetails where status=1", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            
            sda.Fill(dt);
            con.Close();
            grdCourse.DataSource = dt;
            grdCourse.DataBind();

        }
        protected void grdexamcenter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdDelete"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_course_delByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                cmd.Parameters.AddWithValue("@status", statusConstant.Delete);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            else if (e.CommandName.Equals("cmdEdit"))
            {
                Response.Redirect("AddCourse.aspx?id=" + e.CommandArgument);
            }
            bindGrid();
        }
    }
}