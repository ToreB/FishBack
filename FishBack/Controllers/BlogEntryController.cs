using System;
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
    public class BlogEntryController : ApiController
    {
        private FishDbContext db = new FishDbContext();

        // GET api/Blog
        public IEnumerable<BlogEntry> GetBlogEntries()
        {
            return db.BlogEntries.AsEnumerable();
        }

        // GET api/Blog/5
        public BlogEntry GetBlogEntry(int id)
        {
            BlogEntry blogentry = db.BlogEntries.Find(id);
            if (blogentry == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return blogentry;
        }

        // PUT api/Blog/5
        public HttpResponseMessage PutBlogEntry(int id, BlogEntry blogentry)
        {
            if (ModelState.IsValid && id == blogentry.Id)
            {
                db.Entry(blogentry).State = EntityState.Modified;

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

        // POST api/Blog
        public HttpResponseMessage PostBlogEntry(BlogEntry blogentry)
        {
            if (ModelState.IsValid)
            {
                db.BlogEntries.Add(blogentry);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, blogentry);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = blogentry.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Blog/5
        public HttpResponseMessage DeleteBlogEntry(int id)
        {
            BlogEntry blogentry = db.BlogEntries.Find(id);
            if (blogentry == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.BlogEntries.Remove(blogentry);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, blogentry);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}