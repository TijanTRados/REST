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
    public class PhotosController : ApiController
    {
        /// <summary>
        /// Gets all the photos.
        /// </summary>
        /// <returns></returns>
        // GET: api/Photos
        public List<Photos> Get()
        {
            PhotosPersistence photosPersistance = new PhotosPersistence();
            return photosPersistance.GetPhotos();
        }

        /// <summary>
        /// Gets a photo by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Photos/5
        public Photos Get(int id)
        {
            PhotosPersistence photosPersistance = new PhotosPersistence();
            Photos photo = photosPersistance.GetPhoto(id);

            if (photo.Id != 0)
            {
                return photo;
            }
            else
            {
                Request.CreateResponse(HttpStatusCode.NotFound);
                return null;
            }
        }

        /// <summary>
        /// Makes a new instance of photo and write it in the database.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST: api/Photos
        public HttpResponseMessage Post([FromBody]Photos value)
        {
            int id;
            PhotosPersistence photoPersistance = new PhotosPersistence();
            id = photoPersistance.SavePhoto(value);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("Photos/{0}", id));
            return response;
        }

        /// <summary>
        /// Updates values in photo database by photo id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        // PUT: api/Photos/5
        public HttpResponseMessage Put(int id, [FromBody]Photos value)
        {
            bool request = false;
            PhotosPersistence photosPersistance = new PhotosPersistence();

            request = photosPersistance.UpdatePhoto(id, value);

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
        /// Delete an instance of photos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Photos/5
        public HttpResponseMessage Delete(int id)
        {
            bool request = false;
            PhotosPersistence photosPersistance = new PhotosPersistence();

            request = photosPersistance.DeletePhoto(id);

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
