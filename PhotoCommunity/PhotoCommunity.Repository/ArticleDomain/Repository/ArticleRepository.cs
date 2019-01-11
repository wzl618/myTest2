using PhotoCommunity.Repository.Entity;
using PhotoCommunity.Repository.myDbContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoCommunity.Repository.ArticleDomain.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private MyDbContext _myDbContext;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="myDbContext"></param>
        public ArticleRepository(MyDbContext myDbContext) {
            _myDbContext = myDbContext;
        }
        /// <summary>
        /// 增加文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public long AddArticle(Article article) {
            _myDbContext.ArticleRepository.Add(article);
            _myDbContext.SaveChanges();
            return article.Id;
        }

        /// <summary>
        /// 获取文章信息
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public Article GetArticleById(long articleId) {
           return _myDbContext.ArticleRepository.Where(x => x.Id == articleId && x.IsDelete==false).FirstOrDefault();
        }

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public bool UpdateArticle(Article article) {
            var oldArticle = _myDbContext.ArticleRepository.Where(x => x.Id == article.Id).FirstOrDefault();
            if (oldArticle != null)
            {
                oldArticle.ClassId = article.ClassId;
                oldArticle.TagId = article.TagId;
                oldArticle.ArticleTitle = article.ArticleTitle;
                oldArticle.ArticleContext = article.ArticleContext;
                oldArticle.IsDelete = article.IsDelete;
                oldArticle.CreateTime = article.CreateTime;
                oldArticle.UserName = article.UserName;
                oldArticle.ViewCount = article.ViewCount;
                oldArticle.CommentCount = article.CommentCount;
                oldArticle.Context = article.Context;
                return _myDbContext.SaveChanges() > 0;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public bool DeleteArticle(long articleId) {
            var oldArticle = _myDbContext.ArticleRepository.Where(x => x.Id == articleId).FirstOrDefault();
            if (oldArticle != null)
            {
                oldArticle.IsDelete = true;
                return _myDbContext.SaveChanges() > 0;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// 根据文章标题获取文章信息
        /// </summary>
        /// <param name="articleTitle"></param>
        /// <returns></returns>
        public List<Article> GetArticleByArticleTitle(string articleTitle) {

            return _myDbContext.ArticleRepository.Where(x => x.ArticleTitle.Contains(articleTitle)).ToList();
        }

        /// <summary>
        /// 根据大类获取文章信息
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<Article> GetArticleByClassId(int pageSize, int pageIndex,long classId) {
            return _myDbContext.ArticleRepository.Where(x => x.ClassId == classId&&x.IsDelete==false)
                .OrderByDescending(x=>x.Id)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize).ToList();
        }

        /// <summary>
        /// 根据大类Id获取文章数量
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public int GetArticleCountByClassId(long classId) {
            return _myDbContext.ArticleRepository.Where(x => x.ClassId == classId&&x.IsDelete==false).Count();
        }

        /// <summary>
        /// 根据标签Id获取文章信息
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public List<Article> GetArticleByTagId(int pageSize, int pageIndex, long tagId) {
            return _myDbContext.ArticleRepository.Where(x => x.TagId == tagId && x.IsDelete == false)
               .OrderByDescending(x => x.Id)
               .Skip(pageSize * (pageIndex - 1))
               .Take(pageSize).ToList();
        }

        /// <summary>
        /// 根据标签Id获取文章数量
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public int GetArticleCountByTagId(long tagId) {
            return _myDbContext.ArticleRepository.Where(x => x.TagId == tagId&&x.IsDelete==false).Count();
        }

        /// <summary>
        /// 根据查看次数排序获取文章
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Article> GetArticleOrderByViewCountDesc(int count) {
            return _myDbContext.ArticleRepository.Where(x => x.IsDelete == false)
                .OrderByDescending(x => x.ViewCount)
                .Take(count).ToList();
        }

        /// <summary>
        /// 根据用户名称获取文章查看次数
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int GetArticleViewCountByUserName(string userName) {
            var article = _myDbContext.ArticleRepository.Where(x => x.UserName == userName && x.IsDelete == false).FirstOrDefault();
            if (article == null)
            {
                return 0;
            }
            else {
                return article.ViewCount;
            }
        }
    }
}
