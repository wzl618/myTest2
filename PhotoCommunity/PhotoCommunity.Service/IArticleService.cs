using PhotoCommunity.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Service
{
    public interface IArticleService
    {
        /// <summary>
        /// 增加文章
        /// </summary>
        /// <param name="articleModel"></param>
        /// <returns></returns>
        bool AddArticle(ArticleModel articleModel);
    }
}
