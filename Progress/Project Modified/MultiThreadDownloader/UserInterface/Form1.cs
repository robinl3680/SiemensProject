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
using MultiThreadDownloader;
using System.Security.Permissions;
using System.IO;
using System.Configuration;

namespace UserInterface
{
    public partial class Form1 : Form
    {


        DownloadHelper download;
        Dictionary<string, double> displays = new Dictionary<string, double>();
        Dictionary<string, string> status = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Bytes", "Bytes");
            dataGridView1.Columns.Add("Status", "Status");
        }


        public void UpdateProgress(FileInfo[] files)
        {
            foreach(var item in files)
            {
                displays[item.Name] = item.Length;
                if (dataGridView1.Rows.Count > 1)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != String.Empty)
                        {
                            if (displays.ContainsKey(row.Cells[0].Value.ToString()) && row.Cells[0].Value.ToString() == item.Name)
                            {
                                row.Cells[1].Value = item.Length;
                                //row.Cells[2].Value = $"{displayProgress.PercentageCompleted}%";
                                break;
                            }
                        }
                        else
                        {
                            dataGridView1.Rows.Add(item.Name, item.Length);
                            break;
                        }
                    }
                }
                else
                {
                    dataGridView1.Rows.Add(item.Name, item.Length);
                }
            }

        }

        public void PrintMessage(string message)
        {
            MessageBox.Show(message);
        }
        public void DisplayMessage(string fileName)
        {
            status[fileName] = "Completed";
            if (dataGridView1.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != String.Empty)
                    {
                        if (status.ContainsKey(row.Cells[0].Value.ToString()) && row.Cells[0].Value.ToString() == fileName)
                        {

                            row.Cells[2].Value = status[fileName];
                            break;
                        }
                    }
                }
            }
        }




        private void Button1_Click(object sender, EventArgs e)
        {
            //string url = txt_url.Text;
            download = new DownloadHelper();
            HelperDownload h = this.UpdateProgress;
            //DownloadComplete d = this.DisplayMessage;
            //IntenetSlow slow = this.PrintMessage;
            string[] urls = { "https://file-examples.com/wp-content/uploads/2017/04/file_example_MP4_1280_10MG.mp4",
                "https://file-examples.com/wp-content/uploads/2017/10/file_example_ODP_1MB.odp",
                "https://file-examples.com/wp-content/uploads/2017/02/zip_10MB.zip",
                 "https://file-examples.com/wp-content/uploads/2017/04/file_example_MP4_1920_18MG.mp4"};

           
            try

            {
                List<Task> threads = new List<Task>();
                Task t;
                foreach (string url in urls)
                {
                    download = new DownloadHelper();
                    t = download.DownloadHelperDownloadAsync(url);
                    
                }


                download.FileWatcher(h);


                //downloader.DownloadHelperDownloadAsync(url, h, d, slow);
                //Task.WaitAll(threads.ToArray());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        //private static void OnChanged(object source, FileSystemEventArgs e) =>
        //// Specify what is done when a file is changed, created, or deleted.
        //MessageBox.Show($"File: {e.FullPath.Length} {e.Name}");

        //private static void OnRenamed(object source, RenamedEventArgs e) =>
        //    // Specify what is done when a file is renamed.
        //    MessageBox.Show($"File: {e.OldFullPath} renamed to {e.FullPath}");
    }
    
}
