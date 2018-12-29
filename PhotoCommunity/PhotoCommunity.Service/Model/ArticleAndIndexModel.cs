
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Service.Model
{
    public class ArticleAndIndexModel
    {
        /// <summary>
        /// 文章集合
        /// </summary>
        public List<ArticleModel> articles { get; set; }
        /// <summary>
        /// 分页页数集合
        /// </summary>
        public List<int> PageIndexs { get; set; }
    }
}
