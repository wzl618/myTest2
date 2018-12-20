using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoCommunity.Web.Models.Response
{
    /// <summary>
    /// 标签Response
    /// </summary>
    public class TagResponse
    {
        /// <summary>
        /// 标签Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string TagName { get; set; }
    }
}
