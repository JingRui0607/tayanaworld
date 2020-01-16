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
    public partial class NewsIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                

                rightmain();
                Pagination();


            }

        }

        public void rightmain()
        {
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("ShowNews.sql"));
            string config = System.Web.Configuration.WebConfigurationManager
                     .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection connectionID = new SqlConnection(config);
            SqlCommand commandID = new SqlCommand(sql, connectionID);
            connectionID.Open();
            SqlDataReader rereader = commandID.ExecuteReader();

            Repeater1.DataSource = rereader;//repeater的資料來源是從rereader來
            Repeater1.DataBind();//執行繫結
            connectionID.Close();

            



            

        }
        private int limit = 10;
        public void Pagination()
        {

            

            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command =
                new SqlCommand("SELECT  count(*)  FROM    YachtsNews Where 1=1 ", getConnection);
            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);

            DataTable user = new DataTable();
            loginAdapter.Fill(user);


            UserPagination.limit = limit; //每頁數量
            UserPagination.totalitems = Convert.ToInt32(user.Rows[0][0]); //資料總量
            UserPagination.targetpage = "NewsIndex.aspx"; //連結文字，例:pagination.aspx?page=100
            UserPagination.showPageControls();
        }

    }
}