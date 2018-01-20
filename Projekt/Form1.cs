using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace Projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #region zalacznik
        private void button2_Click_1(object sender, EventArgs e) // przycisk dodaj załącznik
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                listBox1.Items.Add(openFileDialog1.FileName);
        }
        #endregion zalacznik
        private void button1_Click(object sender, EventArgs e)
        {

            #region Mail

            try // spróbuj wyśłać, a jeśli będzie błąd wyswietl wiadomosc za catch
            {
                button1.Enabled = false; //blokuje przycisk wyslij 
                MailMessage wiadomosc = new MailMessage(); // zmienna o nazwie wiadomosci typu mailmessage
                wiadomosc.From = new MailAddress("projektzprogramowania@gmail.com"); // od kogo jest wiadomosc
                wiadomosc.Subject = textBox1.Text; // tytul naszego maila 
                wiadomosc.Body = richTextBox2.Text; // tresc maila

  
                {

                }

                foreach (string mail in richTextBox1.Text.Split(';')) // petla ktora dla kazdej wartosci zrobi akcj 
                {

                    wiadomosc.To.Add(mail); // mozemy wyslac wiadomosc do wielu odbiorcow

                }

                foreach (string plik in listBox1.Items) // petla dodajaca zalaczniki 

                {
                    Attachment zalacznik = new Attachment(plik);
                    wiadomosc.Attachments.Add(zalacznik);
                }

                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential("projektzprogramowania@gmail.com", "wsbpoznan");
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.Send(wiadomosc);
                MessageBox.Show(this, "Poprawnie wysłano wiadomość email","Eureka!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                       
            }
            catch /// 'zlap' to co sie nie uda 
            {
                MessageBox.Show(this, "Nastąpił błąd wysyłania wiadomości email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
           {
                button1.Enabled = true; // odblokowuje przycisk wyślij
            }
            #endregion Mail

            richTextBox1.Text = textBox1.Text = richTextBox2.Text = ""; // czyści wszystkie pola
            listBox1.Items.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
