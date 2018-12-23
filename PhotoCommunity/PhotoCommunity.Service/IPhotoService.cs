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
    }
}
