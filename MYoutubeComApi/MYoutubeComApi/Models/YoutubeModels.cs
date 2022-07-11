using System;
using MySql.Data.MySqlClient;
using Dapper;

namespace MYoutubeComApi.Models
{
    /// <summary>
    /// youtube
    /// </summary>
    public class YoutubeModels
    {
        private MySqlConnection conn;
        private string sql = string.Empty;

        public YoutubeModels(MySqlConnection _conn)
        {
            conn = _conn;
        }

        /// <summary>
        /// 取得所有影片 "合併" 喜歡影片
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetYoutubeList<T>()
        {
            sql = @"SELECT id,
                           title,
                           image,
                           movieLink,
                           channelName,
                           channelLink,
                           youtubeLogo,
                           viewers,
                           movieType,
                           love
                      FROM youtube
                 LEFT OUTER love ON youtube.id = love.id
            ";

            return conn.Query<T>(sql).ToList();
        }
    }

    #region 接收模型
    
    

    #endregion
}
