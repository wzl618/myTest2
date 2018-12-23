using PhotoCommunity.Repository.Entity;
using PhotoCommunity.Repository.myDbContent;
using System;
using System.Collections.Generic;
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
    }
}
