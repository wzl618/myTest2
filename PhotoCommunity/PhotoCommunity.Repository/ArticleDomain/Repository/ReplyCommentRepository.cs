using PhotoCommunity.Repository.Entity;
using PhotoCommunity.Repository.myDbContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoCommunity.Repository.ArticleDomain.Repository
{
    public class ReplyCommentRepository: IReplyCommentRepository
    {
        private MyDbContext _myDbContext;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="myDbContext"></param>
        public ReplyCommentRepository(MyDbContext myDbContext) {
            _myDbContext = myDbContext;
        }
        /// <summary>
        /// 增加回复
        /// </summary>
        /// <param name="addReplyComment"></param>
        /// <returns></returns>
        public bool AddReplyComment(ReplyComment addReplyComment) {
            _myDbContext.ReplyCommentRepository.Add(addReplyComment);
            return _myDbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 根据评论Id查询评论回复
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public List<ReplyComment> GetReplyCommentByCommentId(long commentId) {

            return _myDbContext.ReplyCommentRepository.Where(x => x.CommentId == commentId).ToList();
        }
    }
}
