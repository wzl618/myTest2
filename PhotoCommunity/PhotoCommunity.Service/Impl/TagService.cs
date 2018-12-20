using PhotoCommunity.Repository.ArticleDomain.Repository;
using PhotoCommunity.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Service.Impl
{
    public class TagService:ITagService
    {
        private ITagRepository _tagRepsitory;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepsitory = tagRepository;
        }

        /// <summary>
        /// 增加标签
        /// </summary>
        /// <param name="tagModel"></param>
        /// <returns></returns>
        public bool AddTag(string tagName)
        {
            var result = _tagRepsitory.GetTagByTagName(tagName);
            if (result==null)
            {
                return _tagRepsitory.AddTag(tagName);
            }
            else {
                return false;
            }           
        }
        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public bool DeleteTag(long tagId)
        {
            var tag = _tagRepsitory.GetTagById(tagId);
            if (tag == null)
            {
                throw new Exception("订单标签不存在");
            }
            else {
               return _tagRepsitory.DeleteTag(tagId);
            }
        }
        /// <summary>
        /// 更新标签
        /// </summary>
        /// <param name="tagModel"></param>
        /// <returns></returns>
        public bool UpdateTag(TagModel tagModel)
        {
            var tag = _tagRepsitory.GetTagById(tagModel.Id);
            if (tag == null)
            {
                throw new Exception("订单标签不存在");
            }
            else {
                return _tagRepsitory.UpdateTag(tagModel);
            }
        }
        /// <summary>
        /// 获取单个标签
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public TagModel GetTag(long tagId)
        {
            var tag = _tagRepsitory.GetTagById(tagId);
            if (tag == null)
            {
                throw new Exception("订单标签不存在");
            }
            else {
                return AutoMapper.Mapper.Map<TagModel>(tag);
            }
        }
        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <returns></returns>
        public List<TagModel> GetTagList()
        {
            var tagList = _tagRepsitory.GetAllTags();
            if (tagList != null && tagList.Count != 0)
            {
                return AutoMapper.Mapper.Map<List<TagModel>>(tagList);
            }
            else {
                throw new Exception("获取标签列表失败");
            }
        }
    }
}
