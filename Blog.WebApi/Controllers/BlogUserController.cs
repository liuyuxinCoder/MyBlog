using Blog.BLL;
using Blog.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blog.WebApi.Controllers
{
    [RoutePrefix("Blog/User")]
    public class BlogUserController : ApiController
    {
        BaseBLL<BlogUser> bll = new BaseBLL<BlogUser>();

        [Route("get/{id:int}")]
        [HttpGet]
        public BlogUser Get(int id)
        {
            return bll.Get(o => o.UserId == id);
        }

        [Route("Add")]
        [HttpPost]
        public BlogUser Add([FromBody] BlogUser model)
        {
            return bll.Add(model);
        }

        [Route("Delete/{id:int}")]
        [HttpGet]
        public bool Delete(int id)
        {
            BlogUser model = Get(id);
            return bll.Delete(model);
        }

        [Route("Update")]
        [HttpPost]
        public bool Update([FromBody] BlogUser model)
        {
            return bll.Update(model);
        }

        [Route("List")]
        [HttpGet]
        public List<BlogUser> List()
        {
            return bll.List(o => true).ToList();
        }
    }
}
