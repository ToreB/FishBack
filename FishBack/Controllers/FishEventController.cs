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
using System.Text;
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
        public HttpResponseMessage GetFishEvents(string title = "")
        {
            var events = db.FishEvents.Include(o => o.User)
                .Include(o => o.Location)
                .Include(o => o.Images)
                .AsEnumerable();

            if (title != String.Empty)
                events = events.Where(o => o.Title == title);
                                        
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
                    var user = db.Users.Find(fishevent.User.Id);
                    fishevent.User = user;

                    db.FishEvents.AddOrUpdate(fishevent);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine(e.Message);
                    sb.AppendLine("Inner Exceptions: ");

                    Exception ex = e;
                    while((ex = ex.InnerException) != null)
                    {
                        sb.AppendLine("Inner Exception: " + e.InnerException.Message);
                    }

                    sb.AppendLine("StackTrace: " + e.StackTrace);

                    logger.Error(sb.ToString());
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