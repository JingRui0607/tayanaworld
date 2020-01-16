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
    public partial class AddCountry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showdata();
            }
        }
        public void showdata()
        {

            int page = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;

            SqlConnection getConnection = new SqlConnection(config);
            SqlCommand command = new SqlCommand($"with cte as(\r\nSELECT   ROW_NUMBER() OVER(ORDER BY id desc ) as rowID , id, name,initdate   FROM    Country \r\n)\r\n \r\nselect * from   cte  where rowID >= {(page - 1) * 5 + 1}  and rowID <={page * 5} ", getConnection);
            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);
            DataTable user = new DataTable();

            loginAdapter.Fill(user);
            GridView1.DataSource = user; //告訴GridView1的DataSource資料來源是dataset
            GridView1.DataBind(); //資料繫結

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string config = System.Web.Configuration.WebConfigurationManager
               .ConnectionStrings["ProjectConnection"].ConnectionString;

            SqlConnection getConnection = new SqlConnection(config);
            SqlCommand command = new SqlCommand($"INSERT INTO Country  (name) VALUES  (@name)", getConnection);
            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);



            command.Parameters.Add("@name", SqlDbType.NVarChar);
            command.Parameters["@name"].Value = TextBox2.Text;
            //有時間的話做確認重複國家

            getConnection.Open();
            command.ExecuteNonQuery();
            getConnection.Close();


            Response.Redirect("AddCountry.aspx");

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();//抓第幾行要被動作
            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command = new SqlCommand("DELETE  FROM Country WHERE   (id = @id)  DELETE  FROM Dealers WHERE   (Cid = @id) ", getConnection);

            command.Parameters.Add("@id", SqlDbType.NVarChar);
            command.Parameters["@id"].Value = id;
            getConnection.Open();
            command.ExecuteNonQuery();
            getConnection.Close();
            showdata();
           

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dealers.aspx");
        }
    }
}