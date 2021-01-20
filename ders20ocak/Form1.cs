using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ders20ocak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Server=NB-2CEA7F20A15A;Initial Catalog=tarihgece;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            int sayi=listBox1.SelectedItems.Count;
            for (int i = 0; i < sayi; i++)
            {
                listBox2.Items.Add(listBox1.SelectedItems[0]);
                listBox1.Items.Remove(listBox1.SelectedItems[0]);
            }

            
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox2.SelectionMode = SelectionMode.MultiSimple;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sayi = listBox2.SelectedItems.Count;
            for(int i=0;i<sayi;i++)
            {
                listBox1.Items.Add(listBox2.SelectedItems[0]);
                listBox2.Items.Remove(listBox2.SelectedItems[0]);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = dateTimePicker1.Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string kad, ksoyad, ktarih;
            kad = textBox1.Text;
            ksoyad = textBox2.Text;
            ktarih = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            baglanti.Open();
            SqlCommand gonder = new SqlCommand("Insert Into kayit (kullanici_adi,kullanici_soyadi,tarih) values ('"+kad+ "','" + ksoyad + "','" + ktarih + "')", baglanti);
            gonder.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string gad, gsoyad, gtarih;
            gad = textBox4.Text;
            gsoyad = textBox3.Text;
            baglanti.Open();
            SqlCommand getir = new SqlCommand(" Select * From kayit Where kullanici_adi='"+gad+ "'or kullanici_soyadi='" + gsoyad + "' ", baglanti);
            SqlDataReader oku =getir.ExecuteReader();
            if(oku.Read())
            {
                textBox4.Text = oku[1].ToString();
                textBox3.Text = oku[2].ToString();
                dateTimePicker2.Value =Convert.ToDateTime( oku[3]);

            }
            
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker2.Value = DateTime.Now;
        }
    }
}
