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

    }
}
