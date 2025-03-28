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
using System.Net.Http;
using System.IO;

namespace FitsHeaderEditor
{
    public partial class TextInput : Form
    {

        public event EventHandler<Stream> TextSent;

        public TextInput()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string url = textBox1.Text; // Assume urlTextBox is your TextBox control

                ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;
                ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                using (HttpResponseMessage response = await Form1.client.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();
                    Stream responseBody = await response.Content.ReadAsStreamAsync();
                    TextSent?.Invoke(this, responseBody);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TextInput_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }

}
