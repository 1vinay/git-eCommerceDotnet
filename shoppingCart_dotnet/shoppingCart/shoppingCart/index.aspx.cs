using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace shoppingCart
{
    public partial class index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showProducts();
        }


        private static string connstr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["shoppingCart"].ConnectionString;

        private SqlCommand cmd;
        private SqlConnection conn;
        private SqlDataReader rdr;


        protected void showProducts()
        {

            conn = new SqlConnection(connstr);
            conn.Open();
            cmd = new SqlCommand("SELECT ProductID, ProductName, ProductCost from Products WHERE ProductUser ='" + Session["UserID"] + "'", conn);
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
                GridView1.EmptyDataText = "Products Not Found";
                GridView1.DataBind();

            }
            conn.Close();

        }

        protected void btnChangeProduct_Click(object sender, EventArgs e)
        {


            conn = new SqlConnection(connstr);

            conn.Open();

            cmd = new SqlCommand("UPDATE Products SET ProductName = @Pname, ProductCost = @Pcost WHERE ProductID = @lblProductID", conn);

            cmd.Parameters.AddWithValue("@lblProductID", lblProductID.Text);
            cmd.Parameters.AddWithValue("@Pname", txtProductName.Text);
            cmd.Parameters.AddWithValue("@Pcost", txtProductPrice.Text);

            

            if (cmd.ExecuteNonQuery() == 1)
            {

                lblProductUpdate.Text = "Product is Updated Successfully";

                showProducts();

            }
            else
            {
                lblProductUpdate.Text = "Product failed to Update";
            }

            conn.Close();

        }

        protected void btnOrderProduct_Click(object sender, EventArgs e)
        {
            if (lblProductID.Text != "")
            {

                lblProductUpdate.Text = "Product already exists, Can be updated";
            }

            conn = new SqlConnection(connstr);

            conn.Open();

            cmd = new SqlCommand("INSERT INTO Products(ProductName, ProductCost, ProductUser) VALUES (@Pname , @Pcost, @Puser)", conn);

            cmd.Parameters.AddWithValue("@Pname", txtProductName.Text);
            cmd.Parameters.AddWithValue("@Pcost", txtProductPrice.Text);
            cmd.Parameters.AddWithValue("@Puser", Session["UserID"]);

            
            if (cmd.ExecuteNonQuery() == 1)
            {
                lblProductMessage.Text = "Product has been Added";
                showProducts();
                lblProductID.Text = "";
            }
            else
            {
                lblProductID.Text = "Product failed to add"; 
            }
            conn.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowIndex = GridView1.SelectedIndex;
            lblProductID.Text = GridView1.SelectedRow.Cells[1].Text;
            txtProductName.Text = GridView1.SelectedRow.Cells[2].Text;
            txtProductPrice.Text = GridView1.SelectedRow.Cells[3].Text;

        }
    }
}