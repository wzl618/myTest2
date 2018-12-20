
using Microsoft.EntityFrameworkCore;
using PhotoCommunity.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Repository.myDbContent
{
    public class MyDbContext:DbContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options"></param>
        public MyDbContext(DbContextOptions options) : base(options)
        { }

        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<User> UserRepository { get; set; }

        /// <summary>
        /// 文章
        /// </summary>
        public DbSet<Article> ArticleRepository { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        public DbSet<Comment> CommentRepository { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public DbSet<Photo> PhotoRepository { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public DbSet<Tag> TagRepository { get; set; }

        /// <summary>
        /// 大类
        /// </summary>
        public DbSet<Class> ClassRepository { get; set; }
    }
}
