using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoCommunity.Repository.Entity
{
    [Table("tag")]
    public class Tag
    {
        [Key]
        public long Id { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        [Required, MaxLength(100)]
        public string TagName { get; set; }
    }
}
