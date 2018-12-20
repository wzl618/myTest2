using PhotoCommunity.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Service
{
    public interface ITagService
    {
        /// <summary>
        /// 增加标签
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        bool AddTag(string tagName);
        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        bool DeleteTag(long tagId);
        /// <summary>
        /// 更新标签
        /// </summary>
        /// <param name="tagModel"></param>
        /// <returns></returns>
        bool UpdateTag(TagModel tagModel);
        /// <summary>
        /// 获取单个标签
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        TagModel GetTag(long tagId);
        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <returns></returns>
        List<TagModel> GetTagList();
    }
}
