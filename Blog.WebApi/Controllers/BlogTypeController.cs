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
    [RoutePrefix("Blog/Type")]
    public class BlogTypeController : ApiController
    {
        BaseBLL<BlogType> bll = new BaseBLL<BlogType>();

        [Route("get/{id:int}")]
        [HttpGet]
        public BlogType Get(int id)
        {
            return bll.Get(o => o.Id == id);
        }

        [Route("Add")]
        [HttpPost]
        public BlogType Add([FromBody] BlogType model)
        {
            return bll.Add(model);
        }

        [Route("Delete/{id:int}")]
        [HttpGet]
        public bool Delete(int id)
        {
            BlogType model = Get(id);
            return bll.Delete(model);
        }

        [Route("Update")]
        [HttpPost]
        public bool Update([FromBody] BlogType model)
        {
            return bll.Update(model);
        }

        [Route("List")]
        [HttpGet]
        public List<BlogType> List()
        {
            return bll.List(o => true).ToList();
        }
    }
}
