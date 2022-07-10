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

        public IEnumerable<T> GetYoutubeList<T>()
        {
            sql = @"SELECT *
                           FROM youtube
                           LEFT OUTER love ON youtube.id = love.id                   
            ";

            return conn.Query<T>(sql);
        }
    }
}
