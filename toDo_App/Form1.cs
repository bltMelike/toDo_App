using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toDo_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ArrayList gorevKutulari = new ArrayList();
        ArrayList tarihler = new ArrayList();
        int sayac = 0;
        String text;
        DateTime tarih;
        int tarihSimdi = DateTime.Now.DayOfYear;
        int kalanSure;
        int seciliIndex;
        public void satirEkle(String text, String tarih,int kalanSure)
        {
            sayac++;
            CheckBox checkBox = new CheckBox();

            checkBox.Name = "ChechkBox" + sayac;
            checkBox.Text = text + " / " + tarih + " / Bitişe kalan: " + kalanSure + " gün";
            checkBox.Checked = false;
            checkBox.AutoSize = true;
            gorevKutulari.Add(checkBox);
            tarihler.Add(tarih);
        }
        public void goruntule()
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < gorevKutulari.Count; i++)
            {

                flowLayoutPanel1.Controls.Add((CheckBox)gorevKutulari[i]);
            }
        }

        private void ekleButon_Click(object sender, EventArgs e)
        {
            text = textBox1.Text;
            tarih = monthCalendar1.SelectionStart.Date;
            String tarih2= monthCalendar1.SelectionStart.ToString("d");
            
            kalanSure = tarih.DayOfYear - tarihSimdi;

            if (text != "" && kalanSure >= 0)
            {
                satirEkle(text, tarih2,kalanSure);
                goruntule();
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("!!!Lütfen girilen bilgileri kontrol ediniz!!!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void kilavuzButon_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            tabControl1.Visible = false;
        }

        private void silButon_Click(object sender, EventArgs e)
        {
            for (int i = gorevKutulari.Count - 1; i >= 0; i--)
            {
                CheckBox checkBox_Yedek = new CheckBox();
                checkBox_Yedek = (CheckBox)gorevKutulari[i];
                if (checkBox_Yedek.Checked == true)
                {
                    gorevKutulari.RemoveAt(i);
                }
            }
            goruntule();
        }

        private void guncelleButon_Click(object sender, EventArgs e)
        {
            int sayacKontrol = 0;
            CheckBox checkBox_Yedek = new CheckBox();


            for (int i = gorevKutulari.Count - 1; i >= 0; i--)
            {
                checkBox_Yedek = (CheckBox)gorevKutulari[i];
                if (checkBox_Yedek.Checked == true)
                {
                    sayacKontrol++;

                }
                if (sayacKontrol == 1)
                {
                    seciliIndex = i;
                }
                else
                {
                    seciliIndex = -1;
                }
            }
            if (sayacKontrol > 1)
            {
                MessageBox.Show("!!!Sadece 1 tane seçebilirsiniz!!!");
            }
            if (sayacKontrol == 0)
            {
                MessageBox.Show("!!!Seçim yapın!!!");
            }
            else
            {
                textBox3.Visible = true;
                label1.Visible = true;
                bitirButon.Visible = true;
                flowLayoutPanel1.Enabled = false;
                silButon.Enabled = false;
                monthCalendar2.Visible = true;
            }
            textBox3.Text = "";
        }

        private void bitirButon_Click(object sender, EventArgs e)
        {
            CheckBox checkBox_Yedek = new CheckBox();
            checkBox_Yedek = (CheckBox)gorevKutulari[seciliIndex];

            text = textBox3.Text;
            tarih = monthCalendar2.SelectionStart.Date;
            String tarih2 = monthCalendar2.SelectionStart.ToString("d");
            kalanSure = tarih.DayOfYear - tarihSimdi;
            
            
            if (text != "" && kalanSure >= 0)
            {
                checkBox_Yedek.Text = text + " / " + tarih2 + " / Bitişe kalan: " + kalanSure + " gün";
                goruntule();
                checkBox_Yedek.Checked = false;
                textBox3.Visible = false;
                label1.Visible = false;
                monthCalendar2.Visible = false;
                bitirButon.Visible = false;
                flowLayoutPanel1.Enabled = true;
                silButon.Enabled = true;
                guncelleButon.Enabled = true;
            }
            else
            {
                MessageBox.Show("!!!Lütfen sadece birini değiştirecek olsanız bile iki parametreyi de giriniz!!!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("!!!Girilen bilgileri kontrol ediniz!!!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Hoşgeldiniz...\nUygulamamızı ilk defa mı kullanıyorsunuz?", "Mesaj", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                groupBox1.Visible = true;
                tabControl1.Visible = false;

            }
            else if (cevap == DialogResult.No)
            {
                groupBox1.Visible = false;
                tabControl1.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            tabControl1.Visible = true;
        }
    }
}
