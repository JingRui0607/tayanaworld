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
    public partial class Specifications : System.Web.UI.Page
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
            if (string.IsNullOrEmpty($"{Request.QueryString["id"]}"))
            {
                //抓名字(標題)

                string id = Request.QueryString["id"] ?? $"{userID.Rows[0]["id"].ToString()}";

                SqlConnection rconnection = new SqlConnection(config);

                SqlCommand Rcommand = new SqlCommand($"Select * FROM YachtsType where id =@id  ", rconnection);

                Rcommand.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                Rcommand.Parameters["@id"].Value = id; //接id的值變成參數的值

                SqlDataAdapter loginAdapter = new SqlDataAdapter(Rcommand);
                DataTable user = new DataTable();
                loginAdapter.Fill(user);

                menuOverview.HRef = "Overview.aspx?id=" + id;
                menuLayout.HRef = "Layout.aspx?id=" + id;
                menuSpec.HRef = "Specifications.aspx?id=" + id;

                Yachtsnnn.InnerHtml = user.Rows[0]["YachtsType"].ToString();

                if (user.Rows[0]["NewYachts"].ToString() == "False")
                {
                    rightYachtsName.InnerHtml = user.Rows[0]["YachtsType"].ToString();
                }
                else
                {
                    rightYachtsName.InnerHtml = user.Rows[0]["YachtsType"].ToString();
                    spanname.InnerHtml = " New";
                }

                //抓主要內容資料

                SqlConnection connectionMain = new SqlConnection(config);
                SqlCommand commandMain = new SqlCommand($"Select Specifications FROM YachtsType where id =@id", connectionMain);
                commandMain.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                commandMain.Parameters["@id"].Value = id; //接id的值變成參數的值


                SqlDataAdapter Adapter = new SqlDataAdapter(commandMain);
                DataTable  main = new DataTable();
                Adapter.Fill(main);




                yacht001.InnerHtml = main.Rows[0]["Specifications"].ToString();

            }


            else
            {
                //抓名字(標題)
                SqlConnection rconnection = new SqlConnection(config);

                SqlCommand Rcommand = new SqlCommand($"Select * FROM YachtsType where id =@id  ", rconnection);

                Rcommand.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                Rcommand.Parameters["@id"].Value = Request.QueryString["id"]; //接id的值變成參數的值

                SqlDataAdapter loginAdapter = new SqlDataAdapter(Rcommand);
                DataTable user = new DataTable();
                loginAdapter.Fill(user);
                menuOverview.HRef = "Overview.aspx?id=" + Request.QueryString["id"];
                menuLayout.HRef = "Layout.aspx?id=" + Request.QueryString["id"];
                menuSpec.HRef = "Specifications.aspx?id=" + Request.QueryString["id"];

                Yachtsnnn.InnerHtml = user.Rows[0]["YachtsType"].ToString();
                if (user.Rows[0]["NewYachts"].ToString() == "False")
                {
                    rightYachtsName.InnerHtml = user.Rows[0]["YachtsType"].ToString();
                }
                else
                {
                    rightYachtsName.InnerHtml = user.Rows[0]["YachtsType"].ToString();
                    spanname.InnerHtml = " New";
                }
                // 繫結內容資料

                SqlConnection connectionMain = new SqlConnection(config);
                SqlCommand commandMain = new SqlCommand($"Select Specifications FROM YachtsType where id =@id ", connectionMain);
                commandMain.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                commandMain.Parameters["@id"].Value = Request.QueryString["id"]; //接id的值變成參數的值
                SqlDataAdapter Adapter = new SqlDataAdapter(commandMain);
                DataTable main = new DataTable();
                Adapter.Fill(main);




                yacht001.InnerHtml = main.Rows[0]["Specifications"].ToString();





            }

        }
    }
}
