/*
  Copyright @2019 Ahmad Aufar Husaini
  This is a program purposed to read any error trigger from PLC and send whatsapp message
  to listed contacts that chosen. In this source code, you *can* change custom message. For
  actual application, you must set your PLC connection with PC by Ethernet and setting *axcopc1*
  toolbox on Design tab.
  */

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
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        ArrayList kontaks = new ArrayList();
        DataTable d = new DataTable();
        int i = 3, waktu = 0;
        IWebDriver driver;
        int on;
        Stopwatch dt = new Stopwatch();
        string pin1, pin2, message;
        string spin1, spin2; //spin adalah template untuk message

        private void SendMessage(string number, string message)
        {
            IWebElement searchbox= driver.FindElement(By.ClassName("_2zCfw")); //cari kotak search
            searchbox.Clear(); //bersihkan dulu
            searchbox.SendKeys(number); //dummy dulu, cari yahya
            System.Threading.Thread.Sleep(2000); //wait for 2 seconds
                driver.FindElement(By.XPath("//*[@title='" + number + "']")).Click();

                IWebElement inputmsg = driver.FindElement(By.ClassName("_3u328"));
                inputmsg.SendKeys(message);
                driver.FindElement(By.CssSelector("button._3M-N->span")).Click();
        }

        public void run()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://web.whatsapp.com");
            on = 1;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            d.Columns.Add("Nomor Telepon");
            dataGridView1.DataSource = d;
            try
            {
                axcopc1.cnnec();
            }

            catch (Exception err)
            {

            }     
        }

        private void send_Click(object sender, EventArgs e)
        {
            /*int j = 0;
            string a;
            for (; j <= i; j++)
            {
                //a = d.;
                SendMessage(a, pesan.Text);
            }*/
            int j = 0;
            for (j = 0; j < kontaks.Count; j++)
            {
                SendMessage( (string)kontaks[j], pesan.Text);
            }

            //SendMessage(nomor.Text, pesan.Text);

        }

        private void open_Click(object sender, EventArgs e)
        {
            run();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                axcopc1.discnn();
            }

            catch (Exception err)
            {

            }
        }

        private void axcopc1_datChange(object sender, EventArgs e)
        {
            msg.Text = axcopc1.GetVl(0).ToString(); //indexnya urutan tag keberapa
            msg2.Text = axcopc1.GetVl(1).ToString();
            pin1 = axcopc1.GetVl(0).ToString(); //buat cek nyala-mati, harusnya boolean saja
            pin2 = axcopc1.GetVl(1).ToString();

            if (pin1 == "True") { spin1 = "PIN 1 rusak"; } else spin1 = "";
            if (pin2 == "True") { spin2 = "PIN 2 rusak"; } else spin2 = "";
            message = "Lapor:" + spin1 + " dan " + spin2 + ", selesai.";

            if (on == 1 && (pin1 == "True" || pin2 == "True") && waktu==0)
            {
                timer1.Start(); //start counting
                SendMessage((string)kontaks[0], message); //kontak 0 prioritit
            }
        }

        private void msg_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            waktu++;
            //label2.Text = waktu.ToString();

            msg.Text = axcopc1.GetVl(0).ToString(); //indexnya urutan tag keberapa
            msg2.Text = axcopc1.GetVl(1).ToString();
            pin1 = axcopc1.GetVl(0).ToString(); //buat cek nyala-mati, harusnya boolean saja
            pin2 = axcopc1.GetVl(1).ToString();

            if (pin1 == "True") { spin1 = "PIN 1 rusak"; } else spin1 = "";
            if (pin2 == "True") { spin2 = "PIN 2 rusak"; } else spin2 = "";
            message = "Lapor:" + spin1 + " dan " + spin2 + ", selesai.";

            if (waktu == 10 && on == 1 && (pin1 == "True" || pin2 == "True"))
            {
                SendMessage((string)kontaks[1], message);
            }
            else if (waktu == 20 && on == 1 && (pin1 == "True" || pin2 == "True"))
            {
                SendMessage((string)kontaks[2], message);
                timer1.Stop();
                waktu = 0;
            }
            else if (pin1 == "False" && pin2 == "False")
            {
                timer1.Stop();
                waktu = 0;
            }
        }

        private void nomor_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            kontaks.Add(nomor.Text);
            d.Rows.Add (nomor.Text);
            dataGridView1.DataSource = d;
            i++;
        }
    }
}
