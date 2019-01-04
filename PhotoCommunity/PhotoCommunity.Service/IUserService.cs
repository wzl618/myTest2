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
    }
}
