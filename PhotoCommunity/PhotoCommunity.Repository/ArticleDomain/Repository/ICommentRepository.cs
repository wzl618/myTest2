using PhotoCommunity.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Repository.ArticleDomain.Repository
{
    public interface ICommentRepository
    {
        /// <summary>
        /// 新增评论
        /// </summary>
        /// <param name="addComment"></param>
        /// <returns></returns>
        bool AddComment(Comment addComment);

        /// <summary>
        /// 根据Id查询评论
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        Comment GetCommentById(long commentId);

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="deleteComment"></param>
        /// <returns></returns>
        bool DeleteComment(Comment deleteComment);

        /// <summary>
        /// 根据文章Id查询评论
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        List<Comment> GetCommentListByArticleId(long articleId);

    }
}
