using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using yoedgeForm.Data;
using yoedgeForm.HttpTool;
using yoedgeForm.HttpTool.Download;
using yoedgeForm.Managers;
using yoedgeForm.Util;

namespace yoedgeForm.Forms
{
    public partial class Main : Form
    {
        private string saveFolder = AppDomain.CurrentDomain.BaseDirectory;
        Dictionary<string, ChapterInfo> ChapterDic = new Dictionary<string, ChapterInfo>();

        public Main()
        {
            InitializeComponent();
        }

        private void btnGetComicIndex_Click(object sender, EventArgs e)
        {
            string strUrl = txtComicNo.Text.Trim();
            if (RegexHelper.CheckUrl(strUrl))
            {
                updateFileList(strUrl);
            }
            else
            {

            }
        }

        private void updateFileList(string url)
        {
            try
            {
                Info_Lab.Text = "获取数据中...";
                string pageString = Http.GetResponseText(url);
                var ChapterData = PageHelper.GetChapter(pageString,ref saveFolder);
                FilelistView.BeginUpdate();
                FilelistView.Items.Clear();
                ChapterDic.Clear();
                foreach (var item in ChapterData)
                {
                    ListViewItem liv = new ListViewItem(item.ChapterName);
                    liv.SubItems.Add(item.Guid);
                    FilelistView.Items.Add(liv);
                    this.ChapterDic.Add(item.Guid, item);
                    setEndItemImageKey("Dir2.png");
                }
                FilelistView.EndUpdate();
            }
            catch (Exception ex)
            {
            }
            Info_Lab.Text = "等待中";
        }

        void setEndItemImageKey(string key)
        {
            FilelistView.Items[FilelistView.Items.Count - 1].ImageKey = key;
        }

        private void InfoMenu_Opening(object sender, CancelEventArgs e)
        {
            if (FilelistView.SelectedIndices.Count <= 0)
            {
                e.Cancel = true;
                return;
            }
        }

        private void 全部下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var downitems = ChapterDic.Select(c => c.Value).ToList();
        }

        private void 下载所选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<ChapterInfo> downitems = new List<ChapterInfo>();
            for (int i = 0; i < FilelistView.SelectedIndices.Count; i++)
            {
                var item = FilelistView.SelectedItems[i];
                if (!ChapterDic.ContainsKey(item.SubItems[1].Text))
                {
                    MessageBox.Show("出现了未知错误! 请刷新重试");
                    return;
                }
                ChapterInfo info = ChapterDic[item.SubItems[1].Text];
                downitems.Add(info);
            }
            //下载
            if (downitems.Count>0)
            {
                StartDownload(downitems);
                tabControl1.SelectedIndex=1;
            }
        }


        private void UpdateDownLoadList_Timer_Tick(object sender, EventArgs e)
        {
            DownloadListView.BeginUpdate();
            foreach (HttpDownload Task in TaskManager.GetTastManager.GetTaskList())
            {
                if (DownloadListView.Items.Count == Task.ID)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = Task.ID.ToString();
                    item.SubItems.Add(Task.DownloadPath.Split('\\')[Task.DownloadPath.Split('\\').Length - 1]);
                    item.SubItems.Add(Task.DownloadPath);
                    item.SubItems.Add((getSizeMB((long)Task.Speed) < 1 ? (Task.Speed / 1024) + "K/s" : getSizeMB((long)Task.Speed) + "M/s"));
                    item.SubItems.Add(Task.Percentage + "%");
                    item.SubItems.Add(Task.Downloading ? "下载中" : Task.Completed ? "下载完成" : "暂停中");
                    DownloadListView.Items.Add(item);
                    continue;
                }
                DownloadListView.Items[Task.ID].SubItems[3].Text = Task.Completed ? "0K/s" : (getSizeMB((long)Task.Speed) < 1 ? (Task.Speed / 1024) + "K/s" : getSizeMB((long)Task.Speed) + "M/s");
                DownloadListView.Items[Task.ID].SubItems[4].Text = Task.Completed ? "100%" : Task.Percentage + "%";
                DownloadListView.Items[Task.ID].SubItems[5].Text = Task.Downloading ? "下载中" : Task.Completed ? "下载完成" : "暂停中";
            }
            DownloadListView.EndUpdate();
            return;

        }

        private void StartDownload(List<ChapterInfo> downitems)
        {
            foreach (var item in downitems)
            {
                string pageString = Http.GetResponseText(item.ChapterJsonUrl);
                var mp = Regex.Match(pageString, "\\\"page\\\"\\:(?<data>{.*})\\,\\\"resource", RegexOptions.IgnoreCase);
                if (mp.Success)
                {
                    string imgPaths = mp.Groups["data"].Value;
                    JObject request = JsonConvert.DeserializeObject<dynamic>(imgPaths);
                    string savePath = saveFolder + item.ChapterName;
                    if (!System.IO.Directory.Exists(savePath))
                    {
                        System.IO.Directory.CreateDirectory(savePath);
                    }
                    List<string> orderPath = new List<string>();
                    foreach (var v in request){orderPath.Add(v.Value.ToString());}
                    //int index = 0;
                    foreach (var v in orderPath.OrderBy(c => c))
                    {
                        //if (index > 0) { break; }index++;
                        TaskManager.GetTastManager.CreateDownloadTask(
                            $"http://smp.yoedge.com/smp-app/{ item.ChapterNo }/shinmangaplayer/{v}",
                            savePath + "\\" + v.GetFileName(), item.Url, 1);
                    }
                   
                }
            }
        }


        float getSizeGB(long byt)
        {
            return (float)byt / 1024 / 1024 / 1024;
        }

        float getSizeMB(long byt)
        {
            return (float)byt / 1024 / 1024;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}