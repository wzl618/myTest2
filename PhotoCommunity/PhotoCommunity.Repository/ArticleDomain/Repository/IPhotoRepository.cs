using PhotoCommunity.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Repository.ArticleDomain.Repository
{
    public interface IPhotoRepository
    {
        /// <summary>
        /// 增加图片
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        bool AddPhoto(Photo photo);

        /// <summary>
        /// 获取图片集合
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        List<Photo> GetPhotosByArticleId(long articleId);

        /// <summary>
        /// 更新图片
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        bool UpdatePhoto(Photo photo);

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        bool DeletePhoto(Photo photo);
    }
}
