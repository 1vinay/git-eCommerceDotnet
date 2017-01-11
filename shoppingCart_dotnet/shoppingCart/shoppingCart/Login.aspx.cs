using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Security.Cryptography;



namespace shoppingCart
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }











        private static string connstr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["shoppingCart"].ConnectionString;
        private SqlDataReader rdr;
       
        
        SqlConnection conn = new SqlConnection(connstr);




        protected void btnSignUp_Click(object sender, EventArgs e)
        {

            //create the MD5CryptoServiceProvider object we will use to encrypt the password
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            //create an array of bytes we will use to store the encrypted password
            Byte[] hashedBytes;
            //Create a UTF8Encoding object we will use to convert our password string to a byte array
            UTF8Encoding encoder = new UTF8Encoding();

            //encrypt the password and store it in the hashedBytes byte array
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(txtSignupPassword.Text));


            conn.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from Register where Name=@username", conn);
            cmd1.Parameters.AddWithValue("@username", txtSignupName.Text);
            rdr = cmd1.ExecuteReader();

            if (rdr.HasRows)
            {
                lblMsg.Text = "Username or e-Mail already exists";
            }
            else
            {
                    rdr.Close();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Register(Name,Email,Password,Role) values(@name,@mail,@password,@Role)", conn);
                    cmd.Parameters.AddWithValue("@name", txtSignupName.Text);
                    cmd.Parameters.AddWithValue("@mail", txtSignupEmail.Text);
                    cmd.Parameters.AddWithValue("@password", hashedBytes);
                    cmd.Parameters.AddWithValue("@Role", "Customer");

               
                   
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        lblMsg.Text = "Message status:" + "Customer added successfully";

                       sendEmail();
                    }
                    else
                        lblMsg.Text = "Message status:" + "some error occured";
                 }
            }

        

        protected void Button1_Click(object sender, EventArgs e)
        {

            //create the MD5CryptoServiceProvider object we will use to encrypt the password
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            //create an array of bytes we will use to store the encrypted password
            Byte[] hashedBytes;
            //Create a UTF8Encoding object we will use to convert our password string to a byte array
            UTF8Encoding encoder = new UTF8Encoding();

            //encrypt the password and store it in the hashedBytes byte array
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(txtLoginPassword.Text));



            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * From Register where Name=@username and Password=@password", conn);
            cmd.Parameters.AddWithValue("@username", txtLoginName.Text);
            cmd.Parameters.AddWithValue("@password", hashedBytes);
            //DataTable dtUser = new System.Data.DataTable();
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                Session["UserName"] = txtLoginName.Text;
               // Session["UserID"] = dtUser.Rows[0]["UserID"].ToString();

                Session["UserID"] = rdr["UserID"].ToString();

                if(rdr["Role"].ToString()=="Admin")
                {
                    Session["Role"] = "Admin";

                    Response.Redirect("AddProducts.aspx");
                }
                else
                {
                    Session["Role"] = "Customer";
                    Response.Redirect("CustomerProducts.aspx");
                }
                
            }
            else
            {
                Response.Write(@"<script language=''javascript''>alert('Username Or Password is incorrect')</script>");
            }
            conn.Close();
        }



        string name = "dummystudent05";
        string password = "hello123hello123";
        private void sendEmail()
        {
            try
            {
                MailMessage gmail = new MailMessage();
                SmtpClient gmailSmtpServer = new SmtpClient("smtp.gmail.com");
                gmail.From = new MailAddress("dummystudent05@gmail.com");
                gmail.To.Add(txtSignupEmail.Text);
                gmail.Subject = "Shopping Cart Registration Details";
                gmail.Body = "Hello," + txtSignupName.Text + ". you are now Registered for Shopping Cart!";

                gmailSmtpServer.Port = 587;
                gmailSmtpServer.Credentials = new System.Net.NetworkCredential(name, password);
                gmailSmtpServer.EnableSsl = true;

                gmailSmtpServer.Send(gmail);
                lblMsg.Text = "Message Sent";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.ToString();

            }

        }


        }

     

    


    }
