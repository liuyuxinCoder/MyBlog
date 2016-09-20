using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using System.Linq.Expressions;

namespace Blog.DAL
{
    public class BaseDAL<T> where T : class
    {
        BlogDbContext dbContext = dbEntities;
        //获取数据上下文对象
        public static BlogDbContext dbEntities
        {
            get
            {
                //从线程中读取
                DbContext dbContext = CallContext.GetData(typeof(BaseDAL<T>).Name) as DbContext;
                if (dbContext == null)
                {
                    dbContext = new BlogDbContext();
                    //将新创建的 ef上下文对象 存入线程
                    CallContext.SetData(typeof(BaseDAL<T>).Name, dbContext);
                }
                return dbContext as BlogDbContext;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">需要添加的实体对象</param>
        /// <returns></returns>
        public T Add(T model)
        {
            T res = dbContext.Set<T>().Add(model);
            dbContext.SaveChanges();
            return res;
        }

        /// <summary>
        /// 按条件删除（批量删除）
        /// </summary>
        /// <param name="condition">删除的条件</param>
        public void Delete(Expression<Func<T, bool>> condition)
        {
            //根据条件查询出所有满足条件的项
            var delList = dbContext.Set<T>().Where(condition).ToList();
            if (delList != null)
            {
                //循环删除
                delList.ForEach(o =>
                {
                    dbContext.Set<T>().Attach(o);
                    dbContext.Set<T>().Remove(o);
                });
            }
            dbContext.SaveChanges();
        }

        /// <summary>
        /// 删除指定对象
        /// </summary>
        /// <param name="model">需要删除的对象</param>
        /// <returns></returns>
        public bool Delete(T model)
        {
            dbContext.Set<T>().Attach(model);
            dbContext.Set<T>().Remove(model);
            //dbContext.SaveChanges() 返回受影响的行数
            return dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 修改指定对象
        /// </summary>
        /// <param name="model">需要修改的对象</param>
        /// <returns></returns>
        public bool Update(T model)
        {
            dbContext.Set<T>().Attach(model);
            //EntityState.Modified：实体将由上下文跟踪并存在于数据库中，已修改其中的一些或所有属性值。
            dbContext.Entry<T>(model).State = EntityState.Modified;
            //dbContext.SaveChanges() 返回受影响的行数
            return dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 按条件得到一个对象
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> condition)
        {
            //找到满足条件的第一个元素，没有找到则返回默认值
            return dbContext.Set<T>().FirstOrDefault<T>(condition);
        }

        public IQueryable<T> List(Expression<Func<T, bool>> condition, string orderName = "", string isAsc = "true")
        {
            IQueryable<T> list = dbContext.Set<T>().Where(condition);
            //需要做排序
            return list;
        }

        //public IQueryable<T> OrderBy(IQueryable<T> source, string orderName, bool isAsc)
        //{ 

        //}
    }
}
