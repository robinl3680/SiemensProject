using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MultiThreadedDownloader.MultiDownloaderLibrary;
using Supporter;
namespace MultiThreadedDownloader.UserInterface
{
    public partial class UserInterface : Form
    {
        MultiThreadDownloader downloader;
        public UserInterface()
        {
            InitializeComponent();
        }
        public void UpdateProgress(string fileName,double x)
        {
            //prgs_download.Value = x;
            lbl_prgrs.Text = fileName;
            DisplayClass display = new DisplayClass { FileName = fileName, ByteReceived = x };
            List<DisplayClass> displays = new List<DisplayClass> { display };
            var datasource = from a in displays
                             select new
                             { Name = a.FileName, ByteReceived = a.ByteReceived };
            dataGridView1.DataSource = datasource.ToArray();
        }
        public void DisplayMessage(string fileName)
        {
            MessageBox.Show($"Downloaded : {fileName}");
        }
        private void Btn_download_Click(object sender, EventArgs e)
        {
            string url = txt_url.Text;
            downloader = new MultiThreadDownloader();
            HelperDownload h = this.UpdateProgress;
            DownloadComplete d = this.DisplayMessage;
            downloader.DownloadHelperDownload(url,h,d);
        }

        private void Txt_url_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
