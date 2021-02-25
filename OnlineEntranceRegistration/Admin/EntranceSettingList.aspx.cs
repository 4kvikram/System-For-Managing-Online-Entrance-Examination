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
    public partial class EntranceSettingList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindentranceSetting();
            }
        }
        public void bindentranceSetting()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from EntranceSetting", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //DataSet ds = new DataSet();
            sda.Fill(dt);
            con.Close();
            grdsetting.DataSource = dt; // to show the data to page
            grdsetting.DataBind();

        }
        protected void grdsetting_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdDelete"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_EntranceSetting_del", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            else if (e.CommandName.Equals("cmdEdit"))
            {
                Response.Redirect("EntranceSetting.aspx?id=" + e.CommandArgument);
            }
            bindentranceSetting();
        }
    }

}