namespace MYoutubeComApi.Settings
{
    public class MysqlSettings
    {
        private static string server = "localhost";
        private static string port = "3306";
        private static string user = "root";
        private static string password = "mimic980011309";
        private static string database = "m_youtube_com";
        private static string sslM = "none";
        public static string connStr = String.Format("server={0}; port={1}; user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);
    }
}
