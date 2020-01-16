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
    public partial class ADDYachts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showdata();
                Pagination();
            }

        }

        private int limit = 5;
        public void showdata()
        {
            int page = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/YachtsInformation.sql"));
            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;

            SqlConnection getConnection = new SqlConnection(config);
            SqlCommand command = new SqlCommand(sql, getConnection);
            command.Parameters.Add("@limit", SqlDbType.Int);
            command.Parameters["@limit"].Value = limit;
            command.Parameters.Add("@page", SqlDbType.Int);
            command.Parameters["@page"].Value = page;

            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);
            DataTable user = new DataTable();
            loginAdapter.Fill(user);
            GridView1.DataSource = user; //告訴GridView1的DataSource資料來源是dataset
            GridView1.DataBind(); //資料繫結
        }
        public void Pagination()
        {

            string commandpage = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/YachtsCount.sql"));

            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command =
                new SqlCommand(commandpage, getConnection);
            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);

            DataTable user = new DataTable();
            loginAdapter.Fill(user);


            UserPagination.limit = limit; //每頁數量
            UserPagination.totalitems = Convert.ToInt32(user.Rows[0][0]); //資料總量
            UserPagination.targetpage = "YachtsInformation.aspx"; //連結文字，例:pagination.aspx?page=100
            UserPagination.showPageControls();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/YachtsDelete.sql"));
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
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            int page = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
            Response.Redirect("YachtsUpdate.aspx?id=" + id + "&Page=" + page);



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("YachtsAdd.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string get = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);

            switch (e.CommandName)
            {

                case "NewYachts":
                    {

                        string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/IsNew.sql"));
                        LinkButton BTN = (LinkButton)e.CommandSource;    //先抓到這個按鈕（我們設定了CommandName）
                        GridViewRow myRow = (GridViewRow)BTN.NamingContainer;
                        string id = GridView1.DataKeys[myRow.RowIndex].Value.ToString();//抓取ID


                        SqlCommand command = new SqlCommand(sql, getConnection);

                        command.Parameters.Add("@id", SqlDbType.Int);

                        command.Parameters["@id"].Value = Convert.ToInt32(id);

                        getConnection.Open();

                        command.ExecuteNonQuery();

                        getConnection.Close();

                        break;

                    }

                case "YachtsAlbum":
                    {
                        LinkButton BTN = (LinkButton)e.CommandSource;    //先抓到這個按鈕（我們設定了CommandName）
                        GridViewRow myRow = (GridViewRow)BTN.NamingContainer;
                        string id = GridView1.DataKeys[myRow.RowIndex].Value.ToString();//抓取ID

                        Response.Redirect("YachtsAlbum.aspx?id=" + id);
                        break;
                    }
                case "YachtsLayout":
                    {
                        LinkButton BTN = (LinkButton)e.CommandSource;    //先抓到這個按鈕（我們設定了CommandName）
                        GridViewRow myRow = (GridViewRow)BTN.NamingContainer;
                        string id = GridView1.DataKeys[myRow.RowIndex].Value.ToString();//抓取ID

                        Response.Redirect("YachtsLayout.aspx?id=" + id);
                        break;
                    }



             






            }

            showdata();
        }
    }
}