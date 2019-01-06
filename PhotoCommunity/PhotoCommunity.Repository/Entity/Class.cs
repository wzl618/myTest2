using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoCommunity.Repository.Entity
{
    /// <summary>
    /// 大类
    /// </summary>
    [Table("class")]
    public class Class
    {
        [Key]
        public long Id { get; set; }
        /// <summary>
        /// 大类名称
        /// </summary>
        [Required,MaxLength(100)]
        public string ClassName { get; set; }
    }
}
