using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TayanaProject.sys
{
    public partial class user : System.Web.UI.Page
    {
        private int limit = 10;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //if (Session["keyword"] != null)
                //{
                //    KeyWord.Text = Session["keyword"].ToString();
                //}

                showdata();
                Pagination();

            }
        }

        public void showdata()
        {
            int page = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;

            SqlConnection getConnection = new SqlConnection(config);
            SqlCommand command = new SqlCommand($"with cte as(\r\nSELECT   ROW_NUMBER() OVER(ORDER BY id asc ) as rowID , id, name, username, password, mail,photo, permission FROM     UserInformation \r\n)\r\n \r\nselect * from   cte  where rowID >= {(page - 1) * 3 + 1}  and rowID <={page * 3} ", getConnection);
            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);
            DataTable user = new DataTable();
            loginAdapter.Fill(user);
            GridView1.DataSource = user; //告訴GridView1的DataSource資料來源是dataset
            GridView1.DataBind(); //資料繫結
        }

        public void Pagination()
        {

            string commandpage = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/UserPageCount.sql"));

            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command =
                new SqlCommand(commandpage, getConnection);
            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);
            DataTable user = new DataTable();
            loginAdapter.Fill(user);


            UserPagination.limit = 2; //每頁數量
            UserPagination.totalitems = Convert.ToInt32(user.Rows[0][0]); //資料總量
            UserPagination.targetpage = "user.aspx"; //連結文字，例:pagination.aspx?page=100
            UserPagination.showPageControls();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/DeleteUser.sql"));
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();//抓第幾行要被動作
            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command = new SqlCommand(sql, getConnection);

            command.Parameters.Add("@id", SqlDbType.NVarChar);
            command.Parameters["@id"].Value = id;
            getConnection.Open();
            command.ExecuteNonQuery();
            getConnection.Close();
            showdata();
            Pagination();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            int page = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
            Response.Redirect("UpdateUser.aspx?id=" + id + "&Page=" + page);
        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("AddUser.aspx");
        }
      
    }
}