using System;
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
            if (_dbContext.UserRepository.Where(x => x.UserName == userName).FirstOrDefault() == null)
            {
                return false;
            }
            else {
                return true;
            }
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User GetUser(User user) {
            return _dbContext.UserRepository.Where(p => p.UserName == user.UserName && p.Password == user.Password).FirstOrDefault();
        }

        /// <summary>
        /// 根据用户Id获取用户名称
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetUserNameById(long userId) {
            return _dbContext.UserRepository.Where(x => x.Id == userId).FirstOrDefault().UserName;
        }

        /// <summary>
        /// 根据用户名称获取用户Id
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public long GetUserIdByUserName(string userName) {
            return _dbContext.UserRepository.Where(x => x.UserName == userName).FirstOrDefault().Id;
        }
    }
}
