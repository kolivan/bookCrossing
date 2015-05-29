using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BookCrossing.Controllers
{
    public class TemplateController<T> : ApiController where T:Entity
    {
        public BookCrossingContext context = new BookCrossingContext();
        // GET api/template
        public List<T> Get()
        {
            DbQuery<T> query = context.Set<T>();
            string expand = HttpContext.Current.Request.QueryString["expand"];
            if (expand != null)
            {
                string[] properties = expand.Split(',');
                if (properties.Length != 0)
                {
                    foreach (var property in properties)
                    {
                        query = query.Include(property);
                    }
                }
            }
            return query.ToList();
        }

        // GET api/template/5
        public T Get(int id)
        {
            return context.Set<T>().Where(x => x.Id == id).Single();
        }

        // POST api/template
        public void Post([FromBody]T value)
        {
            context.Set<T>().Add(value);
            context.SaveChanges();
        }

        // PUT api/template/5
        public T Put(int id, [FromBody]T value)
        {
            var _value = context.Set<T>().Where(p => p.Id == id).First();

            if (_value != null)
            {
                _value.name = value.name;


                context.SaveChanges();
            }
            return _value;
        }

        // DELETE api/template/5
        public void Delete(int id)
        {
            var value = context.Set<T>().Where(p => p.Id == id).First();
            context.Set<T>().Remove(value);
            context.SaveChanges(); 
        }
    }
}
