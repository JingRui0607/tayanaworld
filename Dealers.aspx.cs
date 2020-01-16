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
    public partial class Dealers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            leftSideBar();
            rightmain();

        }
        public void leftSideBar()
        {
            string config = System.Web.Configuration.WebConfigurationManager
                     .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection rconnection = new SqlConnection(config);


            SqlCommand Rcommand = new SqlCommand($"Select id,name as Country ,initdate FROM Country  ", rconnection);




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
            SqlCommand commandID = new SqlCommand($"Select * FROM Country ", connectionID);
            SqlDataAdapter loginAdapterID = new SqlDataAdapter(commandID);
            DataTable userID = new DataTable();
            loginAdapterID.Fill(userID);

            //判斷Request.QueryString["id"]有沒有資料,因為一開始進網頁時要直接抓第一筆id,但網址一開始載入會沒有id資料
            if (string.IsNullOrEmpty($"{Request.QueryString["id"]}"))
            {
                //抓名字(標題)

                string id = Request.QueryString["id"] ?? $"{userID.Rows[0]["id"].ToString()}";

                SqlConnection rconnection = new SqlConnection(config);

                SqlCommand Rcommand = new SqlCommand($"Select * FROM Country where id =@id  ", rconnection);

                Rcommand.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                Rcommand.Parameters["@id"].Value = id; //接id的值變成參數的值

                SqlDataAdapter loginAdapter = new SqlDataAdapter(Rcommand);
                DataTable user = new DataTable();
                loginAdapter.Fill(user);

                rightCountryName.InnerHtml = user.Rows[0]["name"].ToString();
               rightCountryName2.InnerHtml = user.Rows[0]["name"].ToString();




                //內容

                SqlConnection connectionMain = new SqlConnection(config);
                SqlCommand commandMain = new SqlCommand($"Select * FROM Dealers where Cid=@id ", connectionMain);
                commandMain.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                commandMain.Parameters["@id"].Value = id; //接id的值變成參數的值


                connectionMain.Open();
                SqlDataReader rereader = commandMain.ExecuteReader();

                Repeater_Main.DataSource = rereader;//repeater的資料來源是從rereader來
                Repeater_Main.DataBind();//執行繫結
                connectionMain.Close();




            }


            else
            {
                //抓名字(標題)
                SqlConnection rconnection = new SqlConnection(config);

                SqlCommand Rcommand = new SqlCommand($"Select * FROM Country where id =@id  ", rconnection);

                Rcommand.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                Rcommand.Parameters["@id"].Value = Request.QueryString["id"]; //接id的值變成參數的值

                SqlDataAdapter loginAdapter = new SqlDataAdapter(Rcommand);
                DataTable user = new DataTable();
                loginAdapter.Fill(user);

                rightCountryName.InnerHtml = user.Rows[0]["name"].ToString();
                rightCountryName2.InnerHtml = user.Rows[0]["name"].ToString();

                // 繫結內容資料

                SqlConnection connectionMain = new SqlConnection(config);
                SqlCommand commandMain = new SqlCommand($"Select * FROM Dealers where Cid=@id ", connectionMain);
                commandMain.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                commandMain.Parameters["@id"].Value = Request.QueryString["id"]; //接id的值變成參數的值
                connectionMain.Open();
                SqlDataReader rereader = commandMain.ExecuteReader();

                Repeater_Main.DataSource = rereader;//repeater的資料來源是從rereader來
                Repeater_Main.DataBind();//執行繫結
                connectionMain.Close();



            }

        }
    }
}