namespace FitsHeaderEditor
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ObjectTextBox = new System.Windows.Forms.TextBox();
            this.ObserverTextBox = new System.Windows.Forms.TextBox();
            this.TelescopeTextBox = new System.Windows.Forms.TextBox();
            this.InstrumeTextBox = new System.Windows.Forms.TextBox();
            this.DateTextBox = new System.Windows.Forms.TextBox();
            this.SettingOKButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Observer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Object";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Telescope";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Instruments";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Date";
            // 
            // ObjectTextBox
            // 
            this.ObjectTextBox.Location = new System.Drawing.Point(102, 39);
            this.ObjectTextBox.Name = "ObjectTextBox";
            this.ObjectTextBox.Size = new System.Drawing.Size(247, 22);
            this.ObjectTextBox.TabIndex = 5;
            // 
            // ObserverTextBox
            // 
            this.ObserverTextBox.Location = new System.Drawing.Point(102, 74);
            this.ObserverTextBox.Name = "ObserverTextBox";
            this.ObserverTextBox.Size = new System.Drawing.Size(247, 22);
            this.ObserverTextBox.TabIndex = 6;
            // 
            // TelescopeTextBox
            // 
            this.TelescopeTextBox.Location = new System.Drawing.Point(102, 110);
            this.TelescopeTextBox.Name = "TelescopeTextBox";
            this.TelescopeTextBox.Size = new System.Drawing.Size(247, 22);
            this.TelescopeTextBox.TabIndex = 7;
            // 
            // InstrumeTextBox
            // 
            this.InstrumeTextBox.Location = new System.Drawing.Point(102, 145);
            this.InstrumeTextBox.Name = "InstrumeTextBox";
            this.InstrumeTextBox.Size = new System.Drawing.Size(247, 22);
            this.InstrumeTextBox.TabIndex = 8;
            // 
            // DateTextBox
            // 
            this.DateTextBox.Location = new System.Drawing.Point(102, 182);
            this.DateTextBox.Name = "DateTextBox";
            this.DateTextBox.Size = new System.Drawing.Size(247, 22);
            this.DateTextBox.TabIndex = 9;
            // 
            // SettingOKButton
            // 
            this.SettingOKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingOKButton.Location = new System.Drawing.Point(240, 286);
            this.SettingOKButton.Name = "SettingOKButton";
            this.SettingOKButton.Size = new System.Drawing.Size(134, 34);
            this.SettingOKButton.TabIndex = 10;
            this.SettingOKButton.Text = "OK";
            this.SettingOKButton.UseVisualStyleBackColor = true;
            this.SettingOKButton.Click += new System.EventHandler(this.SettingOKButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.DateTextBox);
            this.groupBox1.Controls.Add(this.InstrumeTextBox);
            this.groupBox1.Controls.Add(this.TelescopeTextBox);
            this.groupBox1.Controls.Add(this.ObserverTextBox);
            this.groupBox1.Controls.Add(this.ObjectTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 236);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(99, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "YYYY-MM-DDThh:mm:ss.ss";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 332);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SettingOKButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(404, 379);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(404, 379);
            this.Name = "Settings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ObjectTextBox;
        private System.Windows.Forms.TextBox ObserverTextBox;
        private System.Windows.Forms.TextBox TelescopeTextBox;
        private System.Windows.Forms.TextBox InstrumeTextBox;
        private System.Windows.Forms.TextBox DateTextBox;
        private System.Windows.Forms.Button SettingOKButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
    }
}