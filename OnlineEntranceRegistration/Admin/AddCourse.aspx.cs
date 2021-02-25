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
    public partial class AddCourse : System.Web.UI.Page
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
        protected void displayData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_course_getByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
            cmd.Parameters.AddWithValue("@status", statusConstant.Active);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            txtcourseName.Text = ds.Rows[0]["name"].ToString();
            txtCourseCode.Text = ds.Rows[0]["code"].ToString();
            txtCourseDuration.Text = ds.Rows[0]["duration"].ToString();
            txtseat.Text = ds.Rows[0]["seat"].ToString();
            txtcoursedetails.Text = ds.Rows[0]["details"].ToString();
            btnsave.Text = "Update";
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnsave.Text == "Save")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("USP_Course_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", txtcourseName.Text);
                    cmd.Parameters.AddWithValue("@code", txtCourseCode.Text);
                    cmd.Parameters.AddWithValue("@duration", txtCourseDuration.Text);
                    cmd.Parameters.AddWithValue("@seat", txtseat.Text);
                    cmd.Parameters.AddWithValue("@details", txtcoursedetails.Text);
                    cmd.Parameters.AddWithValue("@status", statusConstant.Active);
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Response.Redirect("ManageCourse.aspx");
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
                    SqlCommand cmd = new SqlCommand("USP_Course_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
                    cmd.Parameters.AddWithValue("@name", txtcourseName.Text);
                    cmd.Parameters.AddWithValue("@code", txtCourseCode.Text);
                    cmd.Parameters.AddWithValue("@duration", txtCourseDuration.Text);
                    cmd.Parameters.AddWithValue("@seat", txtseat.Text);
                    cmd.Parameters.AddWithValue("@details", txtcoursedetails.Text);
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        lblMessage.Text = "Data Updated";
                        Response.Redirect("ManageCourse.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Data Not Update ";
                    }

                    con.Close();
                }
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}