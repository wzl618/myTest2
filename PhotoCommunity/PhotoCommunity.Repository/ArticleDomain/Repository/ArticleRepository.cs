using PhotoCommunity.Repository.Entity;
using PhotoCommunity.Repository.myDbContent;
using System;
using System.Collections.Generic;
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
        public bool AddArticle(Article article) {
            _myDbContext.ArticleRepository.Add(article);
            return _myDbContext.SaveChanges() > 0;
        }
    }
}
