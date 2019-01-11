using PhotoCommunity.Repository.ArticleDomain.Repository;
using PhotoCommunity.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Service.Impl
{
    public class ArticleService:IArticleService
    {
        private IArticleRepository _articleRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="articleRepository"></param>
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        /// <summary>
        /// 增加文章
        /// </summary>
        /// <param name="articleModel"></param>
        /// <returns></returns>
        public long AddArticle(ArticleModel articleModel)
        {
            return _articleRepository.AddArticle(articleModel);
        }

        /// <summary>
        /// 获取文章信息
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public ArticleModel GetArticleById(long articleId)
        {
            var article = _articleRepository.GetArticleById(articleId);
            if (article != null)
            {
                return AutoMapper.Mapper.Map<ArticleModel>(article);
            }
            else {
                return null;
            }
            
        }

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="articleModel"></param>
        /// <returns></returns>
        public bool UpdateArticle(ArticleModel articleModel)
        {
            return _articleRepository.UpdateArticle(articleModel);
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public bool DeleteArticle(long articleId) {

            return _articleRepository.DeleteArticle(articleId);
        }

        /// <summary>
        /// 根据文章标题获取文章信息
        /// </summary>
        /// <param name="articleTitle"></param>
        /// <returns></returns>
        public List<ArticleModel> GetArticleByArticleTitle(string articleTitle)
        {
            var article = _articleRepository.GetArticleByArticleTitle(articleTitle);
            if (article != null)
            {
                return AutoMapper.Mapper.Map<List<ArticleModel>>(article);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据大类Id获取文章信息
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<ArticleModel> GetArticleByClassId(int pageSize, int pageIndex, long classId) {
            var model = new ArticleAndIndexModel();
            var article = _articleRepository.GetArticleByClassId(pageSize, pageIndex,classId);
            if (article != null)
            {
                return AutoMapper.Mapper.Map<List<ArticleModel>>(article);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据大类获取文章数量
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public int GetArticleCountByClassId(long classId) {
            return _articleRepository.GetArticleCountByClassId(classId);
        }

        /// <summary>
        /// 更新文章已看数量
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public bool UpdateArticleViewCount(long articleId) {

            var oldArticle = _articleRepository.GetArticleById(articleId);
            if (oldArticle != null)
            {
                oldArticle.ViewCount++;
                return _articleRepository.UpdateArticle(oldArticle);
            }
            else {
                return false;
            }
            
        }

        /// <summary>
        /// 更新文章评论数量
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public bool UpdateArticleCommentCount(long articleId) {
            var oldArticle = _articleRepository.GetArticleById(articleId);
            if (oldArticle != null)
            {
                oldArticle.CommentCount++;
                return _articleRepository.UpdateArticle(oldArticle);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据标签Id获取文章信息
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public List<ArticleModel> GetArticleByTagId(int pageSize, int pageIndex, long tagId) {
            var model = new ArticleAndIndexModel();
            var article = _articleRepository.GetArticleByTagId(pageSize, pageIndex, tagId);
            if (article != null)
            {
                return AutoMapper.Mapper.Map<List<ArticleModel>>(article);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据标签获取文章数量
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public int GetArticleCountByTagId(long tagId) {
            return _articleRepository.GetArticleCountByTagId(tagId);
        }

        /// <summary>
        /// 获取最受欢迎的文章列表
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<ArticleModel> GetMostPopularArticel(int count) {
            var model = new ArticleAndIndexModel();
            var article = _articleRepository.GetArticleOrderByViewCountDesc(count);
            if (article != null)
            {
                return AutoMapper.Mapper.Map<List<ArticleModel>>(article);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户名称获取文章查看次数
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int GetViewCountByUserName(string userName) {
            return _articleRepository.GetArticleViewCountByUserName(userName);
        }

    }
}
