namespace LateBindingWordSaveAs
{
    partial class MainForm
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
            this.BrowseButton = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveAsButton = new System.Windows.Forms.Button();
            this.Formats = new System.Windows.Forms.Label();
            this.formatsList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.savePathTextBox = new System.Windows.Forms.TextBox();
            this.BrowseSaveButton = new System.Windows.Forms.Button();
            this.resultNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(329, 5);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(26, 20);
            this.BrowseButton.TabIndex = 0;
            this.BrowseButton.Text = "...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(88, 6);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(235, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path to file:";
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.Location = new System.Drawing.Point(280, 93);
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size(75, 23);
            this.SaveAsButton.TabIndex = 3;
            this.SaveAsButton.Text = "Save As";
            this.SaveAsButton.UseVisualStyleBackColor = true;
            this.SaveAsButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // Formats
            // 
            this.Formats.AutoSize = true;
            this.Formats.Location = new System.Drawing.Point(12, 103);
            this.Formats.Name = "Formats";
            this.Formats.Size = new System.Drawing.Size(47, 13);
            this.Formats.TabIndex = 5;
            this.Formats.Text = "Formats:";
            // 
            // formatsList
            // 
            this.formatsList.FormattingEnabled = true;
            this.formatsList.Location = new System.Drawing.Point(88, 95);
            this.formatsList.Name = "formatsList";
            this.formatsList.Size = new System.Drawing.Size(121, 21);
            this.formatsList.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Path to save:";
            // 
            // savePathTextBox
            // 
            this.savePathTextBox.Location = new System.Drawing.Point(88, 42);
            this.savePathTextBox.Name = "savePathTextBox";
            this.savePathTextBox.Size = new System.Drawing.Size(235, 20);
            this.savePathTextBox.TabIndex = 8;
            // 
            // BrowseSaveButton
            // 
            this.BrowseSaveButton.Location = new System.Drawing.Point(329, 42);
            this.BrowseSaveButton.Name = "BrowseSaveButton";
            this.BrowseSaveButton.Size = new System.Drawing.Size(26, 20);
            this.BrowseSaveButton.TabIndex = 9;
            this.BrowseSaveButton.Text = "...";
            this.BrowseSaveButton.UseVisualStyleBackColor = true;
            this.BrowseSaveButton.Click += new System.EventHandler(this.BrowseSaveButton_Click);
            // 
            // resultNameTextBox
            // 
            this.resultNameTextBox.Location = new System.Drawing.Point(88, 68);
            this.resultNameTextBox.Name = "resultNameTextBox";
            this.resultNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.resultNameTextBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Result name:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 137);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resultNameTextBox);
            this.Controls.Add(this.BrowseSaveButton);
            this.Controls.Add(this.savePathTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.formatsList);
            this.Controls.Add(this.Formats);
            this.Controls.Add(this.SaveAsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.BrowseButton);
            this.Name = "MainForm";
            this.Text = "Word SaveAs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveAsButton;
        private System.Windows.Forms.Label Formats;
        private System.Windows.Forms.ComboBox formatsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox savePathTextBox;
        private System.Windows.Forms.Button BrowseSaveButton;
        private System.Windows.Forms.TextBox resultNameTextBox;
        private System.Windows.Forms.Label label3;
    }
}

