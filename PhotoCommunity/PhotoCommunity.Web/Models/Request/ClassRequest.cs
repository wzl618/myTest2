using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoCommunity.Web.Models.Request
{
    /// <summary>
    /// 大类Request
    /// </summary>
    public class ClassRequest
    {
        /// <summary>
        /// 大类Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 大类名称
        /// </summary>
        public string ClassName { get; set; }
    }
}
