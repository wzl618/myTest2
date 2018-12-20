using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoCommunity.Repository.Entity
{
    [Table("user")]
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required,MaxLength(100)]
        public string UserName { get; set; }
        [Required,MaxLength(100)]
        public string Password { get; set; }
    }
}
