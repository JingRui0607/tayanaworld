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
    public partial class Yachts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                leftSideBar();

                rightmain();
                Response.Redirect("Overview.aspx");
            }
        }

        //繫結左邊的名字與連結
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
        }
        public void rightMainBar()
        {
            string config = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection rconnection = new SqlConnection(config);


            SqlCommand command = new SqlCommand($"SELECT   Overview, Layout_DeckPlan as 'Layout & desk plan', Specifications FROM     YachtsType ", rconnection);
           
            
            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);
            DataTable user = new DataTable();
            loginAdapter.Fill(user);


            //rightspan1.InnerHtml = user.Rows[0].ToString();
            //rightspan2.InnerHtml = user.Rows[1].ToString();
            //rightspan3.InnerHtml = user.Rows[2].ToString();







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

                string id = Request.QueryString["id"] ?? $"{userID.Rows[0]["id"].ToString()}";

                SqlConnection rconnection = new SqlConnection(config);

                SqlCommand Rcommand = new SqlCommand($"Select * FROM YachtsType where id =@id  ", rconnection);

                Rcommand.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                Rcommand.Parameters["@id"].Value = id; //接id的值變成參數的值

                SqlDataAdapter loginAdapter = new SqlDataAdapter(Rcommand);
                DataTable user = new DataTable();
                loginAdapter.Fill(user);

                rightYachtsName.InnerHtml = user.Rows[0]["YachtsType"].ToString();
                Yachtsnnn.InnerHtml= user.Rows[0]["YachtsType"].ToString();
            }


            else
            {
                SqlConnection rconnection = new SqlConnection(config);

                SqlCommand Rcommand = new SqlCommand($"Select * FROM YachtsType where id =@id  ", rconnection);

                Rcommand.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                Rcommand.Parameters["@id"].Value = Request.QueryString["id"]; //接id的值變成參數的值

                SqlDataAdapter loginAdapter = new SqlDataAdapter(Rcommand);
                DataTable user = new DataTable();
                loginAdapter.Fill(user);

                rightYachtsName.InnerHtml = user.Rows[0]["YachtsType"].ToString();
                Yachtsnnn.InnerHtml = user.Rows[0]["YachtsType"].ToString();
            }

        }
    }
}