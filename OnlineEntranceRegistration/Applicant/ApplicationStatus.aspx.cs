using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineEntranceRegistration.Static;
namespace OnlineEntranceRegistration.Applicant
{
    public partial class ApplicationStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] CurrentUser = (string[])Session["currentuser"];
            if (CurrentUser != null)
            {
                checkStatus();
            }
            else
            {
                Response.Redirect("../LoginPage.aspx");
            }

        }
        public void checkStatus()
        {
            MailService mailService = new MailService();
            int i = mailService.checkApplicationAvailableORNot();
            if (i == ApplicationStatusConstant.Application_Available)
            {
                lblmessage.InnerText = "Application is Available";
            }
            else if (i == ApplicationStatusConstant.Application_Will_Available)
            {
                lblmessage.InnerText = "Application will Available soon";
            }
            else if (i == ApplicationStatusConstant.Application_Closed)
            {
                lblmessage.InnerText = "Application Closed";
            }
        }
    }
}