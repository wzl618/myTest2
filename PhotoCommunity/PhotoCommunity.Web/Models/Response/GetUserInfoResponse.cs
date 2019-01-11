using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoCommunity.Web.Models.Response
{
    /// <summary>
    /// 获取用户信息Response
    /// </summary>
    public class GetUserInfoResponse
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户手机号码
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 用户简介
        /// </summary>
        public string UserContext { get; set; }
        /// <summary>
        /// 用户文章被浏览次数
        /// </summary>
        public int ViewCount { get; set; }
    }
}
