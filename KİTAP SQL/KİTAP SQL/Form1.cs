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
namespace KİTAP_SQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I9SKVGB\\VT_SQL;Initial Catalog=KÜTÜPHANE;Integrated Security=True");
        private void goruntule() {
            listView2.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from KİTAPLAR2", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read()){
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["KitapAdı"].ToString());
                ekle.SubItems.Add(oku["Yazar"].ToString());
                ekle.SubItems.Add(oku["YayınEvi"].ToString());
                ekle.SubItems.Add(oku["SayfaSayısı"].ToString());
                listView2.Items.Add(ekle);

            }
            baglanti.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            goruntule();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut=new SqlCommand("insert into  KİTAPLAR2 (id,KitapAdı,Yazar,YayınEvi,SayfaSayısı)  values ('"+textBox1.Text.ToString()+"','"+textBox2.Text.ToString()+"','"+textBox3.Text.ToString()+"','"+ textBox4.Text.ToString() + "','" + textBox5.Text.ToString()+"')",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            goruntule();
            textBox1.Clear();
            textBox2.Clear();

            textBox3.Clear();

            textBox4.Clear();
            textBox5.Clear();



        }
       int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from KİTAPLAR2 where id =("+ id +")", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            goruntule();

        }

       

        private void listView2_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView2.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView2.SelectedItems[0].SubItems[1].Text;

            textBox3.Text = listView2.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView2.SelectedItems[0].SubItems[3].Text;
            textBox5.Text = listView2.SelectedItems[0].SubItems[4].Text;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(" update KİTAPLAR2 set id='" + textBox1.Text.ToString() + "',KitapAdı='" + textBox2.Text.ToString() + "',Yazar='" + textBox3.Text.ToString()+ "',YayınEvi='" + textBox4.Text.ToString()+ "',SayfaSayısı='" + textBox5.Text.ToString()+"' where id=" +id +"", baglanti);
            komut.ExecuteNonQuery();

            baglanti.Close();
            goruntule();
            textBox1.Clear();
            textBox2.Clear();

            textBox3.Clear();

            textBox4.Clear();
            textBox5.Clear();
        }

        
    }
}
