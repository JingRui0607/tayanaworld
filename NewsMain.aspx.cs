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

namespace TayanaProject
{
    public partial class NewsMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {




                rightmain();
                


            }
        }
        public void rightmain()
        {
            string config = System.Web.Configuration.WebConfigurationManager
                      .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection connectionID = new SqlConnection(config);
            SqlCommand commandID = new SqlCommand($"Select * FROM YachtsNews where id=@id", connectionID);

            commandID.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
            commandID.Parameters["@id"].Value = Request.QueryString["id"];

            SqlDataAdapter loginAdapterID = new SqlDataAdapter(commandID);
            DataTable userID = new DataTable();
            loginAdapterID.Fill(userID);

            NewsMainName.InnerHtml = userID.Rows[0]["title"].ToString();
            NewsMains.InnerHtml = userID.Rows[0]["main"].ToString();


            //download



            SqlConnection RPconnection = new SqlConnection(config);


            SqlCommand RPcommand = new SqlCommand($"Select ROW_NUMBER() OVER (ORDER BY id ASC) as ROW_ID, filename ,(Select title from YachtsNews where id=NewsDownload.uid) as title from NewsDownload where uid=@uid", RPconnection);
           
                RPcommand.Parameters.Add("@uid", SqlDbType.NVarChar); //設定參數資料型態
                RPcommand.Parameters["@uid"].Value = Request.QueryString["id"];//接id的值變成參數的值
           

            RPconnection.Open();
            SqlDataReader RPrereader = RPcommand.ExecuteReader();

            Repeater_download.DataSource = RPrereader;//repeater的資料來源是從rereader來
            Repeater_download.DataBind();//執行繫結





        }
    }
}