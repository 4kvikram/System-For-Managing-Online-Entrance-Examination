using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace OnlineEntranceRegistration.Static
{
    public class MailService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);
        public int GenerateOtp()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
        public bool SendEmail(EmailModel email)
        {
            try
            {
                string PortNo = ConfigurationManager.AppSettings["SmtpPort"];
                string FromEmail = ConfigurationManager.AppSettings["FromEmail"];
                string FromPass = ConfigurationManager.AppSettings["Password"];
                string Host = ConfigurationManager.AppSettings["SmtpHost"];
                email.BCC = ConfigurationManager.AppSettings["EmailBCC"];
                bool flag = true;
                using (MailMessage mm = new MailMessage(FromEmail, email.To, email.Subject, email.Body))
                {
                    if (!string.IsNullOrEmpty(email.CC))
                    {
                        mm.CC.Add(email.CC);
                    }
                    if (!string.IsNullOrEmpty(email.BCC))
                    {
                        mm.Bcc.Add(email.BCC);
                    }
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = Host;
                    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                    NetworkCredential NetworkCred = new NetworkCredential(FromEmail, FromPass);
                    smtp.Credentials = NetworkCred;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Port = Convert.ToInt32(PortNo);
                    smtp.Send(mm);
                    return flag;
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }
        }
        public string GenetateApplicationNO()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_GetLastApplication", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                string application = Convert.ToString(Convert.ToInt64(dt.Rows[0]["number"].ToString()) + 1);
                return application;
            }
            else
            {
                return "100000000000";
            }
        }
        public bool checkUserFillPersnolDetailsOrNot(int id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_CheckApplicantpersnol_Detils", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", id);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkUserFillExamCenterOrNot(int id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_CheckApplicantCenter_Detils", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", id);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkUserUploadDocumentOrNot(int id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_CheckApplicantDocument_Detils", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", id);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public int checkApplicationAvailableORNot()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_checkApplicationDAte", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter returnValueParam = cmd.Parameters.Add("@return_value", SqlDbType.Int);
            returnValueParam.Direction = ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            int returnValue = (int)returnValueParam.Value;
            con.Close();
            return returnValue;
        }
    }
}