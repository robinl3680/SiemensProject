using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
using System.Net;

namespace MultiThreadDownload.Library
{
    public delegate void message(string name,double bytes);
    public class Helper
    {
        Mutex mutex;
        Queue<string> urls;
        List<Thread> threads;
        message m;
        
        //public void CreateThread()
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        ParameterizedThreadStart threadDelegate =
        //        new ParameterizedThreadStart((obj) => DownloadUsingThread(obj, m));
        //        Thread t = new Thread(threadDelegate);
        //        threads.Add(t);
        //    }
        //}
        public Helper(message m)
        {
            
            mutex = new Mutex();
            this.m = m;
            urls = new Queue<string>();
            threads = new List<Thread>();
           // CreateThread();
        }
        public Helper(Queue<string> urls)
        {
            
            this.urls = urls;
        }

        public void StartDownload()
        {
            //ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(5, 5);
            foreach(string url in urls)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(DownloadUsingThread), url); 
            }
            
        }

        public void InsertToQueue(string url)
        {
            urls.Enqueue(url);
            
            
        }

        public void DownloadFile(string url,message m)
        {
            WebClient client = new WebClient();
            string[] parts = url.ToString().Split('/');
            string fname = parts.Last();
            client.DownloadFile(url.ToString(), $"{ConfigurationManager.AppSettings["FILE_PATH"]}\\{fname}");
            double totalSizeBytes = Convert.ToDouble(client.ResponseHeaders["Content-Length"]);
            m(fname, totalSizeBytes);
        }

        //public void DownloadStart()
        //{
        //    while(true)
        //    {
        //        foreach (var thread in threads)
        //        {
        //            if (!thread.IsAlive)
        //            {
        //                if (urls.Count > 0)
        //                {
        //                    mutex.WaitOne();
        //                    thread.Start(urls.First());
        //                    urls.Dequeue();
        //                    mutex.ReleaseMutex();
        //                }
        //                else
        //                {
        //                    return;
        //                }

        //            }
                    
                     
        //        }

        //        threads.Clear();
        //       // CreateThread();

        //    }

        //}
        public void DownloadUsingThread(object url)
        {
            mutex.WaitOne();
            DownloadFile(url.ToString(), m);
            mutex.ReleaseMutex();
        }

    }
}
