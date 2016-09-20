using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL;
using System.Linq.Expressions;

namespace Blog.BLL
{
    public class BaseBLL<T> where T : class
    {
        BaseDAL<T> dal = new BaseDAL<T>();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">需要添加的实体对象</param>
        /// <returns></returns>
        public T Add(T model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 按条件删除（批量删除）
        /// </summary>
        /// <param name="condition">删除的条件</param>
        public void Delete(Expression<Func<T, bool>> condition)
        {
            dal.Delete(condition);
        }

        /// <summary>
        /// 删除指定对象
        /// </summary>
        /// <param name="model">需要删除的对象</param>
        /// <returns></returns>
        public bool Delete(T model)
        {
            return dal.Delete(model);
        }

        /// <summary>
        /// 修改指定对象
        /// </summary>
        /// <param name="model">需要修改的对象</param>
        /// <returns></returns>
        public bool Update(T model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 按条件得到一个对象
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> condition)
        {
            return dal.Get(condition);
        }

        public IQueryable<T> List(Expression<Func<T, bool>> condition, string orderName = "", string isAsc = "true")
        {
            return dal.List(condition, orderName, isAsc);
        }
    }
}
