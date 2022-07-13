using System.Net;
using Microsoft.AspNetCore.Mvc;

using MySql.Data.MySqlClient;

using MYoutubeComApi.Models;
using MYoutubeComApi.VM;
using MYoutubeComApi.Settings;

namespace MYoutubeComApi.Controllers
{
    [ApiController]
    public class YoutubeController : ControllerBase
    {
        private MySqlConnection conn;

        private readonly ILogger<YoutubeController> logger;
        public YoutubeController(ILogger<YoutubeController> _logger)
        {
            logger = _logger;
        }

        /// <summary>
        /// 取得影片清單與喜歡影片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/youtube/list")]
        public IActionResult GetYoutubeList()
        {
            ResultModels result = new ResultModels();

            try
            {
                using (conn = new MySqlConnection(MysqlSettings.connStr))
                {
                    conn.Open();

                    var youtubeList = new YoutubeModels(conn).GetYoutubeList<YoutubeListVM>();

                    result.isSuccess = true;
                    result.data = youtubeList;

                    return StatusCode((int)HttpStatusCode.OK, result);
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = "資料傳輸錯誤";
                return StatusCode((int)HttpStatusCode.InternalServerError, result);
            }
        }

        /// <summary>
        /// 新增喜歡影片
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/youtube/create")]
        public IActionResult CreateYoutube(InsertYoutubeRequest body)
        {
            ResultModels result = new ResultModels();

            if (!ModelState.IsValid)
            {
                result.isSuccess = false;
                result.message = "資料傳輸錯誤";
                return StatusCode((int)HttpStatusCode.BadRequest, result);
            }

            try
            {
                using (conn = new MySqlConnection(MysqlSettings.connStr))
                {
                    conn.Open();

                    var insertLoveYoutubeRow = new YoutubeModels(conn).InsertLoveYoutube(body);

                    if (insertLoveYoutubeRow == 1)
                    {
                        result.isSuccess = true;
                        result.message = "新增喜歡影片成功";
                        return StatusCode((int)HttpStatusCode.Created, result);
                    }

                    result.isSuccess = false;
                    result.message = "新增喜歡影片失敗";
                    return StatusCode((int)HttpStatusCode.Forbidden, result);
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = "資料傳輸錯誤";
                return StatusCode((int)HttpStatusCode.InternalServerError, result);
            }
        }

        /// <summary>
        /// 新增喜歡影片
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/youtube/clone/{loveId:regex(^[[0-9]]*$)}")]
        public IActionResult CloneYoutube(int loveId)
        {
            ResultModels result = new ResultModels();

            if (!ModelState.IsValid)
            {
                result.isSuccess = false;
                result.message = "資料傳輸錯誤";
                return StatusCode((int)HttpStatusCode.BadRequest, result);
            }

            try
            {
                using (conn = new MySqlConnection(MysqlSettings.connStr))
                {
                    conn.Open();

                    var insertLoveYoutubeRow = new YoutubeModels(conn).DeleteLoveYoutube(loveId);

                    if (insertLoveYoutubeRow == 1)
                    {
                        result.isSuccess = true;
                        result.message = "刪除喜歡影片成功";
                        return StatusCode((int)HttpStatusCode.Created, result);
                    }

                    result.isSuccess = false;
                    result.message = "刪除喜歡影片失敗";
                    return StatusCode((int)HttpStatusCode.Forbidden, result);
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = "資料傳輸錯誤";
                return StatusCode((int)HttpStatusCode.InternalServerError, result);
            }
        }
    }
}
