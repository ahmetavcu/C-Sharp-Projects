using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DinamikSayiTahminOyunu
{
    public partial class FormSayiTahminOyunu : Form
    {
        public FormSayiTahminOyunu()
        {
            InitializeComponent();
        }


        Label labelBaslik = new Label();
        Label labelAralik = new Label();
        Label labelTahmin = new Label();
        Label labelSkor = new Label();
        Label labelSkorBilgi = new Label();
        Label labelEnYuksekSkor = new Label();
        Label labelEnYuksekSkorBilgi = new Label();

        TextBox textBoxAralikAyarla = new TextBox();
        TextBox textBoxTahmin = new TextBox();

        Button buttonAyarla = new Button();
        Button buttonTahminEt = new Button();
        Button buttonBaslat = new Button();
        Button buttonBitir = new Button();

        ListBox listBox = new ListBox();

        int skor = 100;
        int enyuksekskor = 0;
        int aralik;
        int tutulansayi;
        int tahminim;
        int tahminsayaci = 0;
        private void FormSayiTahminOyunu_Load(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
            //Projeyi başlatınca textbox ve butonların devre dışı bırakılması
            textBoxAralikAyarla.Enabled = false;
            buttonAyarla.Enabled = false;

            textBoxTahmin.Enabled = false;
            buttonTahminEt.Enabled = false;

            buttonBitir.Enabled = false;
            listBox.Items.Add("Oyunu başlatmak için başlat tuşuna basınız.");
            listBox.Font = new Font("x",9);


            //1.satır
            
            labelBaslik.Text = "SAYI TAHMİN OYUNU";
            labelBaslik.Size = new Size(200, 20);
            labelBaslik.Location = new Point(175,20);
            labelBaslik.AutoSize = true;
            labelBaslik.ForeColor = Color.White;
            labelBaslik.BackColor = Color.Transparent;
            labelBaslik.Font = new Font("Century Gothic",25);

            
            labelAralik.Text = "Aralık Belirt(0 - x):";
            labelAralik.Size = new Size(200,20);
            labelAralik.Location = new Point(200,80);
            labelAralik.BackColor = Color.Transparent;
            labelAralik.ForeColor = Color.White;
            labelAralik.Font = new Font("Century Gothic", 13);


            
            textBoxAralikAyarla.Size = new Size(75,22);
            textBoxAralikAyarla.Multiline = true;
            textBoxAralikAyarla.Location = new Point(350,81);

            
            buttonAyarla.Text = "Ayarla";
            buttonAyarla.Location = new Point(430,81);
            buttonAyarla.BackColor = Color.White;
            buttonAyarla.FlatStyle = FlatStyle.Flat;
            buttonAyarla.FlatAppearance.BorderSize = 0;
            buttonAyarla.Size = new Size(70,21);
            buttonAyarla.Click += ButtonAyarla_Click;
            
            //2.satır
            
            labelTahmin.Text = "Tahmininiz:";
            labelTahmin.Size = new Size(200,20);
            labelTahmin.Location = new Point(253,110);
            labelTahmin.BackColor = Color.Transparent;
            labelTahmin.ForeColor = Color.White;
            labelTahmin.Font = new Font("Century Gothic", 13);


            
            textBoxTahmin.Size = new Size(75,22);
            textBoxTahmin.Multiline = true;
            textBoxTahmin.Location = new Point(350,111);

            
            buttonTahminEt.Text = "Tahmin Et";
            buttonTahminEt.Location = new Point(430,111);
            buttonTahminEt.BackColor = Color.White;
            buttonTahminEt.FlatStyle = FlatStyle.Flat;
            buttonTahminEt.FlatAppearance.BorderSize = 0;
            buttonTahminEt.Size = new Size(70,21);
            buttonTahminEt.Click += ButtonTahminEt_Click;


            //3.satır
            
            labelSkor.Text = "Skor:";
            labelSkor.Location = new Point(260,150);
            labelSkor.BackColor = Color.Transparent;
            labelSkor.ForeColor = Color.White;
            //labelSkor.AutoSize = true;
            labelSkor.Size = new Size(65, 25);
            labelSkor.Font = new Font("Century Gothic", 16);

            
            labelSkorBilgi.Text = "";
            labelSkorBilgi.Location = new Point(320, 151);
            labelSkorBilgi.BackColor = Color.Transparent;
            labelSkorBilgi.ForeColor = Color.White;
            labelSkorBilgi.AutoSize = true;
            labelSkorBilgi.Font = new Font("Century Gothic", 16);

            //4.satır listbox
            
            listBox.Location = new Point(200,200);
            listBox.Size = new Size(300,250);


            //5.satır baslat bitir butonları
            
            buttonBaslat.Text = "Başlat";
            buttonBaslat.Location = new Point(201,445);
            buttonBaslat.FlatStyle = FlatStyle.Flat;
            buttonBaslat.FlatAppearance.BorderSize = 0;
            buttonBaslat.BackColor = Color.White;
            buttonBaslat.Click += ButtonBaslat_Click;

            
            buttonBitir.Text = "Bitir";
            buttonBitir.Location = new Point(423, 445);
            buttonBitir.FlatStyle = FlatStyle.Flat;
            buttonBitir.FlatAppearance.BorderSize = 0;
            buttonBitir.BackColor = Color.White;
            buttonBitir.Click += ButtonBitir_Click;

            //6.satır en yuksek skor
            
            labelEnYuksekSkor.Text = "En Yüksek Skor:";
            labelEnYuksekSkor.Location = new Point(10,500);
            labelEnYuksekSkor.BackColor = Color.Transparent;
            labelEnYuksekSkor.ForeColor = Color.White;
            labelEnYuksekSkor.Font = new Font("Century Gothic", 13);
            labelEnYuksekSkor.Size = new Size(150,20);

            
            labelEnYuksekSkorBilgi.Text = "";
            labelEnYuksekSkorBilgi.Location = new Point(155, 500);
            labelEnYuksekSkorBilgi.BackColor = Color.Transparent;
            labelEnYuksekSkorBilgi.ForeColor = Color.White;
            labelEnYuksekSkorBilgi.Font = new Font("Century Gothic", 13);
            


            pictureBox1.Controls.Add(buttonBitir);
            pictureBox1.Controls.Add(buttonBaslat);
            pictureBox1.Controls.Add(listBox);
            pictureBox1.Controls.Add(textBoxAralikAyarla);
            pictureBox1.Controls.Add(textBoxTahmin);
            pictureBox1.Controls.Add(buttonTahminEt);
            pictureBox1.Controls.Add(buttonAyarla);
            pictureBox1.Controls.Add(labelTahmin);
            pictureBox1.Controls.Add(labelEnYuksekSkor);
            pictureBox1.Controls.Add(labelEnYuksekSkorBilgi);
            pictureBox1.Controls.Add(labelAralik);
            pictureBox1.Controls.Add(labelBaslik);
            pictureBox1.Controls.Add(labelSkor);
            pictureBox1.Controls.Add(labelSkorBilgi);
        }

        private void ButtonTahminEt_Click(object sender, EventArgs e)
        {
            bool succes2 = true;
            try
            {
                tahminim = int.Parse(textBoxTahmin.Text);
            }
            catch (FormatException hata1)
            {

                MessageBox.Show("Lütfen tam sayı türünde bir değer giriniz");
                succes2 = false;
            }
            if (succes2)
            {
                tahminsayaci++;
                if (tahminim>tutulansayi)
                {
                    listBox.Items.Add("Büyük bir sayı girdiniz, daha küçük bir sayı giriniz.");
                    skor -= 10;
                    labelSkorBilgi.Text = skor.ToString();
                }
                else if (skor<20)
                {
                    labelSkorBilgi.Text = "0";
                    listBox.Items.Add("Kaybettin!");
                    listBox.Items.Add("Tekrar oynamak için başlat tuşuna basınız");

                    buttonAyarla.Enabled = false;
                    textBoxAralikAyarla.Enabled = false;
                    buttonTahminEt.Enabled = false;
                    textBoxTahmin.Enabled = false;


                }
                else if (tahminim<tutulansayi)
                {
                    listBox.Items.Add("Küçük bir sayı girdiniz, daha büyük bir sayı giriniz.");
                    skor -= 10;
                    labelSkorBilgi.Text = skor.ToString();
                }
                
                else
                {
                    listBox.Items.Add($"Tebrikler,{tahminsayaci} adımda bildiniz, skorunuz {skor} ");
                    buttonTahminEt.Enabled = false;
                    textBoxTahmin.Enabled = false;
                    buttonAyarla.Enabled = true;
                    textBoxAralikAyarla.Enabled = true;

                    if (skor > enyuksekskor)
                    {
                        enyuksekskor = skor;
                        labelEnYuksekSkorBilgi.Text = skor.ToString();
                    }
                    else if (skor < enyuksekskor)
                    {
                        labelEnYuksekSkorBilgi.Text = labelEnYuksekSkorBilgi.Text;
                    }
                    
                }
            }
        }

        private void ButtonAyarla_Click(object sender, EventArgs e)
        {
            skor = 100;
            tahminsayaci = 0;
            bool succes1 = true;
            try
            {
                aralik = Convert.ToInt32(textBoxAralikAyarla.Text);
            }
            catch(FormatException hata1)
            {
                MessageBox.Show("Lütfen tam sayı türünde bir değer giriniz");
                succes1 = false;
            }
            if (succes1)
            {
                labelSkorBilgi.Text = skor.ToString();

                listBox.Items.Add("Aralık belirtildi, unutma skorun 0 olursa kaybedersin.");
                textBoxTahmin.Enabled = true;
                buttonTahminEt.Enabled = true;
                textBoxAralikAyarla.Enabled = false;

                buttonAyarla.Enabled = false;
                Random random = new Random();
                tutulansayi = random.Next(0, aralik);
            }
        }

        private void ButtonBitir_Click(object sender, EventArgs e)
        {
            
            listBox.Items.Add("Oyun Bitti");

            buttonTahminEt.Enabled = false;
            textBoxTahmin.Enabled = false;

            buttonAyarla.Enabled = false;
            textBoxAralikAyarla.Enabled = false;

            enyuksekskor = 0;
            labelEnYuksekSkorBilgi.Text = "";
        }

        private void ButtonBaslat_Click(object sender, EventArgs e)
        {
            tahminsayaci = 0;
            listBox.Items.Clear();
            textBoxAralikAyarla.Enabled = true;
            buttonAyarla.Enabled = true;
            buttonBitir.Enabled = true;

            listBox.Items.Add("Tam sayı değerinde bir aralık belirtiniz.");
            skor = 100;
            labelSkorBilgi.Text = skor.ToString();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Çıkmak istediğinize emin misiniz?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (cevap==DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
