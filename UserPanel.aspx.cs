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
    public partial class UserPanel : Page
    {
        string connection = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlConnection conn;
        SqlCommand com;
        private void Settings()
        {
            panel_moje_dane.Visible = false;
            txt_old_imie.Enabled = false;
            txt_old_nazwisko.Enabled = false;
            txt_old_mail.Enabled = false;
            txt_old_pesel.Enabled = false;
            txt_old_telefon.Enabled = false;
            txt_old_kraj.Enabled = false;
            txt_old_adress.Enabled = false;
            txt_old_city.Enabled = false;
            btn_edytuj.Enabled = true;
            panel_kontrahenci.Visible = false;
            panel_dgv_kontrahent.Visible = false;
            panel_dodaj_kh.Visible = false;
        }

        private void LoadData()
        {
            string query = "SELECT [Name],[FirstName],[Pesel],[Mail],[Phone],[Country],[City],[Adress] FROM [OzyrysApp].[dbo].[CustomersInformation] where [Mail]='"+Session["Mail"].ToString()+"'";
            conn = new SqlConnection(connection);
            SqlCommand com = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                txt_old_nazwisko.Text = reader.GetValue(0).ToString();
                txt_old_imie.Text = reader.GetValue(1).ToString();
                txt_old_pesel.Text = reader.GetValue(2).ToString();
                txt_old_mail.Text = reader.GetValue(3).ToString();
                txt_old_telefon.Text = reader.GetValue(4).ToString();
                txt_old_kraj.Text = reader.GetValue(5).ToString();
                txt_old_city.Text = reader.GetValue(6).ToString();
                txt_old_adress.Text = reader.GetValue(7).ToString();
            }
            conn.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Settings();
                LoadData();
            }

            if (Session["Mail"]==null)
            {
                Response.Redirect("login");
            }
            else
            {

            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["Mail"] = null;
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("login");
        }

        protected void btn_moje_dane_Click(object sender, EventArgs e)
        {
            Settings();
            panel_moje_dane.Visible = true;
        }

        protected void btn_zapisz_dane_Click(object sender, EventArgs e)
        {
            string query = "UPDATE [OzyrysApp].[dbo].[CustomersInformation]  SET [Name] = @name, [Phone]=@phone, [Country]=@kraj,[City]=@miasto,[Adress]=@adres where [Mail]=@mail"; 
            conn = new SqlConnection(connection);
            com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@name", txt_old_nazwisko.Text);
            com.Parameters.AddWithValue("@phone", txt_old_telefon.Text);
            com.Parameters.AddWithValue("@kraj", txt_old_kraj.Text);
            com.Parameters.AddWithValue("@miasto", txt_old_city.Text);
            com.Parameters.AddWithValue("@adres", txt_old_adress.Text);
            com.Parameters.AddWithValue("@mail", Session["Mail"].ToString());
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
            txt_old_nazwisko.Enabled = false;
            txt_old_telefon.Enabled = false;
            txt_old_kraj.Enabled = false;
            txt_old_adress.Enabled = false;
            txt_old_city.Enabled = false;
            panel_moje_dane.Visible = true;
        }

        protected void btn_edytuj_dane_Click(object sender, EventArgs e)
        {
            txt_old_nazwisko.Enabled = true;
            txt_old_telefon.Enabled = true;
            txt_old_kraj.Enabled = true;
            txt_old_adress.Enabled = true;
            txt_old_city.Enabled = true;
            panel_moje_dane.Visible = true;
        }

        protected void btn_kontrahenci_Click(object sender, EventArgs e)
        {
            Settings();
            panel_kontrahenci.Visible = true;
            panel_dgv_kontrahent.Visible = true;
            select_dgv_kontrahent();
        }
        private void select_dgv_kontrahent()
        {
            string query = "SELECT [NIP],[FirmName],[Financing],[FinancingDate] ,[Mail],[Phone] FROM [OzyrysApp].[dbo].[Contractors]";
            conn = new SqlConnection(connection);
            com = new SqlCommand(query, conn);
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                adapter.SelectCommand = com;
                using (DataTable dt = new DataTable())
                {
                    adapter.Fill(dt);
                    dgv_kontrahent.DataSource = dt;
                    dgv_kontrahent.DataBind();
                }
            }
        }

        protected void btn_dodaj_kontrahenta_Click(object sender, EventArgs e)
        {
            panel_dodaj_kh.Visible = true;
            panel_dgv_kontrahent.Visible = true;            
            select_dgv_kontrahent();
        }
        protected void Insert_KH_toBase(object sender, EventArgs e)
        {
            string query = "Insert into [OzyrysApp].[dbo].[Contractors] values ( @nip, @firmname, @financing,@fnancingdate, @mail,@phone, '1',getdate(), 2)";
            conn = new SqlConnection(connection);
            com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("@nip", txt_nip_kh.Text);
            com.Parameters.AddWithValue("@firmname", txt_nazwa_kh.Text);
            com.Parameters.AddWithValue("@financing", txt_finansowanie.Text);
            com.Parameters.AddWithValue("@fnancingdate", txt_koniec_finansowania.Text);
            com.Parameters.AddWithValue("@mail", txt_mail_kh.Text);
            com.Parameters.AddWithValue("@phone", txt_phone_kh.Text);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
            ClearTxTKontrahenci();
            select_dgv_kontrahent();
            
        }
        private void ClearTxTKontrahenci()
        {
            txt_phone_kh.Text = String.Empty;
            txt_mail_kh.Text = String.Empty;
            txt_koniec_finansowania.Text = String.Empty;
            txt_finansowanie.Text = String.Empty;
            txt_nazwa_kh.Text = String.Empty;
            txt_nip_kh.Text = String.Empty;
        }
    }
}