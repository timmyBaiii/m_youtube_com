namespace MYoutubeComApi.Models
{
    public class ResultModels
    {
        public bool isSuccess { get; set; }
        public object data { get; set; }
        public string message { get; set; }

        public ResultModels()
        {
            isSuccess = false;
            data = new object();
            message = string.Empty;
        }
    }
}
