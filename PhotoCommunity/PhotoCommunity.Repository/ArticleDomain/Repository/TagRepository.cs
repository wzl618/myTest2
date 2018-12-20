using PhotoCommunity.Repository.Entity;
using PhotoCommunity.Repository.myDbContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoCommunity.Repository.ArticleDomain.Repository
{
    public class TagRepository:ITagRepository
    {

        private MyDbContext _dbContext;
        public TagRepository(MyDbContext dbContext) {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 增加标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public bool AddTag(string tagNmae)
        {
            _dbContext.TagRepository.Add(new Tag() {
                TagName=tagNmae
            });
            return _dbContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public bool DeleteTag(long tagId)
        {
            var tag= _dbContext.TagRepository.Where(x => x.Id == tagId).FirstOrDefault();
            if (tag != null)
            {
                _dbContext.TagRepository.Remove(tag);
            }
            return _dbContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 获取单个标签
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public Tag GetTagById(long tagId)
        {
            return _dbContext.TagRepository.Where(x => x.Id == tagId).FirstOrDefault();
        }
        /// <summary>
        /// 更新标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public bool UpdateTag(Tag tag)
        {
            var oldTag = _dbContext.TagRepository.Where(x => x.Id == tag.Id).FirstOrDefault();
            if (oldTag!=null) {
                oldTag.TagName = tag.TagName;
            }
            return _dbContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 获取全部标签
        /// </summary>
        /// <returns></returns>
        public List<Tag> GetAllTags()
        {
            
            var tagList = _dbContext.TagRepository.Select(x => new Tag() {
                Id = x.Id,
                TagName=x.TagName
            }).ToList();
            return tagList;
        }

        /// <summary>
        /// 根据名字获取标签
        /// </summary>
        /// <returns></returns>
        public Tag GetTagByTagName(string tagName) {

            return _dbContext.TagRepository.Where(x => x.TagName == tagName).FirstOrDefault();
        }
    }
}
