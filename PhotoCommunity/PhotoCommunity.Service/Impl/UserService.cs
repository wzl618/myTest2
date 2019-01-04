using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PhotoCommunity.Repository.UserDomain.Repository;
using PhotoCommunity.Service.Model;

namespace PhotoCommunity.Service.Impl
{
     public class UserService:IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool UserRegister(UserModel userModel)
        {
            var isExist = _userRepository.CheckUser(userModel.UserName);
            if (userModel != null && !string.IsNullOrEmpty(userModel.UserName) && !string.IsNullOrEmpty(userModel.Password)&&!isExist)
            {
                return _userRepository.AddUser(userModel);
            }

            else {
                return false;
            }
           
        }


        public UserModel UserLogin(UserModel userModel)
        {
            var user = _userRepository.GetUser(userModel);
            return AutoMapper.Mapper.Map<UserModel>(user);
        }

        /// <summary>
        /// 检查用户名是否重复
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool CheckUserName(string userName) 
        {
            return _userRepository.CheckUser(userName);
        }

        /// <summary>
        /// 根据用户Id获取用户名
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetUserNameById(long userId) {
            return _userRepository.GetUserNameById(userId);
        }

        /// <summary>
        /// 根据用户名获取用户Id
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public long GetUserIdByUserName(string userName) {
            return _userRepository.GetUserIdByUserName(userName);
        }
    }
}
