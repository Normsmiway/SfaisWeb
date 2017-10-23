using MongoDB.Bson;
using SfaisWeb.Code;
using SfaisWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SfaisWeb.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("{id}")]
        public User Get(int id)
        {
            return null;
           // return UserService.GetUsers().FirstOrDefault(user => user.Id == id);
        }

        [Route("all")]
        public IEnumerable<User> GetAll()
        {
          var usrs= DataContext.GetUsers();
            return usrs;
            //return UserService.GetUsers();
        }
        // POST: api/User
        [HttpPost]
        [Route("create")]
        public void Post([FromBody]User user)
        {
            DataContext.InsertUser(user);
        }

        [HttpPut]
        [Route("edit")]
        public void Put([FromBody]User user)
        {
           
            DataContext.UpdateUser(user);
        }

        [HttpPost]
        [Route("remove")]
        public void Delete([FromBody]User user)
        {
            DataContext.DeleteUser(new ObjectId());
        }
    }
}
