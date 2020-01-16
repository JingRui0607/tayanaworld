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

namespace TayanaProject.sys
{
    public partial class Dealers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {



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
            SqlCommand command = new SqlCommand($"with cte as(\r\nSELECT   ROW_NUMBER() OVER(ORDER BY id asc ) as rowID , id, DealersName,main,photo,initdate , (select name from Country where id = Dealers.Cid) as Country   FROM     Dealers \r\n)\r\n \r\nselect * from   cte  where rowID >= {(page - 1) * 5 + 1}  and rowID <={page * 5} ", getConnection);
            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);
            DataTable user = new DataTable();
            loginAdapter.Fill(user);
            GridView1.DataSource = user; //告訴GridView1的DataSource資料來源是dataset
            GridView1.DataBind(); //資料繫結
            
        }
        public void Pagination()
        {

            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command =
                new SqlCommand("SELECT  count(*)  FROM    Dealers Where 1 = 1", getConnection);
            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);
            DataTable user = new DataTable();
            loginAdapter.Fill(user);


            UserPagination.limit = 5; //每頁數量
            UserPagination.totalitems = Convert.ToInt32(user.Rows[0][0]); //資料總量
            UserPagination.targetpage = "Dealers.aspx"; //連結文字，例:pagination.aspx?page=100
            UserPagination.showPageControls();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();//抓第幾行要被動作
            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command = new SqlCommand("DELETE  FROM Dealers WHERE   (id = @id)", getConnection);

            command.Parameters.Add("@id", SqlDbType.NVarChar);
            command.Parameters["@id"].Value = id;
            getConnection.Open();
            command.ExecuteNonQuery();
            getConnection.Close();
            showdata();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddDealers.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCountry.aspx");

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            string id = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect("UpdateDealers.aspx?id="+id);
        }
    }
}