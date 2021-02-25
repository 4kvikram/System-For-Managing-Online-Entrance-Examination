using OnlineEntranceRegistration.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineEntranceRegistration.Applicant
{
    public partial class AdmitCardCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            string[] CurrentUser = (string[])Session["currentuser"];
            if (CurrentUser != null)
            {
                string userId = CurrentUser[SessionConstant.Id];
            }
            else
            {
                Response.Redirect("../LoginPage.aspx");
            }

        }
    }
}