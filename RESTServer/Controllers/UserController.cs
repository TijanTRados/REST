using RESTServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections;

namespace RESTServer.Controllers
{
    public class UserController : ApiController
    {
        /// <summary>
        /// Gets all data from Users.
        /// </summary>
        /// <returns></returns>
        // GET: api/User
        public List<User> Get()
        {
            UserPersistence userPersistance = new UserPersistence();
            return userPersistance.GetUsers();
        }

        /// <summary>
        /// Gets User by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/User/5
        [HttpGet]
        [Route("api/User/{id}")]
        public User Get(int id)
        {
            UserPersistence userPersistance = new UserPersistence();
            User user = userPersistance.GetUser(id);

            if (user.Id != 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets all photos from one user filtered by user id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/User/{id}/Photos")]
        // GET: api/User/5/Photos
        public List<Photos> GetPhotos(int id)
        {
            UserPersistence userPersistance = new UserPersistence();
            return userPersistance.GetUserPhotos(id);
        }

        /// <summary>
        /// Makes a new instance of user in the database.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST: api/User
        public HttpResponseMessage Post([FromBody]User value)
        {
            int id;
            UserPersistence userPersistance = new UserPersistence();
            id = userPersistance.SaveUser(value);

            HttpResponseMessage response = new HttpResponseMessage();
            
            response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("User/{0}", id));
            return response;

       
        }

        /// <summary>
        /// Updates an instance of user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        // PUT: api/User/5
        public HttpResponseMessage Put(int id, [FromBody]User value)
        {
            bool request = false;
            UserPersistence userPersistance = new UserPersistence();

            request = userPersistance.UpdateUser(id, value);

            HttpResponseMessage response;

            if (request)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;
        }

        /// <summary>
        /// Delete an instance of user by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/User/5
        public HttpResponseMessage Delete(int id)
        {
            bool request = false;
            UserPersistence userPersistance = new UserPersistence();

            request = userPersistance.DeleteUser(id);

            HttpResponseMessage response;

            if (request)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;

        }
    }
}
