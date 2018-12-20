using PhotoCommunity.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Repository.UserDomain.Repository
{
    public interface IUserRepository
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool AddUser(User user);
        /// <summary>
        /// 检查用户
        /// </summary>
        bool CheckUser(string userName);
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User GetUser(User user);
    }
}
