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
using PhotoCommunity.Web.Models.Response;
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
        private IPhotoService _photoService;
        private IClassService _classService;
        private ITagService _tagService;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="uEditorService"></param>
        /// <param name="articleService"></param>
        /// <param name="photoService"></param>
        /// <param name="classService"></param>
        /// <param name="tagService"></param>
        public ArticleController(UEditorService uEditorService, IArticleService articleService, IPhotoService photoService,
            IClassService classService, ITagService tagService)
        {
            _ueditorService = uEditorService;
            _articleService = articleService;
            _photoService = photoService;
            _classService = classService;
            _tagService = tagService;
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
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("SaveImageNameAndText")]
        [HttpPost]
        public bool SaveImageNameAndText(SaveImageNameAndTextRequest request)
        {
            IList<string> srcArr = new List<string>();
            //获取当前用户
            string username = HttpContext.Session.GetString("username");
            var txt = request.TextContent.Trim();
            //以【】来区分标题
            int start = txt.IndexOf('【');
            int end = txt.IndexOf('】');
            var title = txt.Substring(start, end + 1);
            //切割字符串获取内容
            string[] strs = txt.Split(title);
            var context = strs[1].Trim();
            if (context == null)
            {
                return false;
            }

            //初始化Article
            var article = new AddArticleRequest() {
                ClassId = request.ClassId,
                TagId = request.TagId,
                ArticleTitle = title,
                ArticleContext = context,
                IsDelete = false,
                CreateTime = DateTime.Now.Date,
                UserName = username,
                ViewCount = 0,
                CommmentCount = 0,
                Context = request.Source
            };

            var articleId = _articleService.AddArticle(AutoMapper.Mapper.Map<ArticleModel>(article));

            string strRegExPattern = @"<img[^>]+(src)\s*=\s*""?([^ "">]+)""?(?:[^>]+(width|height)\s*=\s*""?([^ "">]+)""?\s+(height|width)\s*=\s*""?([^ "">]+)""?)?(?:[^>]+(alt)\s*=\s*""?([^"">]+)""?)?";

            Regex re = new Regex(strRegExPattern, RegexOptions.IgnoreCase);
            Match m = re.Match(request.Source);

            while (m.Success)
            {
                srcArr.Add(m.Groups[2].Value);
                m = m.NextMatch();
            }



            if (srcArr.Count() > 0)
            {
                foreach (var src in srcArr)
                {
                    var photo = new AddPhotoRequest()
                    {
                        ArticleId = articleId,
                        Url = src
                    };
                    _photoService.AddPhoto(AutoMapper.Mapper.Map<PhotoModel>(photo));
                }
            }
            else {
                var photo = new AddPhotoRequest()
                {
                    ArticleId = articleId,
                    Url = "images/pic_home_news_1.jpg"
                };
                _photoService.AddPhoto(AutoMapper.Mapper.Map<PhotoModel>(photo));
            }

            return true;
        }

        /// <summary>
        /// 修改图片及文本
        /// </summary>
        /// <returns></returns>
        [Route("UpdateImageNameAndText")]
        [HttpPost]
        public bool UpdateImageNameAndText(UpdateImageNameAndTextRequest request) {
            IList<string> srcArr = new List<string>();
            //获取当前用户
            string username = HttpContext.Session.GetString("username");
            var txt = request.TextContent.Trim();
            int start = txt.IndexOf('【');
            int end = txt.IndexOf('】');
            var title = txt.Substring(start, end + 1);
            string[] strs = txt.Split(title);
            var context = strs[1].Trim();
            if (context == null)
            {
                return false;
            }

            //初始化Article
            var article = new UpdateArticleRequest()
            {
                Id = request.ArticleId,
                ClassId = request.ClassId,
                TagId = request.TagId,
                ArticleTitle = title,
                ArticleContext = context,
                IsDelete = false,
                CreateTime = DateTime.Now.Date,
                UserName = username,
                ViewCount = 0,
                CommentCount = 0,
                Context = request.Source
            };

            var articleId = _articleService.UpdateArticle(AutoMapper.Mapper.Map<ArticleModel>(article));

            string strRegExPattern = @"<img[^>]+(src)\s*=\s*""?([^ "">]+)""?(?:[^>]+(width|height)\s*=\s*""?([^ "">]+)""?\s+(height|width)\s*=\s*""?([^ "">]+)""?)?(?:[^>]+(alt)\s*=\s*""?([^"">]+)""?)?";

            Regex re = new Regex(strRegExPattern, RegexOptions.IgnoreCase);
            Match m = re.Match(request.Source);

            while (m.Success)
            {
                srcArr.Add(m.Groups[2].Value);
                m = m.NextMatch();
            }
            //删除图片
            var deleteRes = _photoService.DeletePhotoByArticleId(request.ArticleId);
            if (deleteRes == false)
            {
                var addPhoto = new AddPhotoRequest()
                {
                    ArticleId = request.ArticleId,
                    Url = "images/pic_home_news_1.jpg"
                };
                _photoService.AddPhoto(AutoMapper.Mapper.Map<PhotoModel>(addPhoto));
            }
            //增加图片
            foreach (var src in srcArr)
            {
                var photo = new AddPhotoRequest()
                {
                    ArticleId = request.ArticleId,
                    Url = src
                };
                _photoService.AddPhoto(AutoMapper.Mapper.Map<PhotoModel>(photo));
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
        public long AddArticle(AddArticleRequest request) {
            return _articleService.AddArticle(AutoMapper.Mapper.Map<ArticleModel>(request));
        }

        /// <summary>
        /// 获取文章内容
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        [Route("GetArticle")]
        [HttpGet]
        public GetArticleResponse GetArticle(long articleId) {

            var article = _articleService.GetArticleById(articleId);
            article.CreateTime = article.CreateTime.Date;
            if (article == null) {
                return new GetArticleResponse();
            }
            var getArticleResponse = AutoMapper.Mapper.Map<GetArticleResponse>(article);
            var photos = _photoService.GetPhotosByArticleId(articleId);
            if (photos != null) {
                getArticleResponse.Photos = AutoMapper.Mapper.Map<List<PhotoResponse>>(photos);
            }
            getArticleResponse.ClassName = _classService.GetClassById(getArticleResponse.ClassId).ClassName;
            getArticleResponse.TagName = _tagService.GetTag(getArticleResponse.TagId).TagName;
            getArticleResponse.CreateTimeStr = Convert.ToDateTime(getArticleResponse.CreateTime).ToString("yyyy-MM-dd");
            return getArticleResponse;
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        [Route("DeleteArticle")]
        [HttpPost]
        public bool DeleteArticle([FromBody]long articleId) {

            var result = _articleService.DeleteArticle(articleId);
            return result;
        }

        /// <summary>
        /// 根据文章标题搜索文章
        /// </summary>
        /// <param name="articleTitle"></param>
        /// <returns></returns>
        [Route("SearchArticleByArticleTitle")]
        [HttpGet]
        public List<GetArticleResponse> SearchArticleByArticleTitle(string articleTitle) {
            var articleList = _articleService.GetArticleByArticleTitle(articleTitle);
            if (articleList == null && articleList.Count == 0)
            {
                return new List<GetArticleResponse>();
            }
            var getArticleResponse = AutoMapper.Mapper.Map<List<GetArticleResponse>>(articleList);
            foreach (var article in articleList) {
                article.CreateTime = article.CreateTime.Date;
                var photos = _photoService.GetPhotosByArticleId(article.Id);
                if (photos != null)
                {
                    getArticleResponse.Where(x => x.Id == article.Id).FirstOrDefault().Photos = AutoMapper.Mapper.Map<List<PhotoResponse>>(photos);
                }
                getArticleResponse.Where(x => x.Id == article.Id).FirstOrDefault().ClassName = _classService.GetClassById(article.ClassId).ClassName;
                getArticleResponse.Where(x => x.Id == article.Id).FirstOrDefault().TagName = _tagService.GetTag(article.TagId).TagName;
                getArticleResponse.Where(x => x.Id == article.Id).FirstOrDefault().CreateTimeStr = Convert.ToDateTime(article.CreateTime).ToString("yyyy-MM-dd");
            }
            return getArticleResponse;
        }

        /// <summary>
        /// 根据大类Id获取文章信息
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        [Route("GetArtilceByClassId")]
        [HttpGet]
        public List<GetArticleResponse> GetArtilceByClassId(int pageSize, int pageIndex, long classId) {
            var articleList = _articleService.GetArticleByClassId(pageSize, pageIndex, classId);

            if (articleList == null && articleList.Count == 0)
            {
                return new List<GetArticleResponse>();
            }
            var getArticleResponse = AutoMapper.Mapper.Map<List<GetArticleResponse>>(articleList);
            foreach (var article in articleList)
            {

                var photos = _photoService.GetPhotosByArticleId(article.Id);
                if (photos != null)
                {
                    getArticleResponse.Where(x => x.Id == article.Id).FirstOrDefault().Photos = AutoMapper.Mapper.Map<List<PhotoResponse>>(photos);
                }
                getArticleResponse.Where(x => x.Id == article.Id).FirstOrDefault().ClassName = _classService.GetClassById(article.ClassId).ClassName;
                getArticleResponse.Where(x => x.Id == article.Id).FirstOrDefault().TagName = _tagService.GetTag(article.TagId).TagName;
                getArticleResponse.Where(x => x.Id == article.Id).FirstOrDefault().CreateTimeStr = Convert.ToDateTime(article.CreateTime).ToString("yyyy-MM-dd");

            }
            return getArticleResponse;
        }

        /// <summary>
        /// 根据大类Id获取文章数量
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        [Route("GetArticleCountByClassId")]
        [HttpGet]
        public int GetArticleCountByClassId(long classId) {
            return _articleService.GetArticleCountByClassId(classId);
        }

        /// <summary>
        /// 增加文章已看次数
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        [Route("UpdateArticleViewCount")]
        [HttpPost]
        public bool UpdateArticleViewCount([FromBody]long articleId) {
            return _articleService.UpdateArticleViewCount(articleId);
        }


        /// <summary>
        /// 根据标签Id获取文章信息
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        [Route("GetArtilceByTagId")]
        [HttpGet]
        public List<GetArticleResponse> GetArtilceByTagId(int pageSize, int pageIndex, long tagId)
        {
            var articleList = _articleService.GetArticleByTagId(pageSize, pageIndex, tagId);

            if (articleList == null && articleList.Count == 0)
            {
                return new List<GetArticleResponse>();
            }
            var getArticleResponse = AutoMapper.Mapper.Map<List<GetArticleResponse>>(articleList);
            foreach (var article in articleList)
            {

                var photos = _photoService.GetPhotosByArticleId(article.Id);
                if (photos != null)
                {
                    getArticleResponse.Where(x => x.Id == article.Id).FirstOrDefault().Photos = AutoMapper.Mapper.Map<List<PhotoResponse>>(photos);
                }
                getArticleResponse.Where(x => x.Id == article.Id).FirstOrDefault().ClassName = _classService.GetClassById(article.ClassId).ClassName;
                getArticleResponse.Where(x => x.Id == article.Id).FirstOrDefault().TagName = _tagService.GetTag(article.TagId).TagName;
                getArticleResponse.Where(x => x.Id == article.Id).FirstOrDefault().CreateTimeStr = Convert.ToDateTime(article.CreateTime).ToString("yyyy-MM-dd");

            }
            return getArticleResponse;
        }

        /// <summary>
        /// 根据标签Id获取文章数量
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        [Route("GetArticleCountByTagId")]
        [HttpGet]
        public int GetArticleCountByTagId(long tagId)
        {
            return _articleService.GetArticleCountByTagId(tagId);
        }

        /// <summary>
        /// 获取最受欢迎的文章
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [Route("GetMostPopularArticle")]
        [HttpGet]
        public List<GetArticleResponse> GetMostPopularArticle(int count) {
            var articleList = _articleService.GetMostPopularArticel(count);

            if (articleList == null && articleList.Count == 0)
            {
                return new List<GetArticleResponse>();
            }
            var getArticleResponse = AutoMapper.Mapper.Map<List<GetArticleResponse>>(articleList);
            foreach (var article in articleList)
            {

                var photos = _photoService.GetPhotosByArticleId(article.Id);
                if (photos != null)
                {
                    getArticleResponse.Where(x => x.Id == article.Id).FirstOrDefault().Photos = AutoMapper.Mapper.Map<List<PhotoResponse>>(photos);
                }
                getArticleResponse.Where(x => x.Id == article.Id).FirstOrDefault().ClassName = _classService.GetClassById(article.ClassId).ClassName;
                getArticleResponse.Where(x => x.Id == article.Id).FirstOrDefault().TagName = _tagService.GetTag(article.TagId).TagName;
                getArticleResponse.Where(x => x.Id == article.Id).FirstOrDefault().CreateTimeStr = Convert.ToDateTime(article.CreateTime).ToString("yyyy-MM-dd");

            }
            return getArticleResponse;
        }
    }
}