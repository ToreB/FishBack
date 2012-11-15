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
    public class FishEventController : ApiController
    {
        private FishDbContext db = new FishDbContext();

        // GET api/FishEvent
        public IEnumerable<FishEvent> GetFishEvents()
        {
            return db.FishEvents.AsEnumerable();
        }

        // GET api/FishEvent/5
        public FishEvent GetFishEvent(int id)
        {
            FishEvent fishevent = db.FishEvents.Find(id);
            if (fishevent == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return fishevent;
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
            if (ModelState.IsValid)
            {
                db.FishEvents.Add(fishevent);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, fishevent);
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