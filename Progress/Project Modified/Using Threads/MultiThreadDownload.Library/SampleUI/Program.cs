using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MultiThreadDownload.Library;
namespace SampleUI
{
    class Program
    {
        public static void printmessage(string message,double bytes, int threadID)
        {
            Console.WriteLine($"{message} : {bytes} : {threadID}");
            
        }

        public static void GetExceptionMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void Main()
        {
            string[] urls = new string[] { "https://file-examples.com/wp-content/uploads/2017/10/file_example_ODP_1MB.odp",
        "http://www.quintic.com/software/sample_videos/AutoTracking_CyclingFV70rpm.avi",
        "http://www.quintic.com/software/sample_videos/AutoTracking_CyclingSV70rpm.avi",
        "http://www.quintic.com/software/sample_videos/Golf_Putting_AutoTracking.avi",
            "https://file-examples.com/wp-content/uploads/2018/04/file_example_AVI_1920_2_3MG.avi",
            "https://file-examples.com/wp-content/uploads/2017/04/file_example_MP4_1280_10MG.mp4",
            "https://file-examples.com/wp-content/uploads/2017/11/file_example_MP3_5MG.mp3",
            "https://file-examples.com/wp-content/uploads/2017/11/file_example_MP3_2MG.mp3",
            "https://file-examples.com/wp-content/uploads/2017/02/file-sample_500kB.docx",
            "http://mirrors.standaloneinstaller.com/video-sample/DLP_PART_2_768k.m4v",
            "http://mirrors.standaloneinstaller.com/video-sample/video-sample.m4v",
            "http://mirrors.standaloneinstaller.com/video-sample/grb_2.m4v",
            "http://mirrors.standaloneinstaller.com/video-sample/TRA3106.m4v",
            "http://mirrors.standaloneinstaller.com/video-sample/lion-sample.avi",
            "http://mirrors.standaloneinstaller.com/video-sample/page18-movie-4.avi"};
            message m = printmessage;
            exceptionMessage message = GetExceptionMessage;
            Helper h = new Helper(m, message);
            foreach (string url in urls)
            {
                h.InsertToQueue(url);
            }
            try
            {
                h.StartDownload();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            Thread.Sleep(200000);
        }
    }
}
