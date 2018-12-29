using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoCommunity.Service;
using PhotoCommunity.Service.Model;
using PhotoCommunity.Web.Models.Request;

namespace PhotoCommunity.Web.Api
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService) {
            _userService = userService;
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("UserRegister")]
        [HttpPost]
        public bool UserRegister(UserRegisterRequest request)
        {
            var result= _userService.UserRegister(AutoMapper.Mapper.Map<UserModel>(request));
            return result;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("UserLogin")]
        [HttpPost]
        public bool UserLogin(UserLoginRequest request)
        {

            var user = _userService.UserLogin(AutoMapper.Mapper.Map<UserModel>(request));
            if (user!=null) {
                HttpContext.Session.SetString("username",user.UserName);
            }
            string username = HttpContext.Session.GetString("username");
            return user!=null?true:false;
        }

        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <returns></returns>
        [Route("GetUserName")]
        [HttpGet]
        public string GetUserName() {
            string username = HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(username)) {
                return username;
            }
            return "false";
        }

        /// <summary>
        /// 用户登出
        /// </summary>
        /// <returns></returns>
        [Route("UserLoginOut")]
        [HttpGet]
        public bool UserLoginOut() {
            HttpContext.Session.Remove("username");
            string username = HttpContext.Session.GetString("username");
            return username==null?true:false;
        }

        /// <summary>
        /// 检查用户名是否重复
        /// </summary>
        /// <returns></returns>
        [Route("CheckUserName")]
        [HttpPost]
        public bool CheckUserName(string userName) {
            return _userService.CheckUserName(userName);
        }
    }
}