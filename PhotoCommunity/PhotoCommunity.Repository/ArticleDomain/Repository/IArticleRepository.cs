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
        long AddArticle(Article article);

        /// <summary>
        /// 根据文章Id获取文章信息
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        Article GetArticleById(long articleId);

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        bool UpdateArticle(Article article);

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
        List<Article> GetArticleByArticleTitle(string articleTitle);

        /// <summary>
        /// 根据大类获取文章信息
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        List<Article> GetArticleByClassId(int pageSize, int pageIndex, long classId);

        /// <summary>
        /// 根据大类Id获取文章数量
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        int GetArticleCountByClassId(long classId);

        /// <summary>
        /// 根据标签Id获取文章信息
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        List<Article> GetArticleByTagId(int pageSize, int pageIndex, long tagId);

        /// <summary>
        /// 根据标签Id获取文章数量
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        int GetArticleCountByTagId(long tagId);

        /// <summary>
        /// 根据查看次数排序获取文章
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        List<Article> GetArticleOrderByViewCountDesc(int count);

        /// <summary>
        /// 根据用户名称获取文章查看次数
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        int GetArticleViewCountByUserName(string userName);

    }
}
