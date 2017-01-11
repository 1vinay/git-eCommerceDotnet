using System; 
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace shoppingCart
{
    public partial class CustomerProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowProducts();
        }

        private static string connstr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["shoppingCart"].ConnectionString;

        private SqlCommand cmd;
        private SqlConnection conn;
        private SqlDataReader rdr;




        protected void ShowProducts()
        {
            conn = new SqlConnection(connstr);
            conn.Open();
            cmd = new SqlCommand("SELECT ProductID,ProductName,ProductCost from Products", conn);
            System.Data.DataTable dtitems = new System.Data.DataTable();
            rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                dtitems.Load(rdr);
                GridView1.DataSource = dtitems;
                GridView1.DataBind();
            }
            else
            {
                dtitems.Load(rdr);
                GridView1.DataSource = dtitems;
                GridView1.EmptyDataText = "No Products to show";
                GridView1.DataBind();
            }
            conn.Close();
        }
        
        
        
        
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
            {
                Response.Redirect("login.aspx");
            }

            conn = new SqlConnection(connstr);

            conn.Open();
            cmd = new SqlCommand("INSERT INTO Cart(ProductID,UserID) values(@Pid,@Uid)", conn);
            cmd.Parameters.AddWithValue("@Pid", Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text));
            cmd.Parameters.AddWithValue("@Uid", Convert.ToInt32(Session["UserID"]));

            if (cmd.ExecuteNonQuery() == 1)
            {
                lblMessage.Text = "Product is added to the Cart";
                ShowProducts();
            }
            else
            {
                lblMessage.Text = "Product failed to add to Cart";
            }
            conn.Close();


        }
    }
}