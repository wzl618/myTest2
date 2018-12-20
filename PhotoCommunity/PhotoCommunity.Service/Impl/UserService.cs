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
    }
}
