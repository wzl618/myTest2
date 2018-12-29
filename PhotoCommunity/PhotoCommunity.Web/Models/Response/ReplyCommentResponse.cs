using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoCommunity.Web.Models.Response
{
    /// <summary>
    /// 回复评论Response
    /// </summary>
    public class ReplyCommentResponse
    {
        /// <summary>
        /// 回复评论Id
        /// </summary>
        public long Id { get; set; }

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
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建时间字符串
        /// </summary>
        public string CreateTimeStr { get; set; }
    }
}
