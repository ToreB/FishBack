using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FishBack.Domain;

namespace FishBack.Formatters
{
    public class ImageFormatter : MediaTypeFormatter
    {
        public ImageFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpeg"));
        }
        public override bool CanReadType(Type type)
        {
            if (type == typeof(Image)) return true;
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            if (type == typeof(Image)) return true;
            return false;
        }

        private object lagBildeKlasse(long lengde, string mimetype, byte[] bildedata)
        {
            //TODO: Fiske ut filnavn og legge det dynamisk
            return new Image() { FileNameSuffix = "jpg", Size = lengde, MIMEType = mimetype, DateTime = DateTime.Now, Bytes = bildedata };
        }

        public override Task<object> ReadFromStreamAsync(Type type, Stream stream, HttpContent content, IFormatterLogger formatterLogger)
        {

            var nyttBilde = new byte[content.Headers.ContentLength.Value];

            stream.Read(nyttBilde, 0, (int)content.Headers.ContentLength.Value);

            //TODO: Her kaster vi til INT, bedre å bruke long i basen.
            return Task.Factory.StartNew(() => this.lagBildeKlasse(content.Headers.ContentLength.Value, content.Headers.ContentType.MediaType, nyttBilde));
        }
    }
}