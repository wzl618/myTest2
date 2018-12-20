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
    }
}
