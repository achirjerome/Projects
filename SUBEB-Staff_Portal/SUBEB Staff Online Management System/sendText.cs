using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

namespace SUBEB_Staff_Online_Management_System
{
    public class sendText
    {
        public void sendSMS(string phoneNo, string message)
        {
            try
            {

                if (!(string.IsNullOrEmpty(phoneNo)))
                {
                    string APIurl = "https://netbulksms.com/index.php?option=com_spc&comm=spc_api&username=achirjerome&password=Achir.Gbenyi1$&sender=SUBEB&recipient=" + phoneNo + "&message=" + message;
                    // Create a request object  
                    WebRequest request = HttpWebRequest.Create(APIurl);
                    // Get the response back  
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream s = (Stream)response.GetResponseStream();
                    StreamReader readStream = new StreamReader(s);
                    string dataString = readStream.ReadToEnd();
                    string reply = response.StatusCode.ToString();
                    response.Close();
                    s.Close();
                    readStream.Close();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}