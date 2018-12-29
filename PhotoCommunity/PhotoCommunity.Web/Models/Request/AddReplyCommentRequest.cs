using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoCommunity.Web.Models.Request
{
    /// <summary>
    /// 增加评论回复Request
    /// </summary>
    public class AddReplyCommentRequest
    {
        /// <summary>
        /// 评论Id
        /// </summary>
        public long CommentId { get; set; }

        /// <summary>
        /// 回复内容
        /// </summary>
        public string ReplyContext { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }
    }
}
