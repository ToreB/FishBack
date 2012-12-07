using System;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using FishBack.DataAccess;
using FishBack.Domain;

namespace FishBack.Controllers
{
    public class ImagesController : ApiController
    {
        private FishDbContext db = new FishDbContext();

        // GET api/Images/5
        public HttpResponseMessage GetImage(int id, string ext)
        {
            Image bilde = db.Images.Find(id);

            Trace.WriteLine("GET: " + id + " EXT: " + ext);

            if (bilde != null && bilde.FileNameSuffix.Equals(ext))
            {

                var response = Request.CreateResponse();
                response.Content = new StreamContent(new MemoryStream(bilde.Bytes)); // this file stream will be closed by lower layers of web api for you once the response is completed.
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(bilde.MIMEType);

                return response;
            }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }


        // POST api/Images
        public HttpResponseMessage PostImage(Image nyttImage)
        {

            db.Images.Add(nyttImage);
            db.SaveChanges();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Url.Link("ImageApi", new { id = nyttImage.Id, ext = nyttImage.FileNameSuffix }));
            return response;
        }

        // DELETE api/Images/5
        public HttpResponseMessage DeleteImage(int id)
        {
            Image bilde = db.Images.Find(id);
            if (bilde == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Images.Remove(bilde);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, bilde);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}