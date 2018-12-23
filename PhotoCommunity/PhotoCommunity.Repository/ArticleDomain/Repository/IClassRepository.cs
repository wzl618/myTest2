﻿using PhotoCommunity.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCommunity.Repository.ArticleDomain.Repository
{
    public interface IClassRepository
    {

        /// <summary>
        /// 增加大类
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        bool AddClass(string className);

        /// <summary>
        /// 删除大类
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        bool DeleteClass(long classId);

        /// <summary>
        /// 查询所有大类信息
        /// </summary>
        /// <returns></returns>
        List<Class> GetAllClass();

        /// <summary>
        /// 根据Id获取大类信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Class GetClassById(long Id);

        /// <summary>
        /// 更新大类信息
        /// </summary>
        /// <param name="updateClass"></param>
        /// <returns></returns>
        bool UpdateClass(Class updateClass);
    }
}
