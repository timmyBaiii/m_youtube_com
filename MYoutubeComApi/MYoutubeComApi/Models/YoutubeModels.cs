using System;
using System.ComponentModel.DataAnnotations;
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
            sql = @"SELECT movies.movieId,
                           movies.title,
                           movies.image,
                           movies.movieLink,
                           movies.channelName,
                           movies.channelLink,
                           movies.youtubeLogo,
                           movies.viewers,
                           movies.movieType,
                           if (movies.movieId = love.loveId, 1, 0) as love
                      FROM movies
                 LEFT OUTER JOIN love ON movies.movieId = love.loveId
            ";

            return conn.Query<T>(sql).ToList();
        }

        /// <summary>
        /// 新增喜歡影片
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertLoveYoutube(InsertYoutubeRequest obj)
        {
            sql = @"INSERT INTO love (loveId, title) SELECT @loveId, @title FROM DUAL WHERE NOT EXISTS (
	                    SELECT loveId FROM love WHERE loveId = @loveId
                    )
            ";

            object param = new
            {
                loveId = obj.loveId,
                title = obj.title
            };

            return conn.Execute(sql, param);
        }

        /// <summary>
        /// 刪除喜歡影片
        /// </summary>
        /// <param name="loveId"></param>
        /// <returns></returns>
        public int DeleteLoveYoutube(int loveId)
        {
            sql = @"DELETE FROM love WHERE loveId = @loveId";

            object param = new
            {
                loveId = loveId
            };

            return conn.Execute(sql, param);
        }
    }

    #region 接收模型
    /// <summary>
    /// 新增影片模型
    /// </summary>
    public class InsertYoutubeRequest
    {
        /// <summary>
        /// 喜歡影片 id
        /// </summary>
        [Required]
        [RegularExpression("^[0-9]*$")]
        public int loveId { get; set; }

        /// <summary>
        /// 影片標題
        /// </summary>
        [Required]
        public string title { get; set; }
    }
    #endregion
}
