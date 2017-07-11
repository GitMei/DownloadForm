using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yoedgeForm.HttpTool.Download
{
    class HttpDownload
    {
        #region 参数
        /// <summary>
        /// 任务ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 下载链接
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 下载路径
        /// </summary>
        public string DownloadPath { get; set; }
        /// <summary>
        /// 线程数
        /// </summary>
        public int ThreadNum { get; set; }
        /// <summary>
        /// 下载速度
        /// </summary>
        public long Speed { get; private set; } = 0L;
        /// <summary>
        /// 下载进度
        /// </summary>
        public float Percentage { get; private set; } = 0F;
        /// <summary>
        /// 是否下载中
        /// </summary>
        public bool Downloading { get; private set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public bool Completed { get; private set; }
        /// <summary>
        /// 是否终止
        /// </summary>
        public bool Stoped { get; private set; }
        public string NeedReferer { get; set; }

        private string defUA = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36";
        #endregion

        DownloadThread[] Threads;
        DownloadInfo Info;
        /// <summary>
        /// 开始下载
        /// </summary>
        public void Start()
        {
            try
            {
                Downloading = true;
                Stoped = false;
                HttpWebRequest Request = WebRequest.Create(Url) as HttpWebRequest;
                Request.UserAgent = defUA;

                Request.Referer = NeedReferer;
                HttpWebResponse Response = Request.GetResponse() as HttpWebResponse;
                Info = new DownloadInfo
                {
                    ContentLength = Response.ContentLength,
                    BlockLength = Response.ContentLength / ThreadNum,
                    DownloadUrl = Url
                };
                Info.init(DownloadPath + ".dcj");
                if (Info.Completed)
                {
                    Downloading = false;
                    Completed = true;
                    Percentage = 100F;
                    return;
                }
                if (!File.Exists(DownloadPath))
                {
                    //LogTool.WriteLogDebug(typeof(HttpDownload), "正在创建文件: " + DownloadPath);
                    FileStream Stream = new FileStream(DownloadPath, FileMode.CreateNew);
                    Stream.SetLength(Response.ContentLength);
                    Stream.Close();
                }
                Threads = new DownloadThread[Info.DownloadBlockList.Count];
                for (int i = 0; i < Info.DownloadBlockList.Count; i++)
                {
                    DownloadBlock Block = (DownloadBlock)Info.DownloadBlockList[i];
                    Threads[i] = new DownloadThread
                    {
                        ID = i,
                        DownloadUrl = Url,
                        Path = DownloadPath,
                        Block = Block,
                        NeedReferer= NeedReferer,
                        Info = Info
                    };
                    Threads[i].ThreadCompletedEvent += HttpDownload_ThreadCompletedEvent;
                }
                new Thread(a).Start();
            }
            catch (Exception ex)
            {
                    Downloading = false;
                Stoped = true;
                //LogTool.WriteLogError(typeof(HttpDownload), "创建下载任务出现错误", ex);
            }
        }

        int CompletedThread = 0;
        private void HttpDownload_ThreadCompletedEvent()
        {
            lock (this)
            {
                CompletedThread++;
                if (CompletedThread >= Threads.Length)
                {
                    Downloading = false;
                    Completed = true;
                    Speed = 0L;
                    Percentage = 100F;
                    Info.Completed = true;
                }
            }
        }

        public void a()
        {
            long temp = 0L;
            while (Downloading)
            {
                Thread.Sleep(1000);
                if (temp == 0)
                {
                    temp = Info.CompletedLength;
                }
                else
                {
                    Speed = Info.CompletedLength - temp;
                    Percentage = (((float)Info.CompletedLength / (float)Info.ContentLength) * 100);
                    temp = Info.CompletedLength;
                    //Console.WriteLine("速度: " + Speed / 1024 / 1024+"MB/S\r\n进度: "+((float)Info.CompletedLength/(float)Info.ContentLength)*100);
                }
            }
        }
        /// <summary>
        /// 保存并结束
        /// </summary>
        public void StopAndSave()
        {
            if (Threads != null)
            {
                Downloading = false;
                Stoped = true;
                CompletedThread = 0;
                foreach (var Thread in Threads)
                {
                    Thread.Stop();
                }
            }
        }
    }
}
