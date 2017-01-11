using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace shoppingCart
{
    public partial class AddProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static string connstr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["shoppingCart"].ConnectionString;

        private SqlCommand cmd;
        private SqlConnection conn;
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowIndex = GridView1.SelectedIndex;
            lblProductID.Text = GridView1.SelectedRow.Cells[1].Text;
            txtProductName.Text = GridView1.SelectedRow.Cells[2].Text;
            txtProductPrice.Text = GridView1.SelectedRow.Cells[3].Text;

        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstr);

            cmd = new SqlCommand("INSERT INTO Products(ProductName, ProductCost) VALUES (@Pname , @Pcost)", conn);

            cmd.Parameters.AddWithValue("@Pname", txtProductName.Text);
            cmd.Parameters.AddWithValue("@Pcost", txtProductPrice.Text);

            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                lblProductMsg.Text = "Product has been Added";


            }

            conn.Close();

        }


        private SqlDataReader rdr;
        protected void btnShowProducts_Click(object sender, EventArgs e)
        {
           
                ShowProducts();
          
            
        }

        private void ShowProducts()
        {
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("SELECT * FROM Products", conn);

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
                GridView1.EmptyDataText = "No Products to show";

                GridView1.DataBind();


            }
            conn.Close();
        }

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("UPDATE Products SET ProductName = @Pname, ProductCost = @Pcost WHERE ProductID = @lblProductID", conn);

            cmd.Parameters.AddWithValue("@lblProductID", lblProductID.Text);
            cmd.Parameters.AddWithValue("@Pname", txtProductName.Text);
            cmd.Parameters.AddWithValue("@Pcost", txtProductPrice.Text);

            conn.Open();

            if(cmd.ExecuteNonQuery() == 1)
            {

                lblProductMsg.Text = "Product is Updated Successfully"; 

            }

            conn.Close();
            ShowProducts();

        }

        protected void btnSearchProduct_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstr);
            conn.Open();
            cmd = new SqlCommand("SELECT ProductID, ProductName, ProductCost from Products WHERE ProductNAme like '%" + txtProductSearch.Text + "%'", conn);
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
                GridView1.EmptyDataText = "Product is not found";
                GridView1.DataBind();
            }
            conn.Close();
        }

        
    }
}