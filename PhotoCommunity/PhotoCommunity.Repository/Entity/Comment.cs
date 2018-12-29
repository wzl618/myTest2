using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoCommunity.Repository.Entity
{
    /// <summary>
    /// 评论
    /// </summary>
    [Table("comment")]
    public class Comment
    {
        [Key]
        public long Id { get; set; }
        /// <summary>
        /// 文章Id
        /// </summary>
        public long ArticleId { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        [Required,MaxLength(500)]
        public string Context { get; set; }

        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime CommentTime { get; set; }
    }
}
