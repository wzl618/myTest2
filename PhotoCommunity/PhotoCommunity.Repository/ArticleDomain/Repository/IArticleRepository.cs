using PhotoCommunity.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Repository.ArticleDomain.Repository
{
    public interface IArticleRepository
    {
        /// <summary>
        /// 增加文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        bool AddArticle(Article article);
    }
}
