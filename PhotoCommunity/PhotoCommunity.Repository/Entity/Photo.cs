using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoCommunity.Repository.Entity
{
    [Table("photo")]
    public class Photo
    {
        public long Id { get; set; }

        public long ArticleId{ get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        [Required,MaxLength(100)]
        public string Url { get; set; }
    }
}
