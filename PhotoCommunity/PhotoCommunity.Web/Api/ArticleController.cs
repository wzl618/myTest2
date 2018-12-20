using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UEditor.Core;

namespace PhotoCommunity.Web.Api
{
    /// <summary>
    /// 文章
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private UEditorService _ueditorService;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="uEditorService"></param>
        public ArticleController(UEditorService uEditorService)
        {
            _ueditorService = uEditorService;
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <returns></returns>
        [Route("Upload")]
        [HttpGet, HttpPost]
        public ContentResult Upload()
        {
            var response = _ueditorService.UploadAndGetResponse(HttpContext);
            return Content(response.Result, response.ContentType);
        }

    }
}