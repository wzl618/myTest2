using AutoMapper;
using PhotoCommunity.Repository.Entity;
using PhotoCommunity.Service.Model;
using PhotoCommunity.Web.Models.Request;
using PhotoCommunity.Web.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoCommunity.Web
{
    /// <summary>
    /// AutoMap配置
    /// </summary>
    public class DefaultProfile: Profile
    {
        /// <summary>
        /// Web层需要用到的AutoMap配置
        /// </summary>
        public DefaultProfile() {

            //用户
            CreateMap<UserRegisterRequest,UserModel>();
            CreateMap<UserLoginRequest, UserModel>();
            CreateMap<User,UserModel>();

            //标签
            CreateMap<Tag,TagModel>();
            CreateMap<TagRequest,TagModel>();
            CreateMap<TagModel,TagResponse>();

        }
    }
}
