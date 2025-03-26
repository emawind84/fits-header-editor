namespace FitsHeaderEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addKeywordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeKeywordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDefaultHeadersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.consoleResultTextBox = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addDefaultHeaderButton = new System.Windows.Forms.Button();
            this.removeHeaderFieldButton = new System.Windows.Forms.Button();
            this.addHeaderFieldButton = new System.Windows.Forms.Button();
            this.headerPresetComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trimHeaderValueCheckbox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.fileHistoryListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.fileHistoryListClearButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "FITS Files (*.fit;*.fits)|*.fit;*.fits";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.AddExtension = false;
            this.saveFileDialog1.DefaultExt = "fits";
            this.saveFileDialog1.Filter = "*.fit|*.fits";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(754, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::FitsHeaderEditor.Properties.Resources.OpenFile_16x;
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Image = global::FitsHeaderEditor.Properties.Resources.Reload_Icon;
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::FitsHeaderEditor.Properties.Resources.Settings_16x;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem1.Text = "Settings";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(183, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::FitsHeaderEditor.Properties.Resources.Save_16x;
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::FitsHeaderEditor.Properties.Resources.SaveAll_16x;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = global::FitsHeaderEditor.Properties.Resources.Print_16x;
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::FitsHeaderEditor.Properties.Resources.Exit_16x;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addKeywordToolStripMenuItem,
            this.removeKeywordsToolStripMenuItem,
            this.addDefaultHeadersToolStripMenuItem,
            this.pasteFromClipboardToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addKeywordToolStripMenuItem
            // 
            this.addKeywordToolStripMenuItem.Image = global::FitsHeaderEditor.Properties.Resources.AddRow_16x;
            this.addKeywordToolStripMenuItem.Name = "addKeywordToolStripMenuItem";
            this.addKeywordToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.addKeywordToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.addKeywordToolStripMenuItem.Text = "Add Keyword";
            this.addKeywordToolStripMenuItem.Click += new System.EventHandler(this.addKeywordToolStripMenuItem_Click);
            // 
            // removeKeywordsToolStripMenuItem
            // 
            this.removeKeywordsToolStripMenuItem.Image = global::FitsHeaderEditor.Properties.Resources.DeleteTableRow_16x;
            this.removeKeywordsToolStripMenuItem.Name = "removeKeywordsToolStripMenuItem";
            this.removeKeywordsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeKeywordsToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.removeKeywordsToolStripMenuItem.Text = "Remove Keyword(s)";
            this.removeKeywordsToolStripMenuItem.Click += new System.EventHandler(this.removeKeywordsToolStripMenuItem_Click);
            // 
            // addDefaultHeadersToolStripMenuItem
            // 
            this.addDefaultHeadersToolStripMenuItem.Image = global::FitsHeaderEditor.Properties.Resources.DefaultIcon_16x;
            this.addDefaultHeadersToolStripMenuItem.Name = "addDefaultHeadersToolStripMenuItem";
            this.addDefaultHeadersToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.addDefaultHeadersToolStripMenuItem.Text = "Add Default Headers";
            this.addDefaultHeadersToolStripMenuItem.Click += new System.EventHandler(this.addDefaultHeadersToolStripMenuItem_Click);
            // 
            // pasteFromClipboardToolStripMenuItem
            // 
            this.pasteFromClipboardToolStripMenuItem.Image = global::FitsHeaderEditor.Properties.Resources.PasteAppend_16x;
            this.pasteFromClipboardToolStripMenuItem.Name = "pasteFromClipboardToolStripMenuItem";
            this.pasteFromClipboardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.pasteFromClipboardToolStripMenuItem.Text = "Paste From Clipboard";
            this.pasteFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.pasteFromClipboardToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Fits Header Editor";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.consoleResultTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(534, 479);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Raw View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // consoleResultTextBox
            // 
            this.consoleResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleResultTextBox.BackColor = System.Drawing.Color.White;
            this.consoleResultTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleResultTextBox.Location = new System.Drawing.Point(5, 3);
            this.consoleResultTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.consoleResultTextBox.Multiline = true;
            this.consoleResultTextBox.Name = "consoleResultTextBox";
            this.consoleResultTextBox.ReadOnly = true;
            this.consoleResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.consoleResultTextBox.Size = new System.Drawing.Size(526, 472);
            this.consoleResultTextBox.TabIndex = 25;
            this.consoleResultTextBox.WordWrap = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(534, 479);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Edit Header";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.addDefaultHeaderButton);
            this.panel1.Controls.Add(this.removeHeaderFieldButton);
            this.panel1.Controls.Add(this.addHeaderFieldButton);
            this.panel1.Controls.Add(this.headerPresetComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 435);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 40);
            this.panel1.TabIndex = 32;
            // 
            // addDefaultHeaderButton
            // 
            this.addDefaultHeaderButton.Image = global::FitsHeaderEditor.Properties.Resources.DefaultIcon_16x;
            this.addDefaultHeaderButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addDefaultHeaderButton.Location = new System.Drawing.Point(362, 15);
            this.addDefaultHeaderButton.Name = "addDefaultHeaderButton";
            this.addDefaultHeaderButton.Size = new System.Drawing.Size(134, 23);
            this.addDefaultHeaderButton.TabIndex = 34;
            this.addDefaultHeaderButton.Text = "Add Default Headers";
            this.addDefaultHeaderButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addDefaultHeaderButton.UseVisualStyleBackColor = true;
            this.addDefaultHeaderButton.Click += new System.EventHandler(this.AddDefaultHeaderButtonOnClick);
            // 
            // removeHeaderFieldButton
            // 
            this.removeHeaderFieldButton.Image = global::FitsHeaderEditor.Properties.Resources.DeleteTableRow_16x;
            this.removeHeaderFieldButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeHeaderFieldButton.Location = new System.Drawing.Point(232, 15);
            this.removeHeaderFieldButton.Name = "removeHeaderFieldButton";
            this.removeHeaderFieldButton.Size = new System.Drawing.Size(124, 23);
            this.removeHeaderFieldButton.TabIndex = 33;
            this.removeHeaderFieldButton.Text = "Remove Keyword(s)";
            this.removeHeaderFieldButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.removeHeaderFieldButton.UseVisualStyleBackColor = true;
            this.removeHeaderFieldButton.Click += new System.EventHandler(this.removeHeaderFieldButton_Click);
            // 
            // addHeaderFieldButton
            // 
            this.addHeaderFieldButton.Image = global::FitsHeaderEditor.Properties.Resources.AddRow_16x;
            this.addHeaderFieldButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addHeaderFieldButton.Location = new System.Drawing.Point(130, 15);
            this.addHeaderFieldButton.Name = "addHeaderFieldButton";
            this.addHeaderFieldButton.Size = new System.Drawing.Size(96, 23);
            this.addHeaderFieldButton.TabIndex = 32;
            this.addHeaderFieldButton.Text = "Add Keyword";
            this.addHeaderFieldButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addHeaderFieldButton.UseVisualStyleBackColor = true;
            this.addHeaderFieldButton.Click += new System.EventHandler(this.addHeaderFieldButton_Click);
            // 
            // headerPresetComboBox
            // 
            this.headerPresetComboBox.FormattingEnabled = true;
            this.headerPresetComboBox.Items.AddRange(new object[] {
            "",
            "COMMENT",
            "HISTORY"});
            this.headerPresetComboBox.Location = new System.Drawing.Point(3, 16);
            this.headerPresetComboBox.Name = "headerPresetComboBox";
            this.headerPresetComboBox.Size = new System.Drawing.Size(121, 21);
            this.headerPresetComboBox.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Keyword Presets";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.key,
            this.value});
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(522, 423);
            this.dataGridView1.TabIndex = 25;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // key
            // 
            this.key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.key.DataPropertyName = "key";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key.DefaultCellStyle = dataGridViewCellStyle1;
            this.key.FillWeight = 40F;
            this.key.HeaderText = "Keyword";
            this.key.Name = "key";
            // 
            // value
            // 
            this.value.DataPropertyName = "value";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.value.DefaultCellStyle = dataGridViewCellStyle2;
            this.value.HeaderText = "Value";
            this.value.Name = "value";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.trimHeaderValueCheckbox);
            this.groupBox1.Location = new System.Drawing.Point(548, 386);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 101);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // trimHeaderValueCheckbox
            // 
            this.trimHeaderValueCheckbox.AutoSize = true;
            this.trimHeaderValueCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.trimHeaderValueCheckbox.Location = new System.Drawing.Point(6, 19);
            this.trimHeaderValueCheckbox.Name = "trimHeaderValueCheckbox";
            this.trimHeaderValueCheckbox.Size = new System.Drawing.Size(144, 18);
            this.trimHeaderValueCheckbox.TabIndex = 28;
            this.trimHeaderValueCheckbox.Text = "Pretty View (Read Only)";
            this.trimHeaderValueCheckbox.UseVisualStyleBackColor = true;
            this.trimHeaderValueCheckbox.CheckedChanged += new System.EventHandler(this.trimHeaderValueCheckbox_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(542, 508);
            this.tabControl1.TabIndex = 22;
            // 
            // fileHistoryListBox
            // 
            this.fileHistoryListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileHistoryListBox.FormattingEnabled = true;
            this.fileHistoryListBox.HorizontalScrollbar = true;
            this.fileHistoryListBox.Location = new System.Drawing.Point(548, 58);
            this.fileHistoryListBox.Name = "fileHistoryListBox";
            this.fileHistoryListBox.Size = new System.Drawing.Size(194, 290);
            this.fileHistoryListBox.Sorted = true;
            this.fileHistoryListBox.TabIndex = 27;
            this.fileHistoryListBox.SelectedIndexChanged += new System.EventHandler(this.fileHistoryListBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(545, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Files History";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // fileHistoryListClearButton
            // 
            this.fileHistoryListClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fileHistoryListClearButton.Location = new System.Drawing.Point(667, 357);
            this.fileHistoryListClearButton.Name = "fileHistoryListClearButton";
            this.fileHistoryListClearButton.Size = new System.Drawing.Size(75, 23);
            this.fileHistoryListClearButton.TabIndex = 30;
            this.fileHistoryListClearButton.Text = "Clear List";
            this.fileHistoryListClearButton.UseVisualStyleBackColor = true;
            this.fileHistoryListClearButton.Click += new System.EventHandler(this.fileHistoryListClearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(754, 542);
            this.Controls.Add(this.fileHistoryListClearButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fileHistoryListBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 499);
            this.Name = "Form1";
            this.Text = "Fits Header Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox consoleResultTextBox;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox trimHeaderValueCheckbox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn key;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ListBox fileHistoryListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button removeHeaderFieldButton;
        private System.Windows.Forms.Button addHeaderFieldButton;
        private System.Windows.Forms.ComboBox headerPresetComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button fileHistoryListClearButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button addDefaultHeaderButton;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addKeywordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeKeywordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDefaultHeadersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteFromClipboardToolStripMenuItem;
    }
}

