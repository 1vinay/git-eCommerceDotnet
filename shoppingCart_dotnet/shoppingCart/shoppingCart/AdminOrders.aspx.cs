using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace shoppingCart
{
    public partial class AdminOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowProducts();
        }


        private static string connstr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["shoppingCart"].ConnectionString;

        private SqlCommand cmd;
        private SqlConnection conn;

        private SqlDataReader rdr;
        private void ShowProducts()
        {
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("SELECT Cart.CartID, Cart.ProductID, Products.ProductName, Products.ProductCost FROM Cart INNER JOIN Products ON Cart.ProductID = Products.ProductID WHERE Cart.Ordered = 'Inactive' ", conn);

            System.Data.DataTable dt = new System.Data.DataTable();

            conn.Open();

            rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {

                dt.Load(rdr);

                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            else
            {
                dt.Load(rdr);

                GridView1.DataSource = dt;
                GridView1.EmptyDataText = "No Products where Ordered";

                GridView1.DataBind();


            }
            conn.Close();
        }

        protected void btnConfirmOrder_Click(object sender, EventArgs e)
        {

            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("UPDATE Cart SET Ordered = @Pname WHERE ProductID = @lblProductID", conn);

            cmd.Parameters.AddWithValue("@lblProductID", lblProductID.Text);
            cmd.Parameters.AddWithValue("@Pname", "Active");
            

            conn.Open();

            if (cmd.ExecuteNonQuery() == 1)
            {

                lblProductID.Text = "Product is confirmed Successfully";

            }

            conn.Close();
            ShowProducts();


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowIndex = GridView1.SelectedIndex;
            lblProductID.Text = GridView1.SelectedRow.Cells[2].Text;
            txtProductName.Text = GridView1.SelectedRow.Cells[3].Text;
        }
    }
}