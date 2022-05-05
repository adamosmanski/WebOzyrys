using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace WebOzyrys
{
    public partial class RecoveryPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_phone_number.Visible = true;
            btn_submit.Visible = true;
        }
        string connection = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string query = "Select count(1) FROM [OzyrysApp].[dbo].[Customers] where [Phone] = @txt_phone_number and [Mail]=@txt_email";
                SqlCommand com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@txt_phone_number", txt_phone_number.Text.Trim());
                com.Parameters.AddWithValue("@txt_email", txt_email.Text.Trim());
                int count = Convert.ToInt32(com.ExecuteScalar());
                if (count == 1)
                {
                    Communicate.Text = "Hasło zostało wysłane, sprawdź swoje konto mailowe.";
                    Session["Phone"] = txt_phone_number.Text.Trim();
                    Session["Mail"] = txt_email.Text.Trim();
                    SendEmail(txt_email.Text.Trim());
                }
                else
                {
                    Communicate.Text = "Nie znaleziono takiego użytkownika. Upewnij się że wprowadziłeś poprawny numer telefonu lub adres mailowy";
                }
            }
        }
        private void SendEmail(string mail)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            try
            {
                var message = new MailMessage();
                message.From = new MailAddress("pmooctechniczna@gmail.com");
                message.To.Add(new MailAddress(mail));
                message.Subject = "Hasło";
                message.Body = "Twoje hasło do konta: " + Environment.NewLine + finalString;
                var smtp = new SmtpClient("smtp.gmail.com");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("pmooctechniczna@gmail.com", "Cisowianka144");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(message);

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    string query = "UPDATE [OzyrysApp].[dbo].[Customers] SET [Password] = @pass where [Mail]=@txt_email";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.Parameters.AddWithValue("@pass", finalString);
                    com.Parameters.AddWithValue("@txt_email", txt_email.Text.Trim());
                    com.ExecuteNonQuery();

                }
                Thread.Sleep(TimeSpan.FromSeconds(10));
                Response.Redirect("login");
                
            }
            catch (Exception e)
            {
                Communicate.Text = "Ups... Coś poszło nie tak. Spróbuj ponownie";
            }
            
        }
    }
}