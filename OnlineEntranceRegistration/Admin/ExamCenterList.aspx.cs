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
    public partial class ExamCenterList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            bindexamcenterlist();
        }
        public void bindexamcenterlist()
        {
            con.Open(); 
            SqlCommand cmd = new SqlCommand("Usp_ExamCenterGet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            grdexamcenter.DataSource = dt; 
            grdexamcenter.DataBind();
        }

        protected void grdexamcenter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdDelete"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ExamCenterDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else if (e.CommandName.Equals("cmdEdit"))
            {
                Response.Redirect("ExamCenterManage.aspx?id=" + e.CommandArgument);
            }
            bindexamcenterlist();
        }
    }
}