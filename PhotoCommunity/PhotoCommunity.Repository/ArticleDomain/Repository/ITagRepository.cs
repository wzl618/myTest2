using PhotoCommunity.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Repository.ArticleDomain.Repository
{
    public interface ITagRepository
    {
        /// <summary>
        /// 增加标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        bool AddTag(string tagName);
        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        bool DeleteTag(long tagId);
        /// <summary>
        /// 获取单个标签
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        Tag GetTagById(long tagId);
        /// <summary>
        /// 更新标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        bool UpdateTag(Tag tag);
        /// <summary>
        /// 获取全部标签
        /// </summary>
        /// <returns></returns>
        List<Tag> GetAllTags();

        /// <summary>
        /// 根据名字获取标签
        /// </summary>
        /// <returns></returns>
        Tag GetTagByTagName(string tagName);
    }
}
