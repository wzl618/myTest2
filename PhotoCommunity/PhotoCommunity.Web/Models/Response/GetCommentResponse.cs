using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoCommunity.Web.Models.Response
{
    /// <summary>
    /// 获取评论Response
    /// </summary>
    public class GetCommentResponse
    {
        /// <summary>
        /// 评论Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 文章Id
        /// </summary>
        public long ArticleId { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime CommentTime { get; set; }

        /// <summary>
        /// 评论时间字符串
        /// </summary>
        public string CommentTimeStr { get; set; }

        /// <summary>
        /// 回复评论集合
        /// </summary>
        public List<ReplyCommentResponse> ReplyComments { get; set; }
    }
}
