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
    /// 标签
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private ITagService _tagService;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="tagService"></param>
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        /// <summary>
        /// 增加标签
        /// </summary>
        /// <returns></returns>
        [Route("AddTag")]
        [HttpPost]
        public bool AddTag(AddTagRequest request)
        {
            return _tagService.AddTag(request.TagName);
        }

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        [Route("DeleteTag")]
        [HttpPost]
        public bool DeleteTag(long tagId)
        {
            return _tagService.DeleteTag(tagId);
        }

        /// <summary>
        /// 更新标签
        /// </summary>
        /// <param name="request"></param>
        [Route("UpdateTag")]
        [HttpPost]
        public bool UpdateTag(TagRequest request)
        {
            return _tagService.UpdateTag(AutoMapper.Mapper.Map<TagModel>(request));
        }

        /// <summary>
        /// 获取所有标签数据
        /// </summary>
        /// <returns></returns>
        [Route("GetAllTag")]
        [HttpGet]
        public List<TagResponse> GetAllTag()
        {
            return AutoMapper.Mapper.Map<List<TagResponse>>(_tagService.GetTagList()) ;
        }
    }
}