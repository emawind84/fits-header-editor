﻿namespace FitsHeaderEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "*.fit|*.fits";
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
            this.aboutToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1005, 28);
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
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.toolStripMenuItem1.Text = "Settings";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(178, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(715, 593);
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
            this.consoleResultTextBox.Location = new System.Drawing.Point(7, 4);
            this.consoleResultTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.consoleResultTextBox.Multiline = true;
            this.consoleResultTextBox.Name = "consoleResultTextBox";
            this.consoleResultTextBox.ReadOnly = true;
            this.consoleResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.consoleResultTextBox.Size = new System.Drawing.Size(700, 580);
            this.consoleResultTextBox.TabIndex = 25;
            this.consoleResultTextBox.WordWrap = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(715, 593);
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
            this.panel1.Location = new System.Drawing.Point(8, 535);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 49);
            this.panel1.TabIndex = 32;
            // 
            // addDefaultHeaderButton
            // 
            this.addDefaultHeaderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addDefaultHeaderButton.Location = new System.Drawing.Point(482, 18);
            this.addDefaultHeaderButton.Margin = new System.Windows.Forms.Padding(4);
            this.addDefaultHeaderButton.Name = "addDefaultHeaderButton";
            this.addDefaultHeaderButton.Size = new System.Drawing.Size(162, 28);
            this.addDefaultHeaderButton.TabIndex = 34;
            this.addDefaultHeaderButton.Text = "Add Default Headers";
            this.addDefaultHeaderButton.UseVisualStyleBackColor = true;
            this.addDefaultHeaderButton.Click += new System.EventHandler(this.AddDefaultHeaderButtonOnClick);
            // 
            // removeHeaderFieldButton
            // 
            this.removeHeaderFieldButton.Image = ((System.Drawing.Image)(resources.GetObject("removeHeaderFieldButton.Image")));
            this.removeHeaderFieldButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeHeaderFieldButton.Location = new System.Drawing.Point(309, 18);
            this.removeHeaderFieldButton.Margin = new System.Windows.Forms.Padding(4);
            this.removeHeaderFieldButton.Name = "removeHeaderFieldButton";
            this.removeHeaderFieldButton.Size = new System.Drawing.Size(165, 28);
            this.removeHeaderFieldButton.TabIndex = 33;
            this.removeHeaderFieldButton.Text = "Remove Keyword(s)";
            this.removeHeaderFieldButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.removeHeaderFieldButton.UseVisualStyleBackColor = true;
            this.removeHeaderFieldButton.Click += new System.EventHandler(this.removeHeaderFieldButton_Click);
            // 
            // addHeaderFieldButton
            // 
            this.addHeaderFieldButton.Image = ((System.Drawing.Image)(resources.GetObject("addHeaderFieldButton.Image")));
            this.addHeaderFieldButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addHeaderFieldButton.Location = new System.Drawing.Point(173, 18);
            this.addHeaderFieldButton.Margin = new System.Windows.Forms.Padding(4);
            this.addHeaderFieldButton.Name = "addHeaderFieldButton";
            this.addHeaderFieldButton.Size = new System.Drawing.Size(128, 28);
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
            this.headerPresetComboBox.Location = new System.Drawing.Point(4, 20);
            this.headerPresetComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.headerPresetComboBox.Name = "headerPresetComboBox";
            this.headerPresetComboBox.Size = new System.Drawing.Size(160, 24);
            this.headerPresetComboBox.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
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
            this.dataGridView1.Location = new System.Drawing.Point(8, 7);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(696, 521);
            this.dataGridView1.TabIndex = 25;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // key
            // 
            this.key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.key.DataPropertyName = "key";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key.DefaultCellStyle = dataGridViewCellStyle3;
            this.key.FillWeight = 40F;
            this.key.HeaderText = "Keyword";
            this.key.Name = "key";
            // 
            // value
            // 
            this.value.DataPropertyName = "value";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.value.DefaultCellStyle = dataGridViewCellStyle4;
            this.value.HeaderText = "Value";
            this.value.Name = "value";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.trimHeaderValueCheckbox);
            this.groupBox1.Location = new System.Drawing.Point(731, 475);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(259, 124);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // trimHeaderValueCheckbox
            // 
            this.trimHeaderValueCheckbox.AutoSize = true;
            this.trimHeaderValueCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.trimHeaderValueCheckbox.Location = new System.Drawing.Point(8, 17);
            this.trimHeaderValueCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.trimHeaderValueCheckbox.Name = "trimHeaderValueCheckbox";
            this.trimHeaderValueCheckbox.Size = new System.Drawing.Size(184, 22);
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
            this.tabControl1.Location = new System.Drawing.Point(0, 41);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(723, 625);
            this.tabControl1.TabIndex = 22;
            // 
            // fileHistoryListBox
            // 
            this.fileHistoryListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileHistoryListBox.FormattingEnabled = true;
            this.fileHistoryListBox.HorizontalScrollbar = true;
            this.fileHistoryListBox.ItemHeight = 16;
            this.fileHistoryListBox.Location = new System.Drawing.Point(731, 63);
            this.fileHistoryListBox.Margin = new System.Windows.Forms.Padding(4);
            this.fileHistoryListBox.Name = "fileHistoryListBox";
            this.fileHistoryListBox.Size = new System.Drawing.Size(257, 340);
            this.fileHistoryListBox.Sorted = true;
            this.fileHistoryListBox.TabIndex = 27;
            this.fileHistoryListBox.SelectedIndexChanged += new System.EventHandler(this.fileHistoryListBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(727, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
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
            this.fileHistoryListClearButton.Location = new System.Drawing.Point(889, 412);
            this.fileHistoryListClearButton.Margin = new System.Windows.Forms.Padding(4);
            this.fileHistoryListClearButton.Name = "fileHistoryListClearButton";
            this.fileHistoryListClearButton.Size = new System.Drawing.Size(100, 28);
            this.fileHistoryListClearButton.TabIndex = 30;
            this.fileHistoryListClearButton.Text = "Clear List";
            this.fileHistoryListClearButton.UseVisualStyleBackColor = true;
            this.fileHistoryListClearButton.Click += new System.EventHandler(this.fileHistoryListClearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1005, 667);
            this.Controls.Add(this.fileHistoryListClearButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fileHistoryListBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(794, 605);
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
    }
}

