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
using FishBack.Util;
using System.IO;
using log4net;

namespace FishBack.Controllers
{
    public class LoginController : ApiController
    {
        private FishDbContext _db = new FishDbContext();
        private static readonly ILog log = LogManager.GetLogger(typeof(LoginController));

        public ClientLogin GetLogin()
        {
            var client = new Client {ClientId = Guid.NewGuid(), SoftwareVersion = "1.0", Type = "iPhone"};

            var hash = StringTools.GetMd5Hash("pass1");
            var login = new ClientLogin { Username = "toreb", Password = hash, ClientInfo = client};

            log.Info(login.Username);

            return login;
        }

        // GET api/Login/5
        public Login GetLogin(int id)
        {
            Login login = _db.Logins.Find(id);
            if (login == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return login;
        }

        // PUT api/Login/5
        public HttpResponseMessage PutLogin(int id, Login login)
        {
            if (ModelState.IsValid && id == login.Id)
            {
                _db.Entry(login).State = EntityState.Modified;

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

        // POST api/Login
        public HttpResponseMessage PostLogin(ClientLogin login)
        {
            log.Info(login);

            Login userLogin = null;
            if (ModelState.IsValid)
            {
                try
                {
                    var user = (from u in _db.Users.Include(o => o.Passwords)
                                where u.Username == login.Username &&
                                u.Passwords.OrderByDescending(d => d.Date).FirstOrDefault().PasswordHash == login.Password
                                select u).FirstOrDefault();

                    if (user == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }

                    var now = DateTime.Now;
                    userLogin = new Login
                                     {
                                         Ip = ((HttpContextWrapper) Request.Properties["MS_HttpContext"]).Request.UserHostAddress,
                                         User = user,
                                         LoginTime = now,
                                         LogoutTime = now.AddHours(1),
                                         Session = new Session
                                                       {
                                                           Begin = now,
                                                           Expires = now.AddHours(1),
                                                           Token = Guid.NewGuid()
                                                       }
                                     };

                
                    _db.Logins.Add(userLogin);
                    _db.SaveChanges();
                }
                catch (Exception e)
                {
                    log.Error(e.Message + ": " + e.StackTrace);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, new {Login = userLogin});
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = userLogin.Id }));
                return response;
            }


            return Request.CreateResponse(HttpStatusCode.BadRequest);
            
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}