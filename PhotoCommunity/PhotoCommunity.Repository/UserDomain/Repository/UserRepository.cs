﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PhotoCommunity.Repository.Entity;
using PhotoCommunity.Repository.myDbContent;

namespace PhotoCommunity.Repository.UserDomain.Repository
{
    public class UserRepository:IUserRepository
    {
        private MyDbContext _dbContext;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        public UserRepository(MyDbContext myDbContext) {
            _dbContext = myDbContext;
        }
        public bool AddUser(User user)
        {
            _dbContext.UserRepository.Add(user);
            return _dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 检查用户
        /// </summary>
        public bool CheckUser(string userName) {
            var sql = "select id from user where username=@userName";
            //return _dbContext.Database.ExecuteSqlCommand(sql,new { userName})>0;
            return _dbContext.UserRepository.FromSql(sql,new { userName }).FirstOrDefaultAsync().Id>0;
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User GetUser(User user) {
            return _dbContext.UserRepository.Where(p => p.UserName == user.UserName && p.Password == user.Password).FirstOrDefault();
        }
    }
}
