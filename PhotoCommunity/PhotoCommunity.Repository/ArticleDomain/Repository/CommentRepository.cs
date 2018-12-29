using PhotoCommunity.Repository.Entity;
using PhotoCommunity.Repository.myDbContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoCommunity.Repository.ArticleDomain.Repository
{
    public class CommentRepository:ICommentRepository
    {
        private MyDbContext _myDbContent;

        public CommentRepository(MyDbContext myDbContext) {
            _myDbContent = myDbContext;
        }
        /// <summary>
        /// 新增评论
        /// </summary>
        /// <param name="addComment"></param>
        /// <returns></returns>
        public bool AddComment(Comment addComment)
        {
            _myDbContent.CommentRepository.Add(addComment);
            return _myDbContent.SaveChanges() > 0;
        }

        /// <summary>
        /// 根据Id查询评论
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public Comment GetCommentById(long commentId) {
            return _myDbContent.CommentRepository.Where(x => x.Id == commentId).FirstOrDefault();
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="deleteComment"></param>
        /// <returns></returns>
        public bool DeleteComment(Comment deleteComment) {
            _myDbContent.CommentRepository.Remove(deleteComment);
            return _myDbContent.SaveChanges() > 0;
        }

        /// <summary>
        /// 根据文章Id查询评论
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public List<Comment> GetCommentListByArticleId(long articleId) {
            return _myDbContent.CommentRepository.Where(x => x.ArticleId == articleId).ToList();
        }
    }
}
