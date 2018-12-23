using PhotoCommunity.Repository.ArticleDomain.Repository;
using PhotoCommunity.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Service.Impl
{
     public class PhotoService:IPhotoService
    {
        private IPhotoRepository _photoRepository;

        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }
        /// <summary>
        /// 增加图片
        /// </summary>
        /// <param name="photoModel"></param>
        /// <returns></returns>
        public bool AddPhoto(PhotoModel photoModel)
        {
            return _photoRepository.AddPhoto(photoModel);
        }
    }
}
