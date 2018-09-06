using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;


namespace Grafik
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da1;
        public static DataTable dt1;
        public Ayrintilar frm;
        public static string yazi;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                groupBox2.Hide();
                veri_getir();
                chart1.Series["TUTAR"].LabelAngle = 90;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void veri_getir()
        {
            try
            {
                con = new SqlConnection("Server=YPSSQL;Database=YEPSAN_2017;uid=********;pwd=********");
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                //HESAPLAMA YAPILIYOR İSE UYARI VERİYOR.
                string kontrol = "";
                SqlCommand cmd = new SqlCommand("select D_TEXT from CUSTOM WHERE KOD = '!K1' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    // Eğer veritabanında girdiğimiz şifre var ise bilgilerini değişkenlere atadık..
                    kontrol = dr["D_TEXT"].ToString();

                }
                dr.Close();
                cmd.Dispose();
                kontrol = kontrol.Trim();
                if (kontrol == "E")
                {
                    MessageBox.Show("Son Dönem Verileri Hesaplanıyor. Bazı Son Dönem Değerleri Eksik Görünebilir. Bir Süre Sonra Tekrar Deneyiniz.");
                }

                //############################################## 1-MAMUL

                da1 = new SqlDataAdapter("SELECT DISTINCT AY, TUTAR FROM _MMSTOK where KOD='TOPLAM' ORDER BY AY", con);
                dt1 = new DataTable();
                da1.Fill(dt1);

                chart1.DataSource = dt1;
                chart1.DataBind();


                //########################################## 2-HAMMADDE

                da1 = new SqlDataAdapter("SELECT DISTINCT AY, TUTAR FROM _HMSTOK where KOD='TOPLAM' ORDER BY AY", con);
                dt1 = new DataTable();
                da1.Fill(dt1);

                chart2.DataSource = dt1;
                chart2.DataBind();

                //########################################## 3-YARIMAMUL

                da1 = new SqlDataAdapter("SELECT DISTINCT AY, TUTAR FROM _YMSTOK  where KOD='TOPLAM' ORDER BY AY", con);
                dt1 = new DataTable();
                da1.Fill(dt1);

                chart3.DataSource = dt1;
                chart3.DataBind();

                //########################################## 4-MAMUL SATIŞ

                da1 = new SqlDataAdapter("SELECT DISTINCT AY, TUTAR FROM _MMSATIS  where KOD='TOPLAM' ORDER BY AY", con);
                dt1 = new DataTable();
                da1.Fill(dt1);

                chart4.DataSource = dt1;
                chart4.DataBind();

                //########################################## 5-İÇ ISKARTA

                da1 = new SqlDataAdapter("SELECT DISTINCT AY, TUTAR FROM _FIRE  where KOD='TOPLAM' ORDER BY AY", con);
                dt1 = new DataTable();
                da1.Fill(dt1);

                chart5.DataSource = dt1;
                chart5.DataBind();

                //########################################## 6-YARDIMCI MALZEME

                da1 = new SqlDataAdapter("SELECT DISTINCT AY, TUTAR FROM _SMSTOK  where KOD='TOPLAM' ORDER BY AY", con);
                dt1 = new DataTable();
                da1.Fill(dt1);

                chart6.DataSource = dt1;
                chart6.DataBind();

                //########################################## 7- UZMAN-AKAL

                da1 = new SqlDataAdapter("SELECT DISTINCT AY, TUTAR FROM _FASON  where KOD='TOPLAM1' ORDER BY AY", con);
                dt1 = new DataTable();
                da1.Fill(dt1);

                chart7.DataSource = dt1;
                chart7.DataBind();

                //########################################## 8- 10-12

                da1 = new SqlDataAdapter("SELECT DISTINCT AY, TUTAR FROM _FASON   where KOD='TOPLAM2' ORDER BY AY", con);
                dt1 = new DataTable();
                da1.Fill(dt1);

                chart8.DataSource = dt1;
                chart8.DataBind();

                //########################################## 9- 12-18

                da1 = new SqlDataAdapter("SELECT DISTINCT AY, TUTAR FROM _FASON  where KOD='TOPLAM3' ORDER BY AY", con);
                dt1 = new DataTable();
                da1.Fill(dt1);

                chart9.DataSource = dt1;
                chart9.DataBind();

                //########################################## 10- YARI MAMUL ALIM

                da1 = new SqlDataAdapter("SELECT DISTINCT AY, TUTAR as TUTAR FROM _YMALIM where KOD='TOPLAM' ORDER BY AY", con);
                dt1 = new DataTable();
                da1.Fill(dt1);
                
                chart10.DataSource = dt1;
                chart10.DataBind();

                //########################################## 11- SAC SATIŞ

                da1 = new SqlDataAdapter("SELECT DISTINCT AY, TUTAR as TUTAR FROM _SCSATIS where KOD='TOPLAM'  ORDER BY AY ", con);
                dt1 = new DataTable();
                da1.Fill(dt1);

                chart11.DataSource = dt1;
                chart11.DataBind();

                con.Close();
                
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                yazi = "MAMUL DEPO(TL)";
                da1 = new SqlDataAdapter("select * from _MMSTOK  order by KOD, AY, TARIH", con);
                dt1 = new DataTable();
                da1.Fill(dt1);
                frm = new Ayrintilar();
                frm.Show();
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                yazi = "HAMMADDE DEPO(TL)";
                da1 = new SqlDataAdapter("select * from _HMSTOK order by KOD, AY, TARIH", con);
                dt1 = new DataTable();
                da1.Fill(dt1);
                frm = new Ayrintilar();
                frm.Show();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                yazi = "YARIMAMUL DEPO(TL)";
                da1 = new SqlDataAdapter("select * from _YMSTOK  order by KOD, AY, TARIH", con);
                dt1 = new DataTable();
                da1.Fill(dt1);
                frm = new Ayrintilar();
                frm.Show();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                yazi = "MAMUL SATIŞ (TL)";
                da1 = new SqlDataAdapter("select * from _MMSATIS  order by KOD, AY, TARIH", con);
                dt1 = new DataTable();
                da1.Fill(dt1);
                frm = new Ayrintilar();
                frm.Show();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                yazi = "İÇ ISKARTA MALİYET (TL)";
                da1 = new SqlDataAdapter("select * from _FIRE  order by KOD, AY, TARIH", con);
                dt1 = new DataTable();
                da1.Fill(dt1);
                frm = new Ayrintilar();
                frm.Show();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                yazi = "YARDIMCI MALZ. (TL)";
                da1 = new SqlDataAdapter("select * from _SMSTOK  order by KOD, AY, TARIH", con);
                dt1 = new DataTable();
                da1.Fill(dt1);
                frm = new Ayrintilar();
                frm.Show();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                yazi = "KAPLAMA (TL)";
                da1 = new SqlDataAdapter("select * from _FASON  order by KOD, AY, TARIH", con);
                dt1 = new DataTable();
                da1.Fill(dt1);
                frm = new Ayrintilar();
                frm.Show();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                yazi = "SAÇ ALIMI(TL)";
                da1 = new SqlDataAdapter("select * from _FASON   order by KOD, AY, TARIH", con);
                dt1 = new DataTable();
                da1.Fill(dt1);
                frm = new Ayrintilar();
                frm.Show();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                yazi = "YARDIMCI MALZEME ALIMI(TL)";
                da1 = new SqlDataAdapter("select * from _FASON  order by KOD, AY, TARIH", con);
                dt1 = new DataTable();
                da1.Fill(dt1);
                frm = new Ayrintilar();
                frm.Show();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                yazi = "YARI MAMÜL ALIM(TL)";
                da1 = new SqlDataAdapter("select * from _YMALIM  order by KOD, AY, TARIH", con);
                dt1 = new DataTable();
                da1.Fill(dt1);
                frm = new Ayrintilar();
                frm.Show();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                yazi = "SAC SATIŞ(TL)";
                da1 = new SqlDataAdapter("select * from  _SCSATIS order by KOD, AY, TARIH", con);
                dt1 = new DataTable();
                da1.Fill(dt1);
                frm = new Ayrintilar();
                frm.Show();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            groupBox2.Hide();
            groupBox1.Show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {

        }
    }
}
