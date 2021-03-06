﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FishBack.Domain;
using FishBack.DataAccess;

namespace FishBack.Controllers
{
    public class UserController : ApiController
    {
        private readonly FishDbContext _db = new FishDbContext();

        // GET api/User
        public HttpResponseMessage GetUsers()
        {
            var users = _db.Users.Include(o => o.Addresses)
                            .Include(o => o.Emails)
                            .Include(o => o.Phones)
                            .AsEnumerable();

            return Request.CreateResponse(HttpStatusCode.OK, new {Users = users});
        }

        // GET api/User/5
        public HttpResponseMessage GetUser(int id)
        {
            User user = _db.Users.Include(o => o.Addresses)
                                 .Include(o => o.Emails)
                                 .Include(o => o.Phones)
                                 .FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, new {User = user});
        }

        // PUT api/User/5
        public HttpResponseMessage PutUser(int id, User user)
        {
            if (ModelState.IsValid && id == user.Id)
            {
                _db.Entry(user).State = EntityState.Modified;

                try
                {
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/User
        public HttpResponseMessage PostUser(User user)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(user);
                _db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/User/5
        public HttpResponseMessage DeleteUser(int id)
        {
            User user = _db.Users.Find(id);
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            _db.Users.Remove(user);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}