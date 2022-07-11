using System.Net;
using Microsoft.AspNetCore.Mvc;

using MySql.Data.MySqlClient;

using MYoutubeComApi.Models;
using MYoutubeComApi.VM;

namespace MYoutubeComApi.Controllers
{
    [ApiController]
    public class YoutubeController : ControllerBase
    {
        private readonly Logger<YoutubeController> logger;
        private MySqlConnection conn;

        public YoutubeController(Logger<YoutubeController> _logger)
        {
            logger = _logger;
        }

        [HttpPost]
        [Route("api/youtube/list")]
        public IActionResult GetYoutubeList()
        {
            ResultModels result = new ResultModels();

            try
            {
                using (conn = new MySqlConnection())
                {
                    conn.Open();

                    var youtubeList = new YoutubeModels(conn).GetYoutubeList<YoutubeListVM>();
                    
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
    }
}
