using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoCommunity.Web.Models.Request
{
    /// <summary>
    /// 增加标签Request
    /// </summary>
    public class AddTagRequest
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        public string TagName { get; set; }
    }
}
