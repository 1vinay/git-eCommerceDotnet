using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace shoppingCart
{
    public partial class ShowCart : System.Web.UI.Page
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
            cmd = new SqlCommand("SELECT Cart.CartID, Cart.ProductID, Products.ProductName, Products.ProductCost FROM Cart INNER JOIN Products ON Cart.ProductID = Products.ProductID WHERE UserID='"+ Session["UserID"] + "'" , conn);
            System.Data.DataTable dt = new System.Data.DataTable();
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
                GridView1.EmptyDataText = "No Products to show in cart";
                GridView1.DataBind();
            }
            conn.Close();
        }




        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {



            conn = new SqlConnection(connstr);

            conn.Open();
            cmd = new SqlCommand("DELETE FROM Cart WHERE ProductID = @Pid AND UserID = '" + Session["UserID"] + "'", conn);

           

            cmd.Parameters.AddWithValue("@Pid", GridView1.SelectedRow.Cells[2].Text);

            if (cmd.ExecuteNonQuery() == 1)
            {
                lblMessage.Text = "Product is removed from the Cart";
                ShowProducts();
            }
            else
            {
                lblMessage.Text = "Product failed to remove from Cart";
            }
            conn.Close();



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerOrder.aspx");
        }
    }
}