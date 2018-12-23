using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoCommunity.Service;
using PhotoCommunity.Service.Model;
using PhotoCommunity.Web.Models.Request;
using PhotoCommunity.Web.Models.Response;

namespace PhotoCommunity.Web.Api
{
    /// <summary>
    /// 大类
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private IClassService _classService;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="classService"></param>
        public ClassController(IClassService classService) {
            _classService = classService;
        }

        /// <summary>
        /// 增加大类
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("AddClass")]
        [HttpPost]
        public bool AddClass(AddClassRequest request) {
            return _classService.AddClass(request.ClassName);
        }

        /// <summary>
        /// 删除大类
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        [Route("DeleteClass")]
        [HttpPost]
        public bool DeleteClass(long classId)
        {
            return _classService.DeleteClass(classId);
        }

        /// <summary>
        /// 获取所有大类
        /// </summary>
        /// <returns></returns>
        [Route("GetAllClass")]
        [HttpGet]
        public List<ClassResponse> GetAllClass() {
            return  AutoMapper.Mapper.Map<List<ClassResponse>>(_classService.GetAllClass());
        }

        /// <summary>
        /// 根据Id获取大类
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        [Route("GetClassById")]
        [HttpGet]
        public ClassResponse GetClassById(long classId) {
            return AutoMapper.Mapper.Map<ClassResponse>(_classService.GetClassById(classId));
        }

        /// <summary>
        /// 更新大类
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("UpdateClass")]
        [HttpPost]
        public bool UpdateClass(ClassRequest request) {
            return _classService.UpdateClass(AutoMapper.Mapper.Map<ClassModel>(request));
        }
    }
}