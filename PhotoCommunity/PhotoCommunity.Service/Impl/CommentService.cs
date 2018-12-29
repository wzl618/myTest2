using PhotoCommunity.Repository.ArticleDomain.Repository;
using PhotoCommunity.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Service.Impl
{
    public class CommentService:ICommentService
    {
        private ICommentRepository _commentRepository;
        private IReplyCommentRepository _replyCommentRepository;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        public CommentService(ICommentRepository commentRepository, IReplyCommentRepository replyCommentRepository) {
            _commentRepository = commentRepository;
            _replyCommentRepository = replyCommentRepository;
        }
        /// <summary>
        /// 增加评论
        /// </summary>
        /// <param name="addComment"></param>
        /// <returns></returns>
        public bool AddComment(CommentModel addComment) {
            return _commentRepository.AddComment(addComment);
        }

        /// <summary>
        /// 查询评论
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public CommentModel GetCommentById(long commentId) {
            var comment = _commentRepository.GetCommentById(commentId);
            return AutoMapper.Mapper.Map<CommentModel>(comment);
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public bool DeleteComment(long commentId) {
            var oldComment = _commentRepository.GetCommentById(commentId);
            if (oldComment != null)
            {
                return _commentRepository.DeleteComment(oldComment);
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// 增加评论回复
        /// </summary>
        /// <param name="addReplyComment"></param>
        /// <returns></returns>
        public bool AddReplyComment(ReplyCommentModel addReplyComment) {
            return _replyCommentRepository.AddReplyComment(addReplyComment);
        }

        /// <summary>
        /// 根据评论Id查询回复评论内容
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public List<ReplyCommentModel> GetReplyCommentByCommmentId(long commentId) {

            var replyComment = _replyCommentRepository.GetReplyCommentByCommentId(commentId);
            return AutoMapper.Mapper.Map<List<ReplyCommentModel>>(replyComment);
        }

        /// <summary>
        /// 根据文章Id查询评论集合
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public List<CommentModel> GetCommentByArticleId(long articleId)
        {
            var comment = _commentRepository.GetCommentListByArticleId(articleId);
            return AutoMapper.Mapper.Map<List<CommentModel>>(comment);
        }
    }
}
