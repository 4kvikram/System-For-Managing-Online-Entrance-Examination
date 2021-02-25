using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineEntranceRegistration.Static;

namespace OnlineEntranceRegistration.CommonPages
{
    public partial class RedirectByUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["currentuser"] != null && (HttpContext.Current.Session["currentuser"]).ToString() != "")
            {
                string[] CurrentUser = (string[])Session["currentuser"];
                string role = CurrentUser[SessionConstant.Role];
                if (role == RoleConstant.Admin.ToString())
                {
                    Response.Redirect("~\\Admin\\Dashboad.aspx");
                }
                else if (role == RoleConstant.Applicant.ToString())
                {
                    Response.Redirect("~\\Applicant\\ApplicantHome.aspx");
                }
            }
            else
            {
                Response.Redirect("../Index.aspx");
            }
        }
    }
}