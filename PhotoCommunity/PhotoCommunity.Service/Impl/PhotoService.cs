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

        /// <summary>
        /// 获取文章图片集合
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public List<PhotoModel> GetPhotosByArticleId(long articleId)
        {
            return AutoMapper.Mapper.Map<List<PhotoModel>>(_photoRepository.GetPhotosByArticleId(articleId));
        }

        /// <summary>
        /// 更新图片
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public bool UpdatePhoto(PhotoModel photoModel)
        {
            return _photoRepository.UpdatePhoto(photoModel);
        }

        /// <summary>
        /// 根据文章Id删除图片
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public bool DeletePhotoByArticleId(long article) {
            var deletePhotos = _photoRepository.GetPhotosByArticleId(article);
            if (deletePhotos != null && deletePhotos.Count > 0)
            {
                try
                {
                    foreach (var deletePhoto in deletePhotos)
                    {
                        _photoRepository.DeletePhoto(deletePhoto);
                    }
                    return true;
                }
                catch (Exception e)
                {

                    return false;
                }

            }
            else {
                return false;
            }
           
        }
    }
}
