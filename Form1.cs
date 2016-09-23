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

namespace FitHeaderReader
{
    public partial class Form1 : Form
    {

        string current_filepath;
        BindingSource datagrid;
        AboutBox1 about;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrintProductVersion();

            datagrid = new BindingSource();
            datagrid.DataSource = new List<HeaderField>();
            datagrid.AllowNew = true;
            dataGridView1.DataSource = datagrid;
            //dataGridView1.Columns[0].HeaderCell.Value = "Key";
            //dataGridView1.Columns[1].HeaderCell.Value = "Value";

            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;

            // allow dragging file inside the window
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        private void loadFitsHeader(string filepath)
        {
            // enable save buttons
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;

            current_filepath = filepath;  // set filepath global variable to the loaded file

            FileInfo info = new FileInfo(filepath);
            changeWindowTitle("Open file: " + info.Name);  // change window title
            var header = readFitsHeader();
            printFitsHeader(header);
        }

        private string readFitsHeader() {
            char[] buffer = null;
            StringBuilder resultBuilder = new StringBuilder();
            //Dictionary<string, string> header = new Dictionary<string, string>();
            FileStream fs = new FileStream(current_filepath, FileMode.Open, FileAccess.Read);

            // remove all fields from datagrid
            datagrid.Clear();

            using (StreamReader streamReader = new StreamReader(fs, Encoding.ASCII))
            {
                buffer = new char[80];
                int idx = 0;
                while (streamReader.ReadBlock(buffer, idx, (int)buffer.Length) != 0)
                {
                    string result = new string(buffer);

                    if (result.Trim() == "END")
                    {
                        break;
                    }
                    
                    string key = result.Substring(0, 8);
                    string value = result.Substring(10, 70);
                    datagrid.Add(new HeaderField(key, value));
                    //dataGridView1.Rows.Add(key, value);
                    //dataGridView1.Refresh();
                    
                    //string result = System.Text.Encoding.ASCII.GetString(buffer);

                    resultBuilder.Append(result + Environment.NewLine);
                    
                }
                
            }

            int count = System.Text.Encoding.ASCII.GetByteCount(resultBuilder.ToString());
            Console.WriteLine("header bytes count: {0}", count);

            return resultBuilder.ToString();
        }

        private byte[] updateFitsHeader()
        {
            StringBuilder resultBuilder = new StringBuilder();
            foreach (HeaderField field in datagrid.List)
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
            using (FileStream fs = new FileStream(current_filepath, FileMode.Open, FileAccess.Read))
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

        private void printFitsHeader(string header) {
            /*foreach (KeyValuePair<string, string> entry in header)
            {
                consoleResultTextBox.AppendText(entry.Key + " = " + entry.Value);
                consoleResultTextBox.AppendText(Environment.NewLine);
            }*/
            consoleResultTextBox.Clear();
            consoleResultTextBox.AppendText(header);
        }

        private void changeWindowTitle(string title) {
            this.Text = title;
        }

        private void PrintProductVersion()
        {
            //String copy = ((AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCopyrightAttribute), false)).Copyright;
            versionLabel.Text = "v. " + Application.ProductVersion;
        }

        private void openAbout() {
            if (about == null || about.IsDisposed)
            {
                about = new AboutBox1();
            }
            about.Show();
        }

        private void addHeaderField() {
            datagrid.AddNew();
        }

        private void removeHeaderField()
        {
            foreach ( DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.IsNewRow) continue;
                dataGridView1.Rows.RemoveAt(row.Index);
            }
            //datagrid.RemoveCurrent();
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
            dataGridView1.Rows[e.RowIndex].ErrorText = "";

            // Don't try to validate the 'new row' until finished 
            // editing since there
            // is not any point in validating its initial value.
            if (dataGridView1.Rows[e.RowIndex].IsNewRow) { return; }

            int col = e.ColumnIndex;
            string value = e.FormattedValue.ToString();
            if (col == 0 && value.Length != 8)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value.PadRight(8).Substring(0, 8);
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
                loadFitsHeader(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (current_filepath != null)
            {
                writeFitsHeader(current_filepath);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            string newfile = saveFileDialog1.FileName;

            if ( result == DialogResult.OK && current_filepath != null)
            {
                writeFitsHeader(current_filepath, newfile);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
            addHeaderField();
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
            //foreach (string file in files) Console.WriteLine(file);
            Console.WriteLine(files[0]);

            try
            {
                loadFitsHeader(files[0]);
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
    }
}
