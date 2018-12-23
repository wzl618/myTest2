using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoCommunity.Web.Models.Request
{
    /// <summary>
    /// 增加图片Reqeust
    /// </summary>
    public class AddPhotoRequest
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
