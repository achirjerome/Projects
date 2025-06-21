using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace DesignTemplate1
{
    public class email
    {
        public static void verify_email(string receiver_add, string activationCode)
        {
            using (MailMessage mm = new MailMessage("achirjerome@gmail.com", receiver_add))
            {
                mm.Subject = "Account Activation";
                string body = "Hello " + receiver_add + ",";
                body += "<br /><br />Please click the following link to activate your account";
                body += "<br /><a href = '" + HttpContext.Current.Request.Url.AbsoluteUri.Replace("CS.aspx", "CS_Activation.aspx?ActivationCode=" + activationCode) + "'>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    //smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("achirjerome@gmail.com", "Achir.Gbenyi1$");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }
            }
        }
    }
}