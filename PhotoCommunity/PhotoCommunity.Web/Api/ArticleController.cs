using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoCommunity.Service;
using PhotoCommunity.Service.Model;
using PhotoCommunity.Web.Models.Request;
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
        private IArticleService _articleService;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="uEditorService"></param>
        /// <param name="articleService"></param>
        public ArticleController(UEditorService uEditorService, IArticleService articleService)
        {
            _ueditorService = uEditorService;
            _articleService = articleService;
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

        /// <summary>
        /// 保存图片名称及文字
        /// </summary>
        /// <param name="source"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("SaveImageNameAndText")]
        [HttpPost]
        public bool SaveImageNameAndText(SaveImageNameAndTextRequest request)
        {
            IList<string> srcArr = new List<string>();

            var txt = request.TextContent.Trim();

            string[] strs = txt.Split("\n");

            var title = strs[0];
            var context = strs[1].Trim();

            string strRegExPattern = @"<img[^>]+(src)\s*=\s*""?([^ "">]+)""?(?:[^>]+(width|height)\s*=\s*""?([^ "">]+)""?\s+(height|width)\s*=\s*""?([^ "">]+)""?)?(?:[^>]+(alt)\s*=\s*""?([^"">]+)""?)?";

            Regex re = new Regex(strRegExPattern, RegexOptions.IgnoreCase);
            Match m = re.Match(request.Source);

            while (m.Success)
            {
                srcArr.Add(m.Groups[2].Value);
                m = m.NextMatch();
            }
            return true;
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("AddArticle")]
        [HttpPost]
        public bool AddArticle(AddArticleRequest request) {
            return _articleService.AddArticle(AutoMapper.Mapper.Map<ArticleModel>(request));
        }

    }
}