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

        /// <summary>
        /// 根据用户Id获取用户名称
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetUserNameById(long userId);

        /// <summary>
        /// 根据用户名称获取用户Id
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        long GetUserIdByUserName(string userName);

        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUser();

        /// <summary>
        /// 根据用户名称获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User GetUserByUserName(string userName);

        /// <summary>
        /// 根据Id获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetUserById(long userId);

        /// <summary>
        /// 获取所有用户的数量
        /// </summary>
        /// <returns></returns>
        int GetAllUserCount();

        /// <summary>
        /// 获取用户的分页数据
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        List<User> GetAllUserInfoPage(int pageSize, int pageIndex);
    }
}
