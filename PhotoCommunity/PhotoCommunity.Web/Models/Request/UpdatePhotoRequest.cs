using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoCommunity.Web.Models.Request
{
    /// <summary>
    /// 更新图片Request
    /// </summary>
    public class UpdatePhotoRequest
    {
        /// <summary>
        /// 图片Id
        /// </summary>
        public long Id { get; set; }

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
