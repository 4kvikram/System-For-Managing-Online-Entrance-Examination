using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineEntranceRegistration.Static;

namespace OnlineEntranceRegistration
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(enableSession: true)]
        public string isLogin()
        {
            
            return "lobin";
        }

       

       

       
    }
}