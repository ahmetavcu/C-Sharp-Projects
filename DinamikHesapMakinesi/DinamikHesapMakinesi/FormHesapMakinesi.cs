using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DinamikHesapMakinesi
{
    public partial class FormHesapMakinesi : Form
    {
        public FormHesapMakinesi()
        {
            InitializeComponent();
        }
        GroupBox groupBox = new GroupBox();
        Label labelSonuc = new Label();

        char _operator;
        bool lblsonucsifirla;
        
        int ilksayi;

        private void FormHesapMakinesi_Load(object sender, EventArgs e)
        {
            groupBox.BackColor = Color.Gray;
            groupBox.FlatStyle = FlatStyle.Flat;
            groupBox.Size = new Size(284, 448);
            groupBox.Paint += GroupBox_Paint;

            int sayac = 0;
            int x = 10;
            int y = 90;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (sayac == 0)
                    {
                        Button button = new Button();
                        button.Text = sayac.ToString();
                        button.Location = new Point(65, 300);
                        button.Size = new Size(45, 45);
                        button.Font = new Font("Arial", 15);
                        button.BackColor = Color.FromArgb(99, 184, 255);
                        button.FlatStyle = FlatStyle.Flat;
                        
                        groupBox.Controls.Add(button);



                    }
                    if (sayac > 0 && sayac < 16)
                    {
                        Button button = new Button();
                        button.Text = sayac.ToString();
                        button.Location = new Point(x, y);
                        button.Size = new Size(45, 45);
                        button.Font = new Font("Arial", 15);
                        button.BackColor = Color.FromArgb(99, 184, 255);
                        button.FlatStyle = FlatStyle.Flat;
                        x += 55;

                        if (sayac == 13)
                        {
                            
                            button.Location = new Point(175, 90);
                            button.Text = "+";
                            button.BackColor = Color.FromArgb(255, 193, 37);
                            button.Click += Button_Click5;
                        }
                        if (sayac == 7)
                        {
                            button.Location = new Point(175, 160);
                            button.Text = "-";
                            button.BackColor = Color.FromArgb(255, 193, 37);
                            button.Click += Button_Click4;
                        }
                        if (sayac==8)
                        {
                            button.Location = new Point(10, 230);
                            button.Text = "7";
                            
                        }
                        if (sayac==9)
                        {
                            button.Location = new Point(65, 230);
                            button.Text = "8";
                        }
                        if (sayac==10)
                        {
                            button.Location = new Point(120, 230);
                            button.Text = "9";
                        }
                        if (sayac == 11)
                        {
                            button.Location = new Point(175, 230);
                            button.Text = "x";
                            button.BackColor = Color.FromArgb(255, 193, 37);
                            button.Click += Button_Click3;
                        }
                        if (sayac==12)
                        {
                            button.Location = new Point(10, 300);
                            button.Text = "C";
                            button.BackColor = Color.FromArgb(238, 59, 59);
                            button.Click += Button_Click;
                        }
                        if (sayac==14)
                        {
                            button.Location = new Point(120, 300);
                            button.Text = "=";
                            button.BackColor = Color.FromArgb(255, 193, 37);
                            button.Click += Button_Click1;
                        }
                        if (sayac == 15)
                        {
                            button.Location = new Point(175, 300);
                            button.Text = "/";
                            button.BackColor = Color.FromArgb(255, 193, 37);
                            button.Click += Button_Click2;
                        }
                        groupBox.Controls.Add(button);
                    }
                    sayac++;

                }
                x = 10;
                y += 70;

            }
            foreach (var item in groupBox.Controls)
            {
                if (item.GetType()==typeof(Button))
                {
                    Button button = (Button)(item);
                    button.Click += Button_Click6;
                }
            }

            labelSonuc.Location = new Point(9, 12); //Label özellikleri(boyut konumlandırma vb...)
            labelSonuc.Size = new Size(220, 66);
            labelSonuc.TextAlign = ContentAlignment.MiddleRight;
            labelSonuc.Font = new Font("Arial", 30);
            labelSonuc.Text = "0";
            labelSonuc.BackColor = Color.Gray;
            labelSonuc.BorderStyle = BorderStyle.FixedSingle;
            labelSonuc.FlatStyle = FlatStyle.Flat;
            labelSonuc.Paint += LabelSonuc_Paint; //Label kenarlığının dizaynı için paint eventi


            groupBox.Controls.Add(labelSonuc);
            Controls.Add(groupBox);
        }
        private void Button_Click1(object sender, EventArgs e)
        {
            //Sonuç Butonu
            int ikincisayi = Convert.ToInt32(labelSonuc.Text);
            int sonuc = 0;
            switch (_operator) //işlemlerin yapıldığı switch case
            {
                case '+':
                    sonuc = ilksayi + ikincisayi;
                    break;
                case '-':
                    sonuc = ilksayi - ikincisayi;
                    break;
                case 'X':
                    sonuc = ilksayi * ikincisayi;
                    break;
                case '/':
                    sonuc = ilksayi / ikincisayi;
                    break;

            }
            labelSonuc.Text = Convert.ToString(sonuc);
        }
       

        private void Button_Click5(object sender, EventArgs e)
        {
            Button button = (Button)(sender);
            //Toplama işlemi
            _operator = '+';
            lblsonucsifirla = true;      
            ilksayi = Convert.ToInt32(labelSonuc.Text);
        }

        private void Button_Click4(object sender, EventArgs e)
        {
            _operator = '-';
            lblsonucsifirla = true;
            ilksayi = Convert.ToInt32(labelSonuc.Text);
        }

        private void Button_Click3(object sender, EventArgs e)
        {
            //Çarpma işlemi
            _operator = 'x';
            lblsonucsifirla = true;
            ilksayi = Convert.ToInt32(labelSonuc.Text);
        }

        private void Button_Click2(object sender, EventArgs e)
        {
            //Bölme işlemi
            _operator = '/';
            lblsonucsifirla = true;
            ilksayi = Convert.ToInt32(labelSonuc.Text); //ilk sayıyı hafızada tutuyoruz.
        }

        private void Button_Click6(object sender, EventArgs e)
        {
            //Sayılara tıklandığında

            Button button = (Button)(sender);
            foreach (var item in groupBox.Controls)
            {
                if (item.GetType() == typeof(Label))
                {
                    Label labelSonuc = (Label)(item);
                    
                    if (lblsonucsifirla == true)
                    {
                        labelSonuc.Text = "";
                        lblsonucsifirla = false;
                        
                    }
                    if (labelSonuc.Text == "0")
                    {
                        labelSonuc.Text = "";
                    }
                    labelSonuc.Text += button.Text;
                   
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            //Sıfırlama Butonu
            labelSonuc.Text = "0";
        }

        private void GroupBox_Paint(object sender, PaintEventArgs e)
        {
            //Groupbox kenarlığını kaldırmak.
            Graphics gfx = e.Graphics;
            var pp = sender as GroupBox;
            gfx.Clear(pp.BackColor);
            gfx.DrawString(pp.Text, pp.Font, new SolidBrush(pp.ForeColor), new PointF(7, 0));
        }

        private void LabelSonuc_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, labelSonuc.DisplayRectangle, Color.Black, ButtonBorderStyle.Solid); //Label kenarlığını siyah yapmak
        }
    }
}
