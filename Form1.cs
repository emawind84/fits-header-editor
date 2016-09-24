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

        private void Form1_Load(object sender, EventArgs e)
        {
             
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

            current_file = file;  // set file global variable to the loaded file
            
            changeWindowTitle(file.Name);  // change window title
            readFitsHeader();

            FitsLoaded(this, file);
            
            
        }

        private List<HeaderField> readFitsHeader() {
            char[] buffer = null;
            List<HeaderField> header = new List<HeaderField>();
            FileStream fs = new FileStream(current_file.FilePath, FileMode.Open, FileAccess.Read);

            using (StreamReader streamReader = new StreamReader(fs, Encoding.ASCII))
            {
                buffer = new char[80];
                while (streamReader.ReadBlock(buffer, 0, (int)buffer.Length) != 0)
                {
                    string result = new string(buffer);

                    if (result.Trim() == "END")
                    {
                        break;
                    }
                    
                    string key = result.Substring(0, 8);
                    string value = result.Substring(10, 70);
                    header.Add(new HeaderField(key, value));
                }
                
            }

            HeaderRead(this, header);

            return header;
        }

        private byte[] updateFitsHeader()
        {
            StringBuilder resultBuilder = new StringBuilder();
            foreach (HeaderField field in headerBS.List)
            {
                if (field.isEmpty()) continue;
                resultBuilder.Append(field.ToString());
            }

            // add the END keyword to end the header
            resultBuilder.Append(HeaderField.EndKeyword());

            // fill the right side of END with spaces if required
            string result = resultBuilder.ToString();
            int pad_length = result.Length % 2880;
            result = result.PadRight(result.Length + pad_length);
            
            return System.Text.Encoding.ASCII.GetBytes(result);
        }

        private void writeFitsHeader(string file, string newfile = null) {
            ASCIIEncoding encoding = new ASCIIEncoding();
            //byte[] header = encoding.GetBytes(consoleResultTextBox.Text.Replace(System.Environment.NewLine, ""));

            // commit all editing stuff
            dataGridView1.EndEdit();
            dataGridView1.CurrentCell = null;
            
            byte[] header = updateFitsHeader();
            byte[] data;

            // extract image data from file
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                int header_end = findHeaderLength();
                
                data = new byte[fs.Length - header_end];
                fs.Read(data, 0, data.Length);
            }

            // write new header with image data
            newfile = newfile != null ? newfile : file;
            using (FileStream fs = new FileStream(newfile, FileMode.Create, FileAccess.Write))
            {
                //fs.Seek(0, SeekOrigin.Begin);
                
                using (BinaryWriter streamWriter = new BinaryWriter(fs, Encoding.ASCII))
                {
                    streamWriter.Write(header);
                    streamWriter.Write(data);
                }
            }
            
        }

        private int findHeaderLength()
        {
            int header_end = 0;
            // extract image data from file
            using (FileStream fs = new FileStream(current_file.FilePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader streamReader = new StreamReader(fs, Encoding.ASCII))
                {
                    char[] buffer = new char[80];
                    while (streamReader.Read(buffer, 0, buffer.Length) != 0)
                    {
                        string f = new string(buffer);
                        if (f.Trim() == "END")
                        {
                            break;
                        }
                    }
                    header_end = (int)fs.Position;
                }

            }

            return header_end;
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
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadFitsHeader(new FitsFile(openFileDialog1.FileName));
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (current_file != null)
            {
                writeFitsHeader(current_file.FilePath);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // set the filename to save to the current file
            saveFileDialog1.FileName = current_file.Name;

            DialogResult result = saveFileDialog1.ShowDialog();
            string newfile = saveFileDialog1.FileName;

            if ( result == DialogResult.OK && current_file != null)
            {
                writeFitsHeader(current_file.FilePath, newfile);
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
            openAbout();
        }

        private void addHeaderFieldButton_Click(object sender, EventArgs e)
        {
            var presetKeyword = headerPresetComboBox.Text;
            if (!string.IsNullOrEmpty(presetKeyword))
            {
                addHeaderField(new HeaderField(presetKeyword));
            } else
            {
                addHeaderField();
            }
            
        }

        private void removeHeaderFieldButton_Click(object sender, EventArgs e)
        {
            removeHeaderField();
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
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                var t = new FitsFile(file);
                if (!fileHistoryBS.Contains(t))
                    fileHistoryBS.Add(new FitsFile(file));
            }
            
            loadFitsHeader(new FitsFile(files[0]));
            
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
            var selected_file = fileHistoryListBox.SelectedItem as FitsFile;
            if ( selected_file != current_file )
                loadFitsHeader(selected_file);
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadFitsHeader(current_file);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.ReadOnly)
            {
                System.Windows.Forms.MessageBox.Show("The header is in read only mode!", "Message", MessageBoxButtons.OK);
            }
        }

    }
}
