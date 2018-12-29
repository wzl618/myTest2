using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoCommunity.Web.Models.Response
{
    /// <summary>
    /// 获取文章Response
    /// </summary>
    public class GetArticleResponse
    {
        /// <summary>
        /// 文章Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 大类Id
        /// </summary>
        public long ClassId { get; set; }
        /// <summary>
        /// 大类名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 标签Id
        /// </summary>
        public long TagId { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string TagName { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string ArticleTitle { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
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
        /// 创建时间转化字符串
        /// </summary>
        public string CreateTimeStr { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
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
        /// 图片集合
        /// </summary>
        public List<PhotoResponse> Photos { get; set; }

        /// <summary>
        /// 全部内容
        /// </summary>
        public string Context { get; set; }

    }
}
