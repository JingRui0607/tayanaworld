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
    public partial class Overview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                topphoto();
                leftSideBar();

                

                rightmain();


            }

        }

        public void topphoto()
        {
            string config = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection connectionID = new SqlConnection(config);
            SqlCommand commandID = new SqlCommand($"Select * FROM YachtsType ", connectionID);
            SqlDataAdapter loginAdapterID = new SqlDataAdapter(commandID);
            DataTable userID = new DataTable();
            loginAdapterID.Fill(userID);





           
            SqlConnection rconnection = new SqlConnection(config);


            SqlCommand Rcommand = new SqlCommand($"Select Photos FROM YachtsAlbum where YachtsID=@id ", rconnection);

            if (string.IsNullOrEmpty($"{Request.QueryString["id"]}"))
            {
                string id = Request.QueryString["id"] ?? $"{userID.Rows[0]["id"].ToString()}";
                Rcommand.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                Rcommand.Parameters["@id"].Value = id; //接id的值變成參數的值
            }
            else
            {
                Rcommand.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                Rcommand.Parameters["@id"].Value = Request.QueryString["id"]; //接id的值變成參數的值

            }


            rconnection.Open();
            SqlDataReader rereader = Rcommand.ExecuteReader();

            Repeater3.DataSource = rereader;//repeater的資料來源是從rereader來
            Repeater3.DataBind();//執行繫結
            rconnection.Close();

        }
        public void leftSideBar()
        {
            string config = System.Web.Configuration.WebConfigurationManager
                     .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection rconnection = new SqlConnection(config);


            SqlCommand Rcommand = new SqlCommand($"Select * FROM YachtsType  ", rconnection);




            rconnection.Open();
            SqlDataReader rereader = Rcommand.ExecuteReader();

            Repeater1.DataSource = rereader;//repeater的資料來源是從rereader來
            Repeater1.DataBind();//執行繫結
            rconnection.Close();
        }
       

        public void rightmain()
        {
            string config = System.Web.Configuration.WebConfigurationManager
                     .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection connectionID = new SqlConnection(config);
            SqlCommand commandID = new SqlCommand($"Select * FROM YachtsType ", connectionID);
            SqlDataAdapter loginAdapterID = new SqlDataAdapter(commandID);
            DataTable userID = new DataTable();
            loginAdapterID.Fill(userID);

            //判斷Request.QueryString["id"]有沒有資料,因為一開始進網頁時要直接抓第一筆id,但網址一開始載入會沒有id資料

            //抓名字(標題)



            SqlConnection rconnection = new SqlConnection(config);

            SqlCommand Rcommand = new SqlCommand($"Select * FROM YachtsType where id =@id  ", rconnection);

           

            if (string.IsNullOrEmpty($"{Request.QueryString["id"]}"))
            {
                string id = Request.QueryString["id"] ?? $"{userID.Rows[0]["id"].ToString()}";
                Rcommand.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                Rcommand.Parameters["@id"].Value = id; //接id的值變成參數的值
                menuOverview.HRef = "Overview.aspx?id=" +id;
                menuLayout.HRef = "Layout.aspx?id=" + id;
                menuSpec.HRef = "Specifications.aspx?id=" + id;
            }
            else
            {
                Rcommand.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                Rcommand.Parameters["@id"].Value = Request.QueryString["id"]; //接id的值變成參數的值
                menuOverview.HRef = "Overview.aspx?id=" + Request.QueryString["id"];
                menuLayout.HRef = "Layout.aspx?id=" + Request.QueryString["id"];
                menuSpec.HRef = "Specifications.aspx?id=" + Request.QueryString["id"];

            }
            SqlDataAdapter loginAdapter = new SqlDataAdapter(Rcommand);
            DataTable user = new DataTable();
            loginAdapter.Fill(user);

            if (user.Rows[0]["NewYachts"].ToString() == "False") 
            {
                rightYachtsName.InnerHtml = user.Rows[0]["YachtsType"].ToString();
            }
            else
            {
                rightYachtsName.InnerHtml = user.Rows[0]["YachtsType"].ToString();
                spanname.InnerHtml = " New";
            }
            
            Yachtsnnn.InnerHtml = user.Rows[0]["YachtsType"].ToString();
            rightYachtsName1.InnerHtml = user.Rows[0]["YachtsType"].ToString();

            SqlConnection connectionMain = new SqlConnection(config);
            SqlCommand commandMain = new SqlCommand($"Select Overview,Dimensions FROM YachtsType where id=@id ", connectionMain);


            if (string.IsNullOrEmpty($"{Request.QueryString["id"]}"))
            {
                string id = Request.QueryString["id"] ?? $"{userID.Rows[0]["id"].ToString()}";
                commandMain.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                commandMain.Parameters["@id"].Value = id; //接id的值變成參數的值

            }
            else
            {
                commandMain.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                commandMain.Parameters["@id"].Value = Request.QueryString["id"]; //接id的值變成參數的值
            }

            SqlDataAdapter loginAdapterMain = new SqlDataAdapter(commandMain);
            DataTable userMain = new DataTable();
            loginAdapterMain.Fill(userMain);
            yacht001.InnerHtml = userMain.Rows[0]["Overview"].ToString();
            yacht002.InnerHtml = userMain.Rows[0]["Dimensions"].ToString();

            //下載

            SqlConnection RPconnection = new SqlConnection(config);


            SqlCommand RPcommand = new SqlCommand($"Select ROW_NUMBER() OVER (ORDER BY id ASC) as ROW_ID, DownloadName ,(Select YachtsType from YachtsType where id=YachtsDownload.YachtsID) as YachtsName from YachtsDownload where YachtsID=@rid", RPconnection);
            if (string.IsNullOrEmpty($"{Request.QueryString["id"]}"))
            {
                string id = Request.QueryString["id"] ?? $"{userID.Rows[0]["id"].ToString()}";
                RPcommand.Parameters.Add("@rid", SqlDbType.NVarChar); //設定參數資料型態
                RPcommand.Parameters["@rid"].Value = id;//接id的值變成參數的值
            }
            else
            {
                RPcommand.Parameters.Add("@rid", SqlDbType.NVarChar); //設定參數資料型態
                RPcommand.Parameters["@rid"].Value = Request.QueryString["id"]; //接id的值變成參數的值

            }

            RPconnection.Open();
            SqlDataReader RPrereader = RPcommand.ExecuteReader();

            Repeater_download.DataSource = RPrereader;//repeater的資料來源是從rereader來
            Repeater_download.DataBind();//執行繫結


        }





    }
}