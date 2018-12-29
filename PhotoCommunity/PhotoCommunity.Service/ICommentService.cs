using PhotoCommunity.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Service
{
    public interface ICommentService
    {
        /// <summary>
        /// 增加评论
        /// </summary>
        /// <param name="addComment"></param>
        /// <returns></returns>
        bool AddComment(CommentModel addComment);

        /// <summary>
        /// 查询评论
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        CommentModel GetCommentById(long commentId);

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        bool DeleteComment(long commentId);

        /// <summary>
        /// 增加评论回复
        /// </summary>
        /// <param name="addReplyComment"></param>
        /// <returns></returns>
        bool AddReplyComment(ReplyCommentModel addReplyComment);

        /// <summary>
        /// 根据评论Id查询回复评论内容
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        List<ReplyCommentModel>  GetReplyCommentByCommmentId(long commentId);

        /// <summary>
        /// 根据文章Id查询评论集合
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        List<CommentModel> GetCommentByArticleId(long articleId);
    }
}
