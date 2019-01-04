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
        long AddArticle(ArticleModel articleModel);

        /// <summary>
        /// 获取文章信息
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        ArticleModel GetArticleById(long articleId);

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="articleModel"></param>
        /// <returns></returns>
        bool UpdateArticle(ArticleModel articleModel);

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        bool DeleteArticle(long articleId);

        /// <summary>
        /// 根据文章标题获取文章信息
        /// </summary>
        /// <param name="articleTitle"></param>
        /// <returns></returns>
        List<ArticleModel>  GetArticleByArticleTitle(string articleTitle);

        /// <summary>
        /// 根据大类Id获取文章信息
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        List<ArticleModel> GetArticleByClassId(int pageSize, int pageIndex, long classId);

        /// <summary>
        /// 根据大类获取文章数量
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        int GetArticleCountByClassId(long classId);

        /// <summary>
        /// 更新文章已看数量
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        bool UpdateArticleViewCount(long articleId);

        /// <summary>
        /// 更新文章评论数量
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        bool UpdateArticleCommentCount(long articleId);


    }
}
