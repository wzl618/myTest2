using PhotoCommunity.Repository.Entity;
using PhotoCommunity.Repository.myDbContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoCommunity.Repository.ArticleDomain.Repository
{
    public class PhotoRepository: IPhotoRepository
    {
        private MyDbContext _myDbContent;

        public PhotoRepository(MyDbContext myDbContext)
        {
            _myDbContent = myDbContext;
        }
        /// <summary>
        /// 增加图片
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        public bool AddPhoto(Photo photo)
        {
            _myDbContent.PhotoRepository.Add(photo);
            return _myDbContent.SaveChanges() > 0;
        }

        /// <summary>
        /// 获取图片集合
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public List<Photo> GetPhotosByArticleId(long articleId) {
            return _myDbContent.PhotoRepository.Where(x => x.ArticleId == articleId).ToList();
        }

        /// <summary>
        /// 更新图片
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        public bool UpdatePhoto(Photo photo) {
            var oldPhoto = _myDbContent.PhotoRepository.Where(x => x.ArticleId == photo.ArticleId).FirstOrDefault();
            if (oldPhoto != null)
            {
                oldPhoto.Url = photo.Url;
                return _myDbContent.SaveChanges() > 0;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        public bool DeletePhoto(Photo photo) {

            _myDbContent.PhotoRepository.Remove(photo);
            return _myDbContent.SaveChanges() > 0;
        }
    }
}
