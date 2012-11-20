using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FishBack.Domain;
using FishBack.DataAccess;
using log4net;

namespace FishBack.Controllers
{
    public class FishEventController : ApiController
    {
        private FishDbContext db = new FishDbContext();
        private readonly ILog logger = LogManager.GetLogger(typeof (FishEventController));

        // GET api/FishEvent
        public HttpResponseMessage GetFishEvents()
        {
            var events = db.FishEvents.Include(o => o.User)
                /*.Include(o => o.User.Addresses)
                                        .Include(o => o.User.Emails)
                                        .Include(o => o.User.Phones)*/
                .Include(o => o.Location)
                .Include(o => o.Images)
                .AsEnumerable();
                                        /*.Select(o =>
                                            new FishEvent
                                                {
                                                    Comment = o.Comment,
                                                    DateTime = o.DateTime,
                                                    Id = o.Id,
                                                    Images = o.Images,
                                                    Location = o.Location,
                                                    Title = o.Title,
                                                    User = new User
                                                               {
                                                                   Addresses = new Collection<Address> { o.User.Addresses.OrderByDescending(p => p.Date).FirstOrDefault() },
                                                                   Birthdate = o.User.Birthdate,
                                                                   Emails = new Collection<Email> { o.User.Emails.OrderByDescending(p => p.Date).FirstOrDefault() },
                                                                   Firstname = o.User.Firstname,
                                                                   Id = o.User.Id,
                                                                   Lastname = o.User.Lastname,
                                                                   Passwords = null,
                                                                   Phones = new Collection<Phone> { o.User.Phones.OrderByDescending(p => p.Date).FirstOrDefault() },
                                                                   Username = o.User.Username
                                                               }
                                                }
                                        );*/
                                        
            return Request.CreateResponse(HttpStatusCode.OK, new {FishEvents = events});
        }

        // GET api/FishEvent/5
        public HttpResponseMessage GetFishEvent(int id)
        {
            FishEvent fishevent = db.FishEvents.Find(id);
            if (fishevent == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Request.CreateResponse(HttpStatusCode.OK, new { FishEvent = fishevent});
        }

        // PUT api/FishEvent/5
        public HttpResponseMessage PutFishEvent(int id, FishEvent fishevent)
        {
            if (ModelState.IsValid && id == fishevent.Id)
            {
                db.Entry(fishevent).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
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

        // POST api/FishEvent
        public HttpResponseMessage PostFishEvent(FishEvent fishevent)
        {
            logger.Info(fishevent);
            if (ModelState.IsValid)
            {
                try
                {
                    /*fishevent.Location = db.Locations.Add(fishevent.Location);
                    db.SaveChanges();
                    
                    var collection = new Collection<Image>();
                    if (fishevent.Images != null && fishevent.Images.Count != 0)
                    {
                        foreach (var image in fishevent.Images)
                        {
                            collection.Add(db.Images.Add(image));
                        }

                        fishevent.Images = collection;
                        db.SaveChanges();
                    }*/

                    db.FishEvents.AddOrUpdate(fishevent);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    logger.Error(e.Message + "\nInner Exception: " + e.InnerException.InnerException.Message + "\nStackTrace: " + e.StackTrace);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, new { FishEvent = fishevent });
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = fishevent.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/FishEvent/5
        public HttpResponseMessage DeleteFishEvent(int id)
        {
            FishEvent fishevent = db.FishEvents.Find(id);
            if (fishevent == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.FishEvents.Remove(fishevent);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, fishevent);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}