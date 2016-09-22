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

        string filepath;
        BindingSource datagrid;

        public Form1()
        {
            InitializeComponent();

            datagrid = new BindingSource();
            datagrid.DataSource = new List<HeaderField>();
            dataGridView1.DataSource = datagrid;
            //dataGridView1.Columns[0].HeaderCell.Value = "Key";
            //dataGridView1.Columns[1].HeaderCell.Value = "Value";

            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
        }

        private string readFitsHeader(string file) {
            char[] buffer = null;
            StringBuilder resultBuilder = new StringBuilder();
            //Dictionary<string, string> header = new Dictionary<string, string>();
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);

            // remove all fields from datagrid
            datagrid.Clear();

            using (StreamReader streamReader = new StreamReader(fs, Encoding.ASCII))
            {
                buffer = new char[80];
                int idx = 0;
                while (streamReader.ReadBlock(buffer, idx, (int)buffer.Length) != 0)
                {
                    string result = new string(buffer);
                    if (result.Substring(8, 2) == "= ")
                    {
                        
                        string key = result.Substring(0, 8);
                        string value = result.Substring(10, 70);
                        datagrid.Add(new HeaderField(key, value));
                        //dataGridView1.Rows.Add(key, value);
                        //dataGridView1.Refresh();
                    }

                    //string result = System.Text.Encoding.ASCII.GetString(buffer);

                    resultBuilder.Append(result + Environment.NewLine);

                    if (result.Trim() == "END")
                    {
                        break;
                    }
                }
                
            }

            int count = System.Text.Encoding.ASCII.GetByteCount(resultBuilder.ToString());
            Console.WriteLine("header bytes count: {0}", count);

            return resultBuilder.ToString();
        }

        private byte[] updateFitsHeader()
        {
            char[] buffer = null;
            StringBuilder resultBuilder = new StringBuilder();
            //Dictionary<string, string> header = new Dictionary<string, string>();
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);

            using (StreamReader streamReader = new StreamReader(fs, Encoding.ASCII))
            {
                buffer = new char[80];
                while (streamReader.ReadBlock(buffer, 0, (int)buffer.Length) != 0)
                {
                    string result = new string(buffer);
                    string key = result.Substring(0, 8);

                    if (result.Substring(8, 2) == "= " )
                    {
                        foreach (HeaderField field in datagrid.List)
                        {
                            if (field.key == key)
                            {
                                result = field.key + "= " + field.value;
                                //Console.WriteLine("Updating header {0} = {1}", field.key, field.value);
                            }
                        }
                    }
                    
                    resultBuilder.Append(result);
                    
                    if (result.Trim() == "END")
                    {
                        break;
                    }
                }

            }
            
            return System.Text.Encoding.ASCII.GetBytes(resultBuilder.ToString()); ;
        }

        private void writeFitsHeader(string file, string newfile = null) {
            ASCIIEncoding encoding = new ASCIIEncoding();
            //byte[] header = encoding.GetBytes(consoleResultTextBox.Text.Replace(System.Environment.NewLine, ""));

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
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
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

        private string createValue(string value) {
            char[] buffer = new char[70];
            for (int i = 0; i < buffer.Length; i++)
            {
                try
                {
                    buffer[i] = value.Substring(i, 1)[0];
                } catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Value too long {0}", value);
                }
            }

            return new string(buffer);
        }

        private void changeWindowTitle(string title) {
            Form.ActiveForm.Text = title;
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
                e.Cancel = true;
                dataGridView1.Rows[e.RowIndex].ErrorText = "Wrong length!";
            }
            else if (col == 1 && value.Length != 70)
            {
                e.Cancel = true;
                dataGridView1.Rows[e.RowIndex].ErrorText = "Wrong length!";
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                // enable save buttons
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;

                string file = openFileDialog1.FileName;

                filepath = file;  // set filepath global variable to the loaded file
                changeWindowTitle("Open file: " + file);  // change window title

                try
                {
                    byte[] fileInBytes = File.ReadAllBytes(file);
                    size = fileInBytes.Length;
                    var header = readFitsHeader(file);
                    printFitsHeader(header);
                }
                catch (IOException)
                {
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filepath != null)
            {
                writeFitsHeader(filepath);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            string newfile = saveFileDialog1.FileName;

            if ( result == DialogResult.OK && filepath != null)
            {
                writeFitsHeader(filepath, newfile);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
