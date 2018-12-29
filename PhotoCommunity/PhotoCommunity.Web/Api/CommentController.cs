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
    /// 评论
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;
        private IUserService _userService;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        public CommentController(ICommentService commentService,IUserService userService) {
            _commentService = commentService;
            _userService = userService;
        }

        /// <summary>
        /// 增加评论
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("AddComment")]
        [HttpPost]
        public bool AddComment(AddCommentRequest request) {
            var model = AutoMapper.Mapper.Map<CommentModel>(request);
            model.CommentTime = DateTime.Now.Date;
            return _commentService.AddComment(model);
        }

        /// <summary>
        /// 增加评论回复
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("AddReplyComment")]
        [HttpPost]
        public bool AddReplyComment(AddReplyCommentRequest request) {
            var model = AutoMapper.Mapper.Map<ReplyCommentModel>(request);
            model.CreateTime = DateTime.Now.Date;
            return _commentService.AddReplyComment(model);
        }

        /// <summary>
        /// 根据文章Id获取评论
        /// </summary>
        /// <param name="ArticleId"></param>
        /// <returns></returns>
        [Route("GetCommentByArticleId")]
        [HttpGet]
        public List<GetCommentResponse> GetCommentByArticleId(long ArticleId) {
            //var response = new List<GetCommentResponse>();
            var commentList = _commentService.GetCommentByArticleId(ArticleId);
            var response = AutoMapper.Mapper.Map<List<GetCommentResponse>>(commentList);
            //var replyCommentList = new List<ReplyCommentResponse>();
            foreach (var comment in commentList) {
                var replyCommentList = _commentService.GetReplyCommentByCommmentId(comment.Id);
                response.Where(x => x.Id == comment.Id).FirstOrDefault().ReplyComments = AutoMapper.Mapper.Map<List<ReplyCommentResponse>>(replyCommentList);
            }
            foreach (var item in response) {
                item.CommentTimeStr = Convert.ToDateTime(item.CommentTime).ToString("yyyy-MM-dd");
                item.UserName = _userService.GetUserNameById(item.UserId);
                foreach (var replyComment in item.ReplyComments) {
                    replyComment.CreateTimeStr = Convert.ToDateTime(replyComment.CreateTime).ToString("yyyy-MM-dd");
                    replyComment.UserName= _userService.GetUserNameById(replyComment.UserId);
                }
            }

            return response;
        }
    }
}