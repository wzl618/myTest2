using PhotoCommunity.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Service
{
    public interface IPhotoService
    {
        /// <summary>
        /// 增加图片
        /// </summary>
        /// <param name="photoModel"></param>
        /// <returns></returns>
        bool AddPhoto(PhotoModel photoModel);

        /// <summary>
        /// 获取文章图片集合
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        List<PhotoModel>  GetPhotosByArticleId(long articleId);

        /// <summary>
        /// 更新图片
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        bool UpdatePhoto(PhotoModel photoModel);

        /// <summary>
        /// 根据文章Id删除图片
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        bool DeletePhotoByArticleId(long article);
    }
}
