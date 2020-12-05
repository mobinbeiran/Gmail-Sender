using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace WindowsFormsApp18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textBox4.Text.Contains("@gmail.com"))
                {
                    MessageBox.Show("you need to provide an email @gmail.com");
                    return;
                }
                button1.Enabled = false;
                MailMessage message = new MailMessage();
                message.From = new MailAddress(textBox4.Text);
                message.Subject = textBox2.Text;
                message.Body = textBox3.Text;
                foreach (string s in textBox1.Text.Split(';'))
                    message.To.Add(s);
                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential(textBox4.Text, textBox5.Text);
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.Send(message);
            }
            catch { MessageBox.Show("there was an error sending the message. make sure you typed\r\nin your credentials correctly and that you have an internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { button1.Enabled = true; }
        }
    }
}
