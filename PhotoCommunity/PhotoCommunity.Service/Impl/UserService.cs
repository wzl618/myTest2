using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using PhotoCommunity.Repository.ArticleDomain.Repository;
using PhotoCommunity.Repository.UserDomain.Repository;
using PhotoCommunity.Service.Model;

namespace PhotoCommunity.Service.Impl
{
     public class UserService:IUserService
    {
        private IUserRepository _userRepository;
        private IArticleRepository _articleRepository;
        public UserService(IUserRepository userRepository,IArticleRepository articleRepository)
        {
            _userRepository = userRepository;
            _articleRepository = articleRepository;
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

        /// <summary>
        /// 获取全部用户信息
        /// </summary>
        /// <returns></returns>
        public List<UserModel> GetAllUser() {
            var users = _userRepository.GetAllUser();
            if (users != null && users.Count > 0)
            {
                return AutoMapper.Mapper.Map<List<UserModel>>(users);
            }
            else {
                return null;
            }

            
        }

        /// <summary>
        /// 获取受欢迎的用户
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<UserModel> GetPopularUser(int count) {
            var popularUserList = new List<UserModel>();
            var userList = new List<UserNameAndViewCount>();
            var allUser = _userRepository.GetAllUser();
            foreach (var user in allUser) {
                var userNameAndViewCount = new UserNameAndViewCount();
                userNameAndViewCount.UserName = user.UserName;
                userNameAndViewCount.ViewCount = _articleRepository.GetArticleViewCountByUserName(user.UserName);
                userList.Add(userNameAndViewCount);
            }
            var userNameList = userList.OrderByDescending(x => x.ViewCount).Take(count).ToList();
            foreach (var userName in userNameList) {
                popularUserList.Add(AutoMapper.Mapper.Map<UserModel>(_userRepository.GetUserByUserName(userName.UserName))) ;
            }
            return popularUserList;
        }

        /// <summary>
        /// 根据用户Id获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserModel GetUserById(long userId) {
            return AutoMapper.Mapper.Map<UserModel>(_userRepository.GetUserById(userId));
        }

        /// <summary>
        /// 获取所有用户的数量
        /// </summary>
        /// <returns></returns>
        public int GetAllUserCount() {
            return _userRepository.GetAllUserCount();
        }

        /// <summary>
        /// 获取用户的分页数据
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<UserModel> GetAllUserInfoPage(int pageSize, int pageIndex) {
            var model = new ArticleAndIndexModel();
            var article = _userRepository.GetAllUserInfoPage(pageSize, pageIndex);
            if (article != null)
            {
                return AutoMapper.Mapper.Map<List<UserModel>>(article);
            }
            else
            {
                return null;
            }
        }
    }
}
