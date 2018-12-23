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
    }
}
