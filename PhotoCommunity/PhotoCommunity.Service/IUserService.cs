using PhotoCommunity.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Service
{
    public interface IUserService
    {
        bool UserRegister(UserModel userModel);

        UserModel UserLogin(UserModel userModel);
        /// <summary>
        /// 检查用户名是否重复
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool CheckUserName(string userName);

        /// <summary>
        /// 根据用户Id获取用户名
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetUserNameById(long userId);

        /// <summary>
        /// 根据用户名获取用户Id
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        long GetUserIdByUserName(string userName);

        /// <summary>
        /// 获取全部用户信息
        /// </summary>
        /// <returns></returns>
        List<UserModel> GetAllUser();

        /// <summary>
        /// 获取受欢迎的用户
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        List<UserModel> GetPopularUser(int count);

        /// <summary>
        /// 根据用户Id获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserModel GetUserById(long userId);

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
        List<UserModel> GetAllUserInfoPage(int pageSize, int pageIndex);
    }
}
