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
        Dictionary<string, double> displays = new Dictionary<string, double>();
        public UserInterface()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Bytes", "Bytes");
        }
        public void UpdateProgress(string fileName,double x,int y)
        {
            prgs_download.Value = y;
            lbl_prgrs.Text = fileName;
            //DisplayClass display = new DisplayClass { FileName = fileName, ByteReceived = x };
            //List<DisplayClass> displays = new List<DisplayClass> { display };
            displays[fileName] = x;
            var datasource = from a in displays
                             select new
                             { Name = a.Key, ByteReceived = a.Value };
            dataGridView1.Rows.Add(datasource.ToArray());
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
