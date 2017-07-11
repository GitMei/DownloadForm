using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using yoedgeForm.HttpTool.Download;
using yoedgeForm.Util.FileTool;

namespace yoedgeForm.Managers
{
    class TaskManager
    {
        public static TaskManager GetTastManager { get; } = new TaskManager();

        Timer TaskManagerTimer = new Timer(1000)
        {
            AutoReset = true,
            Enabled = true
        };

        public TaskManager()
        {
            TaskManagerTimer.Elapsed += TaskManagerTimer_Elapsed;
            TaskManagerTimer.Start();
        }

        Dictionary<int, HttpDownload> TaskList = new Dictionary<int, HttpDownload>();

        bool Flag = false;

        private void TaskManagerTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Flag)
            {
                return;
            }
            if (GetDwonloadingTaskNum() < Program.config.TaskNum)
            {
                var WaitTask = TaskList.Where(v => (!v.Value.Completed && !v.Value.Downloading && !v.Value.Stoped));
                foreach (var task in WaitTask)
                {
                    task.Value.Start();
                    return;
                }
            }
        }

        /// <summary>
        /// 创建一个下载任务
        /// </summary>
        /// <param name="DownloadUrl"></param>
        /// <param name="DownloadPath"></param>
        /// <param name="ThreadNum"></param>
        public void CreateDownloadTask(string DownloadUrl, string DownloadPath,string NeedReferer, int ThreadNum = 0)
        {
            if (File.Exists(DownloadPath))
            {
                return;
            }
            Flag = true;
            var Task = new HttpDownload
            {
                ID = TaskList.Count,
                Url = DownloadUrl,
                DownloadPath = DownloadPath,
                NeedReferer = NeedReferer,
                ThreadNum = ThreadNum == 0 ? Program.config.NetSpeed : ThreadNum
            };
            TaskList.Add(TaskList.Count, Task);
            Flag = false;
        }

        /// <summary>
        /// 结束所有任务并保存
        /// </summary>
        public void StopAndSave()
        {
            TaskManagerTimer.Stop();
            var DownloadingTask = TaskList.Where(v => v.Value.Downloading);
            foreach (var task in DownloadingTask)
            {
                task.Value.StopAndSave();
            }
        }

        /// <summary>
        /// 获取下载中的任务数
        /// </summary>
        /// <returns></returns>
        public int GetDwonloadingTaskNum()
        {
            return TaskList.Where(v => v.Value.Downloading).Count();
        }

        
        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetTaskList()
        {
            ArrayList Temp = new ArrayList();
            foreach (var Task in TaskList)
            {
                Temp.Add(Task.Value);
            }
            return Temp;
        }

        /// <summary>
        /// 通过ID获取任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpDownload GetTaskByID(int id)
        {
            if (!TaskList.ContainsKey(id))
            {
                return null;
            }
            return TaskList[id];
        }

        /// <summary>
        /// 通过ID获取任务速度
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public long GetSpeedByID(int id)
        {
            return 0L;
        }
    }
}
