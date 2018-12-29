using PhotoCommunity.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Repository.ArticleDomain.Repository
{
    public interface IReplyCommentRepository
    {
        /// <summary>
        /// 增加回复
        /// </summary>
        /// <param name="addReplyComment"></param>
        /// <returns></returns>
        bool AddReplyComment(ReplyComment addReplyComment);

        /// <summary>
        /// 根据评论Id查询评论回复
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        List<ReplyComment> GetReplyCommentByCommentId(long commentId);
    }
}
