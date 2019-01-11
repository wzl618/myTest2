using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Service.Model
{
    /// <summary>
    /// 用户名称及文章查看次数模型
    /// </summary>
    public class UserNameAndViewCount
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 文章查看次数
        /// </summary>
        public int ViewCount { get; set; }
    }
}
