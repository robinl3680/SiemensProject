namespace MultiThreadedDownloader.UserInterface
{
    partial class UserInterface
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
            this.btn_download = new System.Windows.Forms.Button();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.lbl_url = new System.Windows.Forms.Label();
            this.prgs_download = new System.Windows.Forms.ProgressBar();
            this.lbl_prgrs = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_download
            // 
            this.btn_download.Location = new System.Drawing.Point(899, 140);
            this.btn_download.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(100, 26);
            this.btn_download.TabIndex = 0;
            this.btn_download.Text = "Download";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.Btn_download_Click);
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(484, 142);
            this.txt_url.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(407, 22);
            this.txt_url.TabIndex = 1;
            this.txt_url.TextChanged += new System.EventHandler(this.Txt_url_TextChanged);
            // 
            // lbl_url
            // 
            this.lbl_url.AutoSize = true;
            this.lbl_url.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_url.Location = new System.Drawing.Point(185, 138);
            this.lbl_url.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_url.Name = "lbl_url";
            this.lbl_url.Size = new System.Drawing.Size(237, 26);
            this.lbl_url.TabIndex = 2;
            this.lbl_url.Text = "Enter URL to download";
            // 
            // prgs_download
            // 
            this.prgs_download.Location = new System.Drawing.Point(497, 249);
            this.prgs_download.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.prgs_download.Name = "prgs_download";
            this.prgs_download.Size = new System.Drawing.Size(408, 28);
            this.prgs_download.TabIndex = 3;
            // 
            // lbl_prgrs
            // 
            this.lbl_prgrs.AutoSize = true;
            this.lbl_prgrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_prgrs.Location = new System.Drawing.Point(185, 250);
            this.lbl_prgrs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_prgrs.Name = "lbl_prgrs";
            this.lbl_prgrs.Size = new System.Drawing.Size(121, 24);
            this.lbl_prgrs.TabIndex = 4;
            this.lbl_prgrs.Text = "Downloading";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(209, 321);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(725, 160);
            this.dataGridView1.TabIndex = 5;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 554);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbl_prgrs);
            this.Controls.Add(this.prgs_download);
            this.Controls.Add(this.lbl_url);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.btn_download);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserInterface";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Label lbl_url;
        private System.Windows.Forms.ProgressBar prgs_download;
        private System.Windows.Forms.Label lbl_prgrs;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

