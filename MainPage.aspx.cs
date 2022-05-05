using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebOzyrys
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLab.Visible = false;
            Recovery_Pass.Visible = false;
            data_ozyrys.Text = DateTime.Now.Year.ToString() + " - Ozyrys";
        }
        string connection = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        protected void btn_login_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string query = "Select count(1) FROM [OzyrysApp].[dbo].[Customers] where [Mail] = @txt_user and [Password]=@txt_pasword";
                SqlCommand com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@txt_user", txt_User.Text.Trim());
                com.Parameters.AddWithValue("@txt_pasword", txt_pass.Text.Trim());
                int count = Convert.ToInt32(com.ExecuteScalar());
                if(count ==1)
                {
                    Session["Mail"] = txt_User.Text.Trim();
                    Session["Password"] = txt_pass.Text.Trim();
                    query = "UPDATE [OzyrysApp].[dbo].[Users] SET [LastDayLogin] = GetDate() where [Login] = 'online'";
                    com = new SqlCommand(query, conn);
                    com.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("panel");
                }
                else
                {
                    ErrorLab.Visible = true;
                    Recovery_Pass.Visible = true;
                }
            }
        }

        protected void Recovery_Pass_Click(object sender, EventArgs e)
        {
            Response.Redirect("password_reset");
        }
    }
}