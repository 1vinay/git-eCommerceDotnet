using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace shoppingCart
{
    public partial class CustomerOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OrderedProducts();
        }

        private static string connstr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["shoppingCart"].ConnectionString;

        private SqlCommand cmd;
        private SqlCommand cmdins;
        private SqlConnection conn;
        private SqlDataReader rdr;
     


        private void OrderedProducts()
        {
            conn = new SqlConnection(connstr);
            conn.Open();
            cmd = new SqlCommand("SELECT Cart.CartID, Cart.ProductID, Products.ProductName, Products.ProductCost FROM Cart INNER JOIN Products ON Cart.ProductID = Products.ProductID WHERE UserID='" + Session["UserID"] + "'", conn);
            
            System.Data.DataTable dt = new System.Data.DataTable();
            rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                dt.Load(rdr);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                cmdins = new SqlCommand("UPDATE Cart SET Ordered = @Ordered WHERE UserID='" + Session["UserID"] + "'", conn);

                cmdins.Parameters.AddWithValue("@Ordered", "Inactive");
                
                cmdins.ExecuteNonQuery();
            }
            else
            {
                dt.Load(rdr);
                GridView1.DataSource = dt;
                GridView1.EmptyDataText = "No Products to show in cart";
                GridView1.DataBind();
            }
            conn.Close();
        }

    }
}