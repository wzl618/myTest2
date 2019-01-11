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
        /// Web层及Service需要用到的AutoMap配置
        /// </summary>
        public DefaultProfile() {

            //用户
            CreateMap<UserRegisterRequest,UserModel>();
            CreateMap<UserLoginRequest, UserModel>();
            CreateMap<User,UserModel>();
            CreateMap<UserModel, GetUserInfoResponse>()
                .ForMember(dm=>dm.ViewCount,mo=>mo.Ignore());

            //标签
            CreateMap<Tag,TagModel>();
            CreateMap<TagRequest,TagModel>();
            CreateMap<TagModel,TagResponse>();

            //文章
            CreateMap<AddArticleRequest,ArticleModel>();
            CreateMap<Article,ArticleModel>();
            CreateMap<ArticleModel, GetArticleResponse>()
                .ForMember(dm => dm.Photos, mo => mo.Ignore())
                .ForMember(dm => dm.ClassName, mo => mo.Ignore())
                .ForMember(dm => dm.TagName, mo => mo.Ignore());

            CreateMap<UpdateArticleRequest,ArticleModel>();


            //图片
            CreateMap<AddPhotoRequest,PhotoModel>();
            CreateMap<Photo,PhotoModel>();
            CreateMap<PhotoModel,PhotoResponse>();
            CreateMap<UpdatePhotoRequest,PhotoModel>();

            //大类
            CreateMap<Class,ClassModel>();
            CreateMap<ClassRequest,ClassModel>();
            CreateMap<ClassModel,ClassResponse>();

            //评论
            CreateMap<Comment,CommentModel>();
            CreateMap<AddCommentRequest, CommentModel>().
                ForMember(dm=>dm.CommentTime,mo=>mo.Ignore());
            CreateMap<AddReplyCommentRequest,ReplyCommentModel>()
                .ForMember(dm=>dm.CreateTime,mo=>mo.Ignore());
            CreateMap<CommentModel,GetCommentResponse>()
                .ForMember(dm=>dm.UserName,mo=>mo.Ignore())
                .ForMember(dm=>dm.ReplyComments,mo=>mo.Ignore());
            CreateMap<ReplyComment,ReplyCommentModel>();
            CreateMap<ReplyCommentModel,ReplyCommentResponse>();


        }
    }
}
