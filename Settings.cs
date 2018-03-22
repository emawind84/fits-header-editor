using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitsHeaderEditor
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            DateTextBox.Text = Properties.Settings.Default.HeaderFieldDate;
            InstrumeTextBox.Text = Properties.Settings.Default.HeaderFieldInstrument;
            ObjectTextBox.Text = Properties.Settings.Default.HeaderFieldObject;
            ObserverTextBox.Text = Properties.Settings.Default.HeaderFieldObserver;
            TelescopeTextBox.Text = Properties.Settings.Default.HeaderFieldTelescope;
        }

        private void SettingOKButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.HeaderFieldDate = DateTextBox.Text;
            Properties.Settings.Default.HeaderFieldInstrument = InstrumeTextBox.Text;
            Properties.Settings.Default.HeaderFieldObject = ObjectTextBox.Text;
            Properties.Settings.Default.HeaderFieldObserver = ObserverTextBox.Text;
            Properties.Settings.Default.HeaderFieldTelescope = TelescopeTextBox.Text;

            this.Hide();
        }
        
    }
}
