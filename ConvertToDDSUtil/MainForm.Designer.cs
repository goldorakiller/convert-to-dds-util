namespace ConvertToDDSUtil
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
            this.fbdSelectDestination = new System.Windows.Forms.FolderBrowserDialog();
            this.ofdSelectFiles = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectFiles = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lstSelectedFiles = new System.Windows.Forms.ListBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.btnClearDestination = new System.Windows.Forms.Button();
            this.cbClearList = new System.Windows.Forms.CheckBox();
            this.cbExceptFailed = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ofdSelectFiles
            // 
            this.ofdSelectFiles.Filter = "Image Files (*.jpeg, *.jpg, *.png)|*.jpeg;*.jpg;*.png|All files (*.*)|*.*";
            this.ofdSelectFiles.Multiselect = true;
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Location = new System.Drawing.Point(13, 13);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(257, 49);
            this.btnSelectFiles.TabIndex = 0;
            this.btnSelectFiles.Text = "Select file(s)";
            this.btnSelectFiles.UseVisualStyleBackColor = true;
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(302, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(257, 49);
            this.button2.TabIndex = 1;
            this.button2.Text = "Select destination";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnSelectDestination_Click);
            // 
            // lstSelectedFiles
            // 
            this.lstSelectedFiles.FormattingEnabled = true;
            this.lstSelectedFiles.HorizontalScrollbar = true;
            this.lstSelectedFiles.ItemHeight = 16;
            this.lstSelectedFiles.Location = new System.Drawing.Point(12, 114);
            this.lstSelectedFiles.Name = "lstSelectedFiles";
            this.lstSelectedFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSelectedFiles.Size = new System.Drawing.Size(547, 228);
            this.lstSelectedFiles.TabIndex = 2;
            this.lstSelectedFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstSelectedFiles_KeyUp);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(12, 404);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(547, 49);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "Convert listed files";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(12, 76);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.ReadOnly = true;
            this.txtDestination.Size = new System.Drawing.Size(434, 22);
            this.txtDestination.TabIndex = 4;
            // 
            // btnClearDestination
            // 
            this.btnClearDestination.Location = new System.Drawing.Point(453, 76);
            this.btnClearDestination.Name = "btnClearDestination";
            this.btnClearDestination.Size = new System.Drawing.Size(106, 22);
            this.btnClearDestination.TabIndex = 5;
            this.btnClearDestination.Text = "Clear";
            this.btnClearDestination.UseVisualStyleBackColor = true;
            this.btnClearDestination.Click += new System.EventHandler(this.btnClearDestination_Click);
            // 
            // cbClearList
            // 
            this.cbClearList.AutoSize = true;
            this.cbClearList.Location = new System.Drawing.Point(13, 349);
            this.cbClearList.Name = "cbClearList";
            this.cbClearList.Size = new System.Drawing.Size(190, 21);
            this.cbClearList.TabIndex = 6;
            this.cbClearList.Text = "Clear list after conversion";
            this.cbClearList.UseVisualStyleBackColor = true;
            this.cbClearList.CheckedChanged += new System.EventHandler(this.cbClearList_CheckedChanged);
            // 
            // cbExceptFailed
            // 
            this.cbExceptFailed.AutoSize = true;
            this.cbExceptFailed.Location = new System.Drawing.Point(13, 377);
            this.cbExceptFailed.Name = "cbExceptFailed";
            this.cbExceptFailed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbExceptFailed.Size = new System.Drawing.Size(160, 21);
            this.cbExceptFailed.TabIndex = 7;
            this.cbExceptFailed.Text = "... except failed ones";
            this.cbExceptFailed.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 464);
            this.Controls.Add(this.cbExceptFailed);
            this.Controls.Add(this.cbClearList);
            this.Controls.Add(this.btnClearDestination);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.lstSelectedFiles);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSelectFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Convert to DDS Utility";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdSelectDestination;
        private System.Windows.Forms.OpenFileDialog ofdSelectFiles;
        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox lstSelectedFiles;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Button btnClearDestination;
        private System.Windows.Forms.CheckBox cbClearList;
        private System.Windows.Forms.CheckBox cbExceptFailed;
    }
}

