using PhotoCommunity.Repository.Entity;
using PhotoCommunity.Repository.myDbContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoCommunity.Repository.ArticleDomain.Repository
{
    public class ClassRepository:IClassRepository
    {
        private MyDbContext _myDbContent;

        public ClassRepository(MyDbContext myDbContext)
        {
            _myDbContent = myDbContext;
        }
        /// <summary>
        /// 增加大类
        /// </summary>
        /// <param name="addClass"></param>
        /// <returns></returns>
        public bool AddClass(string className) {
            _myDbContent.ClassRepository.Add(new Class() {
                ClassName=className
            });
            return _myDbContent.SaveChanges() > 0;
        }

        /// <summary>
        /// 删除大类
        /// </summary>
        /// <param name="deleteClass"></param>
        /// <returns></returns>
        public bool DeleteClass(long classId) {
            var oldClass= _myDbContent.ClassRepository.Where(x => x.Id == classId).FirstOrDefault();
            if (oldClass != null)
            {
                _myDbContent.Remove(oldClass);
                return _myDbContent.SaveChanges() > 0;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// 查询所有大类信息
        /// </summary>
        /// <returns></returns>
        public List<Class> GetAllClass(){
           return  _myDbContent.ClassRepository.Select(x => new Class(){
                Id = x.Id,
                ClassName=x.ClassName
            }).ToList();
        }

        /// <summary>
        /// 根据Id获取大类信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Class GetClassById(long Id) {
            return _myDbContent.ClassRepository.Where(x => x.Id == Id).FirstOrDefault();
        }

        /// <summary>
        /// 更新大类信息
        /// </summary>
        /// <param name="updateClass"></param>
        /// <returns></returns>
        public bool UpdateClass(Class updateClass) {
            var oldClass = _myDbContent.ClassRepository.Where(x => x.Id == updateClass.Id).FirstOrDefault();
            if (oldClass != null)
            {
                oldClass.ClassName = updateClass.ClassName;
                return _myDbContent.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
