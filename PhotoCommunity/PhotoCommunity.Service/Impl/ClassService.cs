using PhotoCommunity.Repository.ArticleDomain.Repository;
using PhotoCommunity.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Service.Impl
{
    public class ClassService:IClassService
    {
        private IClassRepository _classRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="classRepository"></param>
        public ClassService(IClassRepository classRepository) {
            _classRepository = classRepository;
        }

        /// <summary>
        /// 增加大类
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public bool AddClass(string className)
        {
            return _classRepository.AddClass(className);
        }

        /// <summary>
        /// 删除大类
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public bool DeleteClass(long classId) {

            return _classRepository.DeleteClass(classId);
        }

        /// <summary>
        /// 查询所有大类信息
        /// </summary>
        /// <returns></returns>
        public List<ClassModel> GetAllClass() {
            return AutoMapper.Mapper.Map<List<ClassModel>>(_classRepository.GetAllClass()) ;
        }

        /// <summary>
        /// 根据Id获取大类信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ClassModel GetClassById(long Id) {
            return AutoMapper.Mapper.Map<ClassModel>(_classRepository.GetClassById(Id));
        }

        /// <summary>
        /// 更新大类信息
        /// </summary>
        /// <param name="updateClass"></param>
        /// <returns></returns>
        public bool UpdateClass(ClassModel updateClass)
        {
            return _classRepository.UpdateClass(updateClass);
        }
    }
}
