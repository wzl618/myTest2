using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoCommunity.Web.Models.Response
{
    /// <summary>
    /// 图片Response
    /// </summary>
    public class PhotoResponse
    {
        /// <summary>
        /// 文章Id
        /// </summary>
        public long ArticleId { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string Url { get; set; }
    }
}
