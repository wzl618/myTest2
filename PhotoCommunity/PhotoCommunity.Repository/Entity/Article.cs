using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoCommunity.Repository.Entity
{
    /// <summary>
    /// 文章
    /// </summary>
    [Table("article")]
    public class Article
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// 大类Id
        /// </summary>
        public long ClassId { get; set; }
        /// <summary>
        /// 标签Id
        /// </summary>
        public long TagId { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        [Required, MaxLength(100)]
        public string ArticleTitle { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        [Required]
        public string ArticleContext { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [Required, MaxLength(100)]
        public string UserName { get; set; }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int ViewCount { get; set; }
        /// <summary>
        /// 评论次数
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// 全部内容
        /// </summary>
        [Required]
        public string Context { get; set; }
    }
}
