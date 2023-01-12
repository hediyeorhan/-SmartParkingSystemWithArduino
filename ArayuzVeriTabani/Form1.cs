using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace baglanti
{
    public partial class Form1 : Form
    {
        string data;
        string[] portlar = SerialPort.GetPortNames();
        int aracsayisi = 0;
        
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection veritabani = new SqlConnection(@"Data Source = HEDIYEORHAN; Initial Catalog = akilliotoparksistemi; Integrated Security = True");
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string port in portlar)
            {
                comboBox1.Items.Add(port);
                comboBox1.SelectedIndex = 0;
            }
            label1.Text = "Bağlantı Kapalı !";
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.Open();
                button1.Enabled = false;
                button2.Enabled = true;
                label1.Text = "Bağlantı Sağlandı";
                label1.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                label1.Text = "Bağlantı Kesildi";
                label1.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            serialPort1.Write("1");
            aracsayisi++;
            label6.Text = aracsayisi.ToString();
            if(aracsayisi >= 3)
            {
                label7.Text = "1.Kat Doldu. Aydınlatma ve Havalandırma Çalışıyor..";
                label7.ForeColor = Color.Blue;
            }
            if(aracsayisi >= 6)
            {
                label9.ForeColor = Color.Red;
                label9.Text = "!OTOPARK DOLU";
                button3.Enabled = false;
                label8.Text = "2.Kat Doldu. Aydınlatma ve Havalandırma Çalışıyor..";
                label8.ForeColor = Color.Blue;

            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(displaydata));

        }

        private void displaydata(object sender, EventArgs e)
        {
            DateTime tarih_saat = DateTime.Now;
            string[] value = data.Split('-');
            label4.Text = value[0];
            veritabani.Open();
            SqlCommand ekle = new SqlCommand("insert into aracsayisi_sensor(DumanSensorDegeri, Tarih, ToplamAracSayisi) values('" + Convert.ToInt32(value[0]) + "', '" + tarih_saat.ToString() + "', '" + aracsayisi + "')", veritabani);
            ekle.ExecuteNonQuery();
            veritabani.Close();
            if (Convert.ToInt32(value[0]) > 50)
            {
                label4.ForeColor = Color.Red;
                MessageBox.Show("DİKKAT! OKSİJEN SEVİYESİ DÜŞÜK", "UYARI");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.Write("0");
            aracsayisi--;
            label6.Text = aracsayisi.ToString();
            if (aracsayisi < 3)
            {
                label7.Text = "";
            }
            if (aracsayisi < 6)
            {
                label9.Text = "";
                label8.Text = "";
                button3.Enabled = true;
            }
            if(aracsayisi == 0)
            {
                button4.Enabled = false;
            }
            else
            {
                button4.Enabled = true;
            }
        }
    }
}
