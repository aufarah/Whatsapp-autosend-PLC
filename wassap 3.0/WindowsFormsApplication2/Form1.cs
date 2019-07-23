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
        int waktu = 0;
        int i, j = 2;
        IWebDriver driver;
        int on, int1x, int2x, int3x;
        Stopwatch dt = new Stopwatch();
        string pin1, pin2, message;
        string spin1, spin2; //spin adalah template untuk message
        List<pin> himpunan = new List<pin>();

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
            try
            {
                axcopc1.cnnec();
                for (i = 0; i < j; i++)
                {
                    himpunan.Add(new pin()); //therefore there'll be 2 pins
                    himpunan[i].statepin = "hehe";
                    himpunan[i].downtime = -1;
                }
            }

            catch (Exception err)
            {

            }
            timer1.Start();
        }

        private void send_Click(object sender, EventArgs e)
        {
            label2.Text = listBox1.Items[1].ToString();
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
            try
            {
                msg.Text = axcopc1.GetVl(0).ToString(); //indexnya urutan tag keberapa
                msg2.Text = axcopc1.GetVl(1).ToString();
                pin1 = axcopc1.GetVl(0).ToString(); //buat cek nyala-mati, harusnya boolean saja
                pin2 = axcopc1.GetVl(1).ToString();
            }
            catch(Exception) { }

            /*
            if (pin1 == "True") { spin1 = "PIN 1 rusak"; } else spin1 = "";
            if (pin2 == "True") { spin2 = "PIN 2 rusak"; } else spin2 = "";
            message = "Lapor:" + spin1 + " dan " + spin2 + ", selesai.";

            if (on == 1 && (pin1 == "True" || pin2 == "True") && waktu==0)
            {
                timer1.Start(); //start counting
                label10.Text = "1";
                foreach (string item in listBox1.Items)
                {
                    SendMessage(item, message); //kontak 0 prioritit
                }
            }*/
        }

        private void msg_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            catch (Exception)
            {

                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                listBox2.Items.Add(textBox1.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                listBox3.Items.Add(textBox2.Text);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                listBox4.Items.Add(textBox3.Text);
            }
        }

        private void int1_TextChanged(object sender, EventArgs e)
        {
            if (int1.Text == "")
            {
                int1x = 0;
            }
            else
            {
                int1x = Int16.Parse(int1.Text);
            }
            label2.Text = int1x.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                int2x = 0;
            }
            else
            {
                int2x = Int16.Parse(textBox4.Text);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //label11.Text = himpunan[0].statepin;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                int3x = 0;
            }
            else
            {
                int3x = Int16.Parse(textBox5.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
            catch (Exception)
            {

                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                listBox4.Items.RemoveAt(listBox4.SelectedIndex);
            }
            catch (Exception)
            {

                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                listBox3.Items.RemoveAt(listBox3.SelectedIndex);
            }
            catch (Exception)
            {

                return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            waktu++;
            label11.Text = waktu.ToString();
            int1x = Int16.Parse(int1.Text);
            int2x = Int16.Parse(textBox4.Text);
            int3x = Int16.Parse(textBox5.Text);

            ///
            for (i = 0; i < j; i++)
            {
                try
                {
                    himpunan[i].statepin = axcopc1.GetVl(i).ToString();
                    int delta = waktu - himpunan[i].downtime;
                    string message = "Alert: PIN " + i + " error!";
                    if (himpunan[i].statepin == "True" && himpunan[i].downtime == -1)
                    {
                        himpunan[i].downtime = waktu;
                        label12.Text = himpunan[i].downtime.ToString();
                        label10.Text = "1";
                        
                        foreach (string item in listBox1.Items)
                        {
                            if(on==1) SendMessage(item, message); //kontak 0 prioritit
                        }
                    }
                    else if (himpunan[i].statepin == "True" && delta == int1x)
                    {
                        label10.Text = "2";
                        foreach (string item in listBox2.Items)
                        {
                            if (on == 1) SendMessage(item, message); //kontak 0 prioritit
                        }
                    }
                    else if (himpunan[i].statepin == "True" && delta == int1x + int2x)
                    {
                        label10.Text = "3";
                        foreach (string item in listBox4.Items)
                        {
                            if (on == 1) SendMessage(item, message); //kontak 0 prioritit
                        }
                    }
                    else if (himpunan[i].statepin == "True" && delta == int1x + int2x + int3x)
                    {
                        label10.Text = "4";
                        foreach (string item in listBox3.Items)
                        {
                            if (on == 1) SendMessage(item, message); //kontak 0 prioritit
                        }
                    }
                    else if (himpunan[i].statepin == "False")
                    {
                        label10.Text = "0";
                        himpunan[i].downtime = -1;
                    }
                }
                catch (Exception) { }
            }
            
            ///
            /*
            msg.Text = himpunan[0].statepin; //indexnya urutan tag keberapa
            msg2.Text = himpunan[1].statepin;
            pin1 = himpunan[0].statepin; //buat cek nyala-mati, harusnya boolean saja
            pin2 = himpunan[1].statepin;
            int1x = Int16.Parse(int1.Text);
            int2x = Int16.Parse(textBox4.Text);
            int3x = Int16.Parse(textBox5.Text);

            if (pin1 == "True") { spin1 = "PIN 1 rusak"; } else spin1 = "";
            if (pin2 == "True") { spin2 = "PIN 2 rusak"; } else spin2 = "";
            message = "Lapor:" + spin1 + " dan " + spin2 + ", selesai.";

            if (waktu == int1x && on == 1 && (pin1 == "True" || pin2 == "True"))
            {
                label10.Text = "2";
                foreach (string item in listBox2.Items)
                {
                    SendMessage(item, message); //kontak 0 prioritit
                }
            }
            else if (waktu == (int1x+int2x) && on == 1 && (pin1 == "True" || pin2 == "True"))
            {
                label10.Text = "3";
                foreach (string item in listBox4.Items)
                {
                    SendMessage(item, message); //kontak 0 prioritit
                }
            }
            else if (waktu == (int1x + int2x + int3x) && on == 1 && (pin1 == "True" || pin2 == "True"))
            {
                label10.Text = "4";
                foreach (string item in listBox3.Items)
                {
                    SendMessage(item, message); //kontak 0 prioritit
                }
                timer1.Stop();
                waktu = 0;
            }
            else if (pin1 == "False" && pin2 == "False")
            {
                label10.Text = "0";
                timer1.Stop();
                waktu = 0;
            }*/
        }

        private void nomor_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            if (nomor.Text != "")
            {
                kontaks.Add(nomor.Text);
                listBox1.Items.Add(nomor.Text);
            }
        }
    }
}
