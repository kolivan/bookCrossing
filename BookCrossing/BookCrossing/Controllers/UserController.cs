using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;
using System.Data.Entity;

namespace BookCrossing.Controllers
{
    public class UserController : TemplateController<User>
    {
        /*BookCrossingContext context = new BookCrossingContext();
        // GET api/user
        public IEnumerable<User> Get()
        {
            return context.Users.ToList();
        }

        // GET api/user/5
        public User Get(int id)
        {
            return context.Users.Where(x => x.Id == id).Single();
        }

        // POST api/user
        public void Post([FromBody]User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            
        }

        // PUT api/user/5
        public User Put(int id, [FromBody]User user)
        {

            var _user = context.Users.Where(p => p.Id == id).First();

            if (_user != null)
            {
                _user.name = user.name;
                

                context.SaveChanges();
            }
            return _user;
        }



        // DELETE api/user/5
        /*public void Delete(int id)
        {
            User user = context.Users.Find(id);
            //var user = new User() { Id = id };
           // context.Entry(user).State = EntityState.Deleted;
            context.Users.Remove(user);
            context.SaveChanges();
        }*/
        /*public void Delete(int id)
        {
            var user = context.Users.Where(p => p.Id == id).First();
            context.Users.Remove(user);
            context.SaveChanges(); 
        }*/
    }
}
