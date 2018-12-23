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
        public bool AddArticle(ArticleModel articleModel)
        {
            return _articleRepository.AddArticle(articleModel);
        }
    }
}
