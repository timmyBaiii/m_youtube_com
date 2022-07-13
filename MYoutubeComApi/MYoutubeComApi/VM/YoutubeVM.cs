namespace MYoutubeComApi.VM
{
    public class YoutubeListVM
    {
        /// <summary>
        /// 影片 id
        /// </summary>
        public int movieId { get; set; }

        /// <summary>
        /// 影片標題
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 影片圖片
        /// </summary>
        public string image { get; set; }

        /// <summary>
        /// 影片連結
        /// </summary>
        public string movieLink { get; set; }

        /// <summary>
        /// youtube 名稱
        /// </summary>
        public string channelName { get; set; }

        /// <summary>
        /// youtube 連結
        /// </summary>
        public string channelLink { get; set; }

        /// <summary>
        /// youtube 圖示
        /// </summary>
        public string youtubeLogo { get; set; }

        /// <summary>
        /// 觀看人數
        /// </summary>
        public string viewers { get; set; }

        /// <summary>
        /// 影片類型
        /// </summary>
        public string movieType { get; set; }

        /// <summary>
        /// 喜歡影片
        /// </summary>
        public bool love { get; set; }
    }
}
