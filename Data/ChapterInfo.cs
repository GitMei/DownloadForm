namespace yoedgeForm.Data
{
    public class ChapterInfo
    {
        private string baseUrl = "http://smp.yoedge.com/smp-app/{0}/shinmangaplayer/{1}";
        public string ChapterJsonUrl
        {
            get { return string.Format(baseUrl, ChapterNo, "smp_cfg.json"); }
        }
        public string ChapterName { get; set; }
        public string Url { get; set; }
        public int ChapterNo { get; set; }
        public string Guid { get; set; }
    }
}
