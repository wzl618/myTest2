using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoCommunity.Web.Models.Request
{
    /// <summary>
    /// 更新图片及文本
    /// </summary>
    public class UpdateImageNameAndTextRequest
    {
        /// <summary>
        /// 文章Id
        /// </summary>
        public long ArticleId { get; set; }

        /// <summary>
        /// 全部内容
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 文本内容
        /// </summary>
        public string TextContent { get; set; }

        /// <summary>
        /// 大类Id
        /// </summary>
        public long ClassId { get; set; }

        /// <summary>
        /// 标签Id
        /// </summary>
        public long TagId { get; set; }
    }
}
