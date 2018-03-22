using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections.ObjectModel;

namespace FitsHeaderEditor
{
    public partial class Form1 : Form
    {

        FitsFile current_file;
        BindingSource headerBS;
        BindingSource fileHistoryBS;
        AboutBox1 about;
        event EventHandler<List<HeaderField>> HeaderRead;
        event EventHandler<FitsFile> FitsLoaded;

        public Form1(string filepath = "")
        {
            InitializeComponent();

            reloadToolStripMenuItem.Image = Properties.Resources.Reload_Icon.ToBitmap();

            Application.ApplicationExit += new EventHandler(SaveSettings);

            //PrintProductVersion();

            // load user settings
            trimHeaderValueCheckbox.Checked = Properties.Settings.Default.TrimmedHeaderField;

            // prepare data for header grid view
            headerBS = new BindingSource();
            headerBS.DataSource = new List<HeaderField>();
            headerBS.AllowNew = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = headerBS;

            // prepare data for file history list box
            ObservableCollection<FitsFile> items = new ObservableCollection<FitsFile>();
            fileHistoryBS = new BindingSource();
            fileHistoryBS.DataSource = items;
            fileHistoryListBox.DisplayMember = "Name";
            fileHistoryListBox.ValueMember = "FilePath";
            fileHistoryListBox.DataSource = fileHistoryBS;
            
            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;

            // allow dragging file inside the window
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);

            this.HeaderRead += WriteHeaderOnTextBox;
            this.HeaderRead += WriteHeaderOnDataGrid;
            this.FitsLoaded += UpdateHistoryList;

            changeWindowTitle();

            if (filepath != string.Empty)
            {
                loadFitsHeader(new FitsFile(filepath));
            }
        }

        // used to keep a single instance of the application
        public void LoadFile(string filepath)
        {
            if (new FileInfo(filepath).Exists)
            {
                loadFitsHeader(new FitsFile(filepath));
            }
        }

        void WriteHeaderOnTextBox(object sender, List<HeaderField> header)
        {
            StringBuilder resultBuilder = new StringBuilder();
            foreach (HeaderField field in header)
            {
                resultBuilder.Append(field.ToString() + Environment.NewLine);
            }

            int count = System.Text.Encoding.ASCII.GetByteCount(resultBuilder.ToString());
            Console.WriteLine("header bytes count: {0}", count);

            consoleResultTextBox.Clear();
            consoleResultTextBox.AppendText(resultBuilder.ToString());
        }

        void WriteHeaderOnDataGrid(object sender, List<HeaderField> header)
        {
            // remove all fields from datagrid
            headerBS.Clear();

            headerBS.DataSource = header;
        }

        void UpdateHistoryList(object sender, FitsFile file) {
            if (!fileHistoryBS.Contains(file))
            {
                fileHistoryBS.Add(file);
            }
            fileHistoryListBox.SelectedItem = file;
        }

        private void loadFitsHeader(FitsFile file)
        {
            // enable save buttons
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;

            current_file = file ?? throw new Exception("No file currently loaded.").Log();  // set file global variable to the loaded file
            
            changeWindowTitle(file.Name);  // change window title

            var header = FitsUtil.ReadFitsHeader(current_file.FilePath);
            HeaderRead(this, header);
            FitsLoaded(this, file);
        }

        private void changeWindowTitle(string title = "No FITS loaded") {
            this.Text = string.Format("{0} - Version {1} - {2}", Application.ProductName, Application.ProductVersion, title);
        }

        private void PrintProductVersion()
        {
            //String copy = ((AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCopyrightAttribute), false)).Copyright;
            //versionLabel.Text = "v. " + Application.ProductVersion;
        }

        private void openAbout() {
            if (about == null || about.IsDisposed)
            {
                about = new AboutBox1();
            }
            about.Show();
        }

        private void addHeaderField(HeaderField field = null) {
            if (field != null)
            {
                headerBS.Add(field);
            } else
            {
                headerBS.AddNew();
            }
            
        }

        private void removeHeaderField()
        {
            foreach ( DataGridViewRow row in dataGridView1.SelectedRows)
            {
                // first check if the row is new
                if (row.IsNewRow) continue;

                HeaderField field = (HeaderField)row.DataBoundItem;
                
                if (field.isMandatory()) continue;
                dataGridView1.Rows.RemoveAt(row.Index);
            }

            foreach (DataGridViewCell cell in dataGridView1.SelectedCells) {
                var row = cell.OwningRow;
                // first check if the row is new
                if (row.IsNewRow) continue;

                HeaderField field = (HeaderField)row.DataBoundItem;

                if (field.isMandatory()) continue;
                dataGridView1.Rows.RemoveAt(row.Index);
            }
            //datagrid.RemoveCurrent();
        }

        private void findHeaderField(string value)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Selected = false;
                HeaderField field = (HeaderField)row.DataBoundItem;
                if (field == null || field.isEmpty()) continue;
                if (field.Key.Trim().Equals(value) || field.Value.Trim().Equals(value))
                {
                    selectedRow = row;
                    break;
                }
               
            }
            
            if(selectedRow != null)
                selectedRow.Selected = true;

        }

        private void SaveSettings(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void consoleResultTextBox_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("header changed");
            string[] header = consoleResultTextBox.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (string line in header)
            {
                if( line.Length > 80 )
                {
                    line.Substring(0, 80);
                }
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            Console.WriteLine("cellvalidating fired");
            dataGridView1.Rows[e.RowIndex].ErrorText = "";
            
            // Don't try to validate the 'new row' until finished 
            // editing since there
            // is not any point in validating its initial value.
            if (dataGridView1.Rows[e.RowIndex].IsNewRow) { return; }

            int col = e.ColumnIndex;
            string value = e.FormattedValue.ToString();
            if (col == 0 && value.Length != 8)
            {
                value = value.PadRight(8).Substring(0, 8);
                value = value.ToUpper();
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value;
                //e.Cancel = true;
                //dataGridView1.Rows[e.RowIndex].ErrorText = "Wrong length!";
            }
            else if (col == 1 && value.Length != 70)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value.PadRight(70).Substring(0, 70);
                //e.Cancel = true;
                //dataGridView1.Rows[e.RowIndex].ErrorText = "Wrong length!";
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    loadFitsHeader(new FitsFile(openFileDialog1.FileName));
                }
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file = current_file ?? throw new Exception("No file currently loaded.").Log();
                dataGridView1.EndEdit();
                dataGridView1.CurrentCell = null;

                FitsUtil.WriteFitsHeader(headerBS.List, current_file.FilePath);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // set the filename to save to the current file
                current_file = current_file ?? throw new Exception("No file currently loaded.").Log();

                saveFileDialog1.FileName = current_file.Name;

                // commit all editing stuff
                dataGridView1.EndEdit();
                dataGridView1.CurrentCell = null;

                DialogResult result = saveFileDialog1.ShowDialog();
                string newfile = saveFileDialog1.FileName;

                if (result == DialogResult.OK && current_file != null)
                {
                    FitsUtil.WriteFitsHeader(headerBS.List, current_file.FilePath, newfile);
                }
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Hide();
            } else
            {
                this.Show();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openAbout();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void addHeaderFieldButton_Click(object sender, EventArgs e)
        {
            try
            {
                var presetKeyword = headerPresetComboBox.Text;
                if (!string.IsNullOrEmpty(presetKeyword))
                {
                    addHeaderField(new HeaderField(presetKeyword));
                }
                else
                {
                    addHeaderField();
                }
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void removeHeaderFieldButton_Click(object sender, EventArgs e)
        {
            try
            {
                removeHeaderField();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            HeaderField field = (HeaderField)e.Row.DataBoundItem;
            if (field.isMandatory()) e.Cancel = true;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files)
                {
                    var t = new FitsFile(file);
                    if (!fileHistoryBS.Contains(t))
                        fileHistoryBS.Add(new FitsFile(file));
                }

                loadFitsHeader(new FitsFile(files[0]));
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void trimHeaderValueCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            HeaderField.Trimmed = trimHeaderValueCheckbox.Checked;
            Properties.Settings.Default.TrimmedHeaderField = trimHeaderValueCheckbox.Checked;

            dataGridView1.ReadOnly = trimHeaderValueCheckbox.Checked;
            dataGridView1.AllowUserToAddRows = !trimHeaderValueCheckbox.Checked;
            dataGridView1.AllowUserToDeleteRows = !trimHeaderValueCheckbox.Checked;
            dataGridView1.AllowUserToOrderColumns = !trimHeaderValueCheckbox.Checked;

            addHeaderFieldButton.Enabled = !trimHeaderValueCheckbox.Checked;
            removeHeaderFieldButton.Enabled = !trimHeaderValueCheckbox.Checked;

            dataGridView1.Refresh();
        }

        private void fileHistoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selected_file = fileHistoryListBox.SelectedItem as FitsFile;
                if (selected_file != null && selected_file != current_file)
                {
                    loadFitsHeader(selected_file);
                }
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                loadFitsHeader(current_file);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.ReadOnly)
            {
                System.Windows.Forms.MessageBox.Show("The header is in read only mode!", "Message", MessageBoxButtons.OK);
            }
        }

        private void fileHistoryListClearButton_Click(object sender, EventArgs e)
        {
            fileHistoryBS.Clear();
        }
    }
}
