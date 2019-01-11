using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoCommunity.Service;
using PhotoCommunity.Service.Model;
using PhotoCommunity.Web.Models.Request;
using PhotoCommunity.Web.Models.Response;

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
        private IArticleService _articleService;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="articleService"></param>
        public UserController(IUserService userService,IArticleService articleService) {
            _userService = userService;
            _articleService = articleService;
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

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        [Route("GetUserInfos")]
        [HttpGet]
        public List<GetUserInfoResponse> GetUserInfos() {
            var userInfos = _userService.GetAllUser();
            if (userInfos != null && userInfos.Count > 0)
            {
                return AutoMapper.Mapper.Map<List<GetUserInfoResponse>>(userInfos);
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// 获取受欢迎的用户信息
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [Route("GetPopularUserInfos")]
        [HttpGet]
        public List<GetUserInfoResponse> GetPopularUserInfos(int count)
        {
            var userInfos = _userService.GetPopularUser(count);
            if (userInfos != null && userInfos.Count > 0)
            {
                return AutoMapper.Mapper.Map<List<GetUserInfoResponse>>(userInfos);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户Id获取用户的详细信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("GetUserInfoDetail")]
        [HttpGet]
        public GetUserInfoResponse GetUserInfoDetail(long userId) {
            var userInfo = AutoMapper.Mapper.Map<GetUserInfoResponse>(_userService.GetUserById(userId));
            userInfo.ViewCount = _articleService.GetViewCountByUserName(userInfo.UserName);
            return userInfo;
        }

        /// <summary>
        /// 获取所有用户的数量
        /// </summary>
        /// <returns></returns>
        [Route("GetAllUserCount")]
        [HttpGet]
        public int GetAllUserCount() {
            return _userService.GetAllUserCount();
        }

        /// <summary>
        /// 获取用户分页信息
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [Route("GetUserInfoPage")]
        [HttpGet]
        public List<GetUserInfoResponse> GetUserInfoPage(int pageSize, int pageIndex) {
            return  AutoMapper.Mapper.Map<List<GetUserInfoResponse>>(_userService.GetAllUserInfoPage(pageSize, pageIndex));
        }
    }
}