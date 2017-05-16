using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTServer.Controllers;
using RESTServer.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UserPost()
        {
            UserController userController = new UserController();

            User user = new User();

            user.Username = "lili";
            user.Password = "loli";
            user.Name = "LILI";
            user.LastName = "LELI";
            user.BirthDay = DateTime.Now;
            user.Proffesion = "SINGER";

            HttpResponseMessage i= userController.Post(user);

            Assert.AreEqual(i.RequestMessage, "Created.");
            //Assert.AreEqual(1, 1);

        }

        [TestMethod]
        public void UserPut()
        {
            UserController userController = new UserController();

            User user = new User();

            user.Username = "lili";
            user.Password = "loli";
            user.Name = "LILI";
            user.LastName = "LELI";
            user.BirthDay = DateTime.Now;
            user.Proffesion = "SINGER";

            HttpResponseMessage i = userController.Put(2, user);

            Assert.AreEqual(i.RequestMessage, "No content.");
            //Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void UserDelete()
        {
            UserController userController = new UserController();

            HttpResponseMessage i = userController.Delete(2);

            Assert.AreEqual(i.RequestMessage, "No content.");
            //Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void UserGet()
        {
            UserController userController = new UserController();

            User user = userController.Get(3);

            Assert.AreEqual(user.Id, 3);
        }

        [TestMethod]
        public void UserGetAll()
        {
            UserController userController = new UserController();

            List<User> users = userController.Get();
            int first = users[0].Id;

            Assert.AreEqual(first, 3);
        }

        [TestMethod]
        public void UserGetAllPhotos()
        {
            UserController userController = new UserController();

            List<Photos> photos = userController.GetPhotos(2);
            int first = photos[0].Id;

            Assert.AreEqual(first, 3);
        }

        [TestMethod]
        public void PhotosPost()
        {
            PhotosController photosController = new PhotosController();

            Photos photos = new Photos();

            photos.UserId = 2;
            photos.Name = "test";
            photos.Width = 1;
            photos.Height = 1;
            photos.Size = 1;
            photos.Date = DateTime.Now;

            HttpResponseMessage i = photosController.Post(photos);

            Assert.AreEqual(i.RequestMessage, "Created.");
            //Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void PhotosPut()
        {
            PhotosController photosController = new PhotosController();

            Photos photos = new Photos();

            photos.UserId = 2;
            photos.Name = "test";
            photos.Width = 1;
            photos.Height = 1;
            photos.Size = 1;
            photos.Date = DateTime.Now;

            HttpResponseMessage i = photosController.Put(1, photos);

            Assert.AreEqual(i.RequestMessage, "No content.");
            //Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void PhotosDelete()
        {
            PhotosController photosController = new PhotosController();

            HttpResponseMessage i = photosController.Delete(2);

            Assert.AreEqual(i.RequestMessage, "No content.");
            //Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void PhotosGet()
        {
            PhotosController photosController = new PhotosController();

            Photos photos = photosController.Get(3);

            Assert.AreEqual(photos.Id, 3);
        }

        [TestMethod]
        public void PhotosGetAll()
        {
            PhotosController photosController = new PhotosController();

            List<Photos> photos = photosController.Get();
            int first = photos[0].Id;

            Assert.AreEqual(first, 3);
        }
    }
}
