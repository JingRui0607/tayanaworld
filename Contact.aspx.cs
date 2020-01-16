using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

using System;
using System.Data;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TayanaProject
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            select();
        }

        


        public void select()
        {
            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection Connection = new SqlConnection(config);

            //國家
            SqlCommand command1 = new SqlCommand("select DISTINCT name from Country", Connection);
            SqlDataAdapter loginAdapter1 = new SqlDataAdapter(command1);
            DataTable username = new DataTable();

            loginAdapter1.Fill(username);
            selectCountry.DataSource = username;
            selectCountry.DataValueField = "name";
            selectCountry.DataTextField = "name";

            selectCountry.DataBind();



            //產品

            SqlCommand command2 = new SqlCommand("select DISTINCT YachtsType from YachtsType", Connection);
            SqlDataAdapter loginAdapter2 = new SqlDataAdapter(command2);
            DataTable username2 = new DataTable();

            loginAdapter2.Fill(username2);

            selectYachts.DataSource = username2;
            selectYachts.DataValueField = "YachtsType";
            selectYachts.DataTextField = "YachtsType";

            selectYachts.DataBind();



        }
        public void sendGMail()
        {
            sendMail mail = new sendMail();
            mail.fromAddress = "phrost0428123@gmail.com";
            mail.toAddress = "phrost0428123@gmail.com";
            mail.Subject = "客戶"+ textfieldname.Value + DateTime.Now.ToString("yyyy/MM/dd");
            mail.MailBody = "姓名:" + textfieldname.Value + "<br>" + "Email:" + textfieldEmail.Value + "<br>" + "Phone:" + textfieldphone.Value + "<br>" + "Country:" + selectCountry.Value+ "<br>" + "Yachts:"+selectYachts.Value + "<br>"+"內容:"+ textarea.Value;
            mail.password = "yml0428456";

            SendGmailMail(mail.fromAddress, mail.toAddress, mail.Subject, mail.MailBody,mail.password);


        }
      public class sendMail
        {
            public string fromAddress { get; set; }
            public string toAddress { get; set; }

            public string Subject { get; set; }

            public string MailBody { get; set; }
            public string password { get; set; }
        }

        public static void SendGmailMail(string fromAddress, string toAddress, string Subject, string MailBody, string password)
        {

            MailMessage mailMessage = new MailMessage(fromAddress, toAddress);
            
            mailMessage.Subject = Subject;//郵件標題
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = MailBody;
            // SMTP Server
            SmtpClient mailSender = new SmtpClient("smtp.gmail.com");
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(fromAddress, password);
            mailSender.Credentials = basicAuthenticationInfo;
            mailSender.Port = 587;
            mailSender.EnableSsl = true;

            try
            {

                mailSender.Send(mailMessage);
                mailMessage.Dispose();
            }
            catch
            {
                return;
            }
            mailSender = null;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            sendGMail();
            Response.Redirect("Contact.aspx");
        }
    }
}