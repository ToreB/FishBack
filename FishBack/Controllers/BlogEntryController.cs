using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
    public class BlogEntryController : ApiController
    {
        private FishDbContext db = new FishDbContext();
        private readonly ILog logger = LogManager.GetLogger(typeof (BlogEntryController));

        // GET api/Blog
        public HttpResponseMessage GetBlogEntries()
        {
            IEnumerable<BlogEntry> blogEntries = null;
            try
            {
                /*blogEntries = from blogEntry in db.BlogEntries.Include(o => o.User)
                              let tags = db.Tags.Where(tag => tag.BlogEntries.Contains(blogEntry))
                              select new BlogEntry
                                         {
                                             Id = blogEntry.Id,
                                             Content = blogEntry.Content,
                                             CreateDate = blogEntry.CreateDate,
                                             EditDate = blogEntry.EditDate,
                                             Tags = tags.ToList(),
                                             Title = blogEntry.Title,
                                             User = blogEntry.User
                                         };*/

                blogEntries = db.BlogEntries.Include(o => o.User).Include(o => o.Tags).AsEnumerable();
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

            return Request.CreateResponse(HttpStatusCode.OK, new { BlogEntries = blogEntries });
        }

        // GET api/Blog/5
        public HttpResponseMessage GetBlogEntry(int id)
        {
            BlogEntry blogentry = db.BlogEntries.Include(o => o.User).Include(o => o.Tags).FirstOrDefault(o => o.Id == id);
            if (blogentry == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Request.CreateResponse(HttpStatusCode.OK, new { BlogEntry = blogentry });
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