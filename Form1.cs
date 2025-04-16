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
using System.Drawing.Printing;
using System.Net.Http;

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
        Settings settingsForm;

        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        public static readonly HttpClient client = new HttpClient();

        public Form1(string filepath = "")
        {
            InitializeComponent();

            Application.ApplicationExit += new EventHandler(SaveSettings);
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            //PrintProductVersion();

            // load user settings
            trimHeaderValueCheckbox.Checked = false; //Properties.Settings.Default.TrimmedHeaderField;

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
            //saveAsToolStripMenuItem.Enabled = false;

            // allow dragging file inside the window
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);

            this.HeaderRead += WriteHeaderOnTextBox;
            this.HeaderRead += WriteHeaderOnDataGrid;
            this.FitsLoaded += UpdateHistoryList;

            this.settingsForm = new Settings();

            changeWindowTitle();

            if (filepath != string.Empty)
            {
                loadFitsHeader(new FitsFile(filepath));
            }
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
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

            var header = FitsUtil.ReadFitsHeaderFromFile(current_file.FilePath);
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
            about.ShowDialog(this);
        }

        private void addHeaderField(HeaderField field = null) {
            if (dataGridView1.IsCurrentCellInEditMode) return;

            var currentIndex = headerBS.Position;
            if (field == null)
            {
                field = new HeaderField("", "");
            }
            if (insertAtSelectionCheckBox.Checked && currentIndex > 0)
            {
                headerBS.Insert(currentIndex, field);
            }
            else
            {
                headerBS.Add(field);
            }
            headerBS.ResetBindings(false);
        }

        private void removeHeaderField()
        {
            if (dataGridView1.IsCurrentCellInEditMode) return;

            var rowsToDelete = new HashSet<int>();
            foreach ( DataGridViewRow row in dataGridView1.SelectedRows)
            {
                // first check if the row is new
                if (row.IsNewRow) continue;

                HeaderField field = (HeaderField)row.DataBoundItem;
                
                //if (field.isMandatory()) continue;
                rowsToDelete.Add(row.Index);
            }

            foreach (DataGridViewCell cell in dataGridView1.SelectedCells) {
                var row = cell.OwningRow;
                // first check if the row is new
                if (row.IsNewRow) continue;

                HeaderField field = (HeaderField)row.DataBoundItem;

                //if (field.isMandatory()) continue;
                rowsToDelete.Add(row.Index);
            }

            foreach (int rowIndex in rowsToDelete.OrderByDescending(index => index)) // Delete in reverse order
            {
                dataGridView1.Rows.RemoveAt(rowIndex);
            }
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
                //current_file = current_file ?? throw new Exception("No file currently loaded.").Log();
                saveFileDialog1.FileName = current_file?.Name;
                
                // commit all editing stuff
                dataGridView1.EndEdit();
                dataGridView1.CurrentCell = null;

                DialogResult result = saveFileDialog1.ShowDialog();
                string newfile = saveFileDialog1.FileName;

                if (result == DialogResult.OK)
                {
                    FitsUtil.WriteFitsHeader(headerBS.List, current_file?.FilePath, newfile);
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

        private void addPresetHeaderField()
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

            int newRowIndex = dataGridView1.RowCount - 1;
            if (insertAtSelectionCheckBox.Checked && headerBS.Position > 0)
            {
                newRowIndex = headerBS.Position - 1;
            }
            // Scroll to the new row
            dataGridView1.FirstDisplayedScrollingRowIndex = newRowIndex;

            // Focus on the second cell (index 1, assuming it exists)
            if (dataGridView1.Columns.Count > 1)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[newRowIndex].Cells[1]; // Set focus on the second cell
                dataGridView1.BeginEdit(true); // Begin editing the cell
            }
        }

        private void addHeaderFieldButton_Click(object sender, EventArgs e)
        {
            try
            {
                addPresetHeaderField();
                WriteHeaderOnTextBox(this, (List<HeaderField>)headerBS.DataSource);
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
                WriteHeaderOnTextBox(this, (List<HeaderField>)headerBS.DataSource);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            HeaderField field = (HeaderField)e.Row.DataBoundItem;
            //if (field.isMandatory()) e.Cancel = true;
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
            addDefaultHeaderButton.Enabled = !trimHeaderValueCheckbox.Checked;
            addKeywordToolStripMenuItem.Enabled = !trimHeaderValueCheckbox.Checked;
            removeKeywordsToolStripMenuItem.Enabled = !trimHeaderValueCheckbox.Checked;
            addDefaultHeadersToolStripMenuItem.Enabled = !trimHeaderValueCheckbox.Checked;
            pasteFromClipboardToolStripMenuItem.Enabled = !trimHeaderValueCheckbox.Checked;
            pasteFromFileToolStripMenuItem.Enabled = !trimHeaderValueCheckbox.Checked;
            pasteFromURIToolStripMenuItem.Enabled = !trimHeaderValueCheckbox.Checked;

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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                settingsForm.Owner = this;
                settingsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void AddDefaultHeaders()
        {
            var obj = new HeaderField("COMMENT", "/ Added with FitsHeaderEditor"); addHeaderField(obj);
            obj = new HeaderField("OBJECT", Properties.Settings.Default.HeaderFieldObject); addHeaderField(obj);
            obj = new HeaderField("TELESCOP", Properties.Settings.Default.HeaderFieldTelescope); addHeaderField(obj);
            obj = new HeaderField("INSTRUME", Properties.Settings.Default.HeaderFieldInstrument); addHeaderField(obj);
            obj = new HeaderField("OBSERVER", Properties.Settings.Default.HeaderFieldObserver); addHeaderField(obj);
            obj = new HeaderField("DATE-OBS", Properties.Settings.Default.HeaderFieldDate); addHeaderField(obj);
        }

        private void AddDefaultHeaderButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                AddDefaultHeaders();
                WriteHeaderOnTextBox(this, (List<HeaderField>)headerBS.DataSource);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
            
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PrintUtil pu = new PrintUtil();
                pu.PrintHeaders(consoleResultTextBox.Text);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
            
        }

        private void PasteClipboardDataToDataTable()
        {
            // Get clipboard text
            string clipboardText = Clipboard.GetText();
            if (!string.IsNullOrEmpty(clipboardText))
            {
                var obj = new HeaderField("COMMENT", "/ Added with FitsHeaderEditor");
                addHeaderField(obj);

                // Split text into rows
                string[] rows = clipboardText.Split('\n');

                foreach (string row in rows)
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        // Split row into cells (assuming tab-delimited data)
                        string[] cells = row.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (cells == null || cells.Length == 1)
                        {
                            cells = FitsUtil.ProcessHeaderString(row);
                            addHeaderField(new HeaderField(cells[0], cells[1]));
                        }
                        else if (cells.Length > 1)
                            addHeaderField(new HeaderField(cells[0], cells[1]));
                        else
                            addHeaderField(new HeaderField(cells[0]));
                    }
                }
            }
        }

        private void pasteFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PasteClipboardDataToDataTable();
                WriteHeaderOnTextBox(this, (List<HeaderField>)headerBS.DataSource);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void addKeywordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                addPresetHeaderField();
                WriteHeaderOnTextBox(this, (List<HeaderField>)headerBS.DataSource);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void removeKeywordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                removeHeaderField();
                WriteHeaderOnTextBox(this, (List<HeaderField>)headerBS.DataSource);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void addDefaultHeadersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddDefaultHeaders();
                WriteHeaderOnTextBox(this, (List<HeaderField>)headerBS.DataSource);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void pasteFromURIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TextInput textInput = new TextInput();
                textInput.TextSent += PasteFromURI_TextSent;
                textInput.ShowDialog(this);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void PasteFromURI_TextSent(object sender, Stream stream)
        {
            var headers = FitsUtil.ReadFitsHeaderFromStream(stream);
            var obj = new HeaderField("", "");
            addHeaderField(obj);
            obj = new HeaderField("", "/ Added with FitsHeaderEditor");
            addHeaderField(obj);
            foreach (HeaderField field in headers)
            {
                addHeaderField(field);
            }
            WriteHeaderOnTextBox(this, (List<HeaderField>)headerBS.DataSource);
        }

        private void clearHeaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                headerBS.Clear();
                WriteHeaderOnTextBox(this, (List<HeaderField>)headerBS.DataSource);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void pasteFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var headers = FitsUtil.ReadFitsHeaderFromFile(openFileDialog1.FileName);
                    var obj = new HeaderField("", "");
                    addHeaderField(obj);
                    obj = new HeaderField("", "/ Added with FitsHeaderEditor");
                    addHeaderField(obj);
                    foreach (HeaderField field in headers)
                    {
                        addHeaderField(field);
                    }
                    WriteHeaderOnTextBox(this, (List<HeaderField>)headerBS.DataSource);
                }
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                WriteHeaderOnTextBox(this, (List<HeaderField>)headerBS.DataSource);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.IsInEditMode) return;

                if (e.KeyCode == Keys.Delete)
                {
                    removeHeaderField();
                    WriteHeaderOnTextBox(this, (List<HeaderField>)headerBS.DataSource);
                }
                else if (e.KeyCode == Keys.Insert)
                {
                    addPresetHeaderField();
                    WriteHeaderOnTextBox(this, (List<HeaderField>)headerBS.DataSource);
                }
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

    }
}
