using System.Collections.ObjectModel;
using FishBack.Domain;
using System.Security.Cryptography;
using FishBack.Util;

namespace FishBack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FishBack.DataAccess.FishDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FishBack.DataAccess.FishDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

           

            const string pass1 = "pass1";
            const string pass2 = "pass2";
            const string pass3 = "pass3";

            var user1Pass = new Password
                                {
                                    Id = 1,
                                    PasswordClearText = pass1,
                                    PasswordHash = StringTools.GetMd5Hash(pass1),
                                    Date = DateTime.Now
                                };
            var user1Email = new Email {Id = 1, Address = "toreb@mesan.no", Priority = 1, Date = DateTime.Now};
            var user1Address = new Address {Id = 1, Street = "address 1", ZipCode = "1010", Date = DateTime.Now};
            var user1Phone = new Phone {Id = 1, Number = "11111111", CountryCode = "47", Date = DateTime.Now};

            var user2Pass = new Password
            {
                Id = 2,
                PasswordClearText = pass2,
                PasswordHash = StringTools.GetMd5Hash(pass2),
                Date = DateTime.Now
            };
            var user2Email = new Email { Id = 2, Address = "andersa@mesan.no", Priority = 1, Date = DateTime.Now };
            var user2Address = new Address { Id = 2, Street = "address 2", ZipCode = "1010", Date = DateTime.Now };
            var user2Phone = new Phone { Id = 2, Number = "22222222", CountryCode = "47", Date = DateTime.Now };

            var user3Pass = new Password
            {
                Id = 3,
                PasswordClearText = pass3,
                PasswordHash = StringTools.GetMd5Hash(pass3),
                Date = DateTime.Now
            };
            var user3Email = new Email { Id = 3, Address = "richardn@mesan.no", Priority = 1, Date = DateTime.Now };
            var user3Address = new Address { Id = 3, Street = "address 3", ZipCode = "1010", Date = DateTime.Now };
            var user3Phone = new Phone { Id = 3, Number = "33333333", CountryCode = "47", Date = DateTime.Now };

            var user1 = new User
            {
                Id = 1,
                Username = "toreb",
                Firstname = "Tore",
                Lastname = "Brandtzæg",
                Birthdate = DateTime.Now,
                Passwords = new Collection<Password> { user1Pass },
                Addresses = new Collection<Address> { user1Address },
                Emails = new Collection<Email> { user1Email },
                Phones = new Collection<Phone> { user1Phone }
            };
            var user2 = new User
            {
                Id = 2,
                Username = "andersa",
                Firstname = "Anders",
                Lastname = "Asperheim",
                Birthdate = DateTime.Now,
                Passwords = new Collection<Password> { user2Pass },
                Addresses = new Collection<Address> { user2Address },
                Emails = new Collection<Email> { user2Email },
                Phones = new Collection<Phone> { user2Phone }
            };
            var user3 = new User
            {
                Id = 3,
                Username = "richardn",
                Firstname = "Richard",
                Lastname = "Nordli",
                Birthdate = DateTime.Now,
                Passwords = new Collection<Password> { user3Pass },
                Addresses = new Collection<Address> { user3Address },
                Emails = new Collection<Email> { user3Email },
                Phones = new Collection<Phone> { user3Phone }
            };

            context.Users.AddOrUpdate(user1);
            context.Users.AddOrUpdate(user2);
            context.Users.AddOrUpdate(user3);

            context.Passwords.AddOrUpdate(user1Pass);
            context.Passwords.AddOrUpdate(user2Pass);
            context.Passwords.AddOrUpdate(user3Pass);

            context.Addresses.AddOrUpdate(user1Address);
            context.Addresses.AddOrUpdate(user2Address);
            context.Addresses.AddOrUpdate(user3Address);

            context.Emails.AddOrUpdate(user1Email);
            context.Emails.AddOrUpdate(user2Email);
            context.Emails.AddOrUpdate(user3Email);

            context.Phones.AddOrUpdate(user1Phone);
            context.Phones.AddOrUpdate(user2Phone);
            context.Phones.AddOrUpdate(user3Phone);

            var location1 = new Location { Id = 1, Latitude = 59.95m, Longitude = 10.78m, MAMSL = 15 };
            var location2 = new Location { Id = 2, Latitude = 59.25816m, Longitude = 5.321747m, MAMSL = 20 };

            context.Locations.AddOrUpdate(location1);
            context.Locations.AddOrUpdate(location2);

            var img1 = new Image
                           {
                               Id = 1,
                               Title = "Bilde1",
                               FileName = "path/Bilde1",
                               OriginalFileName = "DCIM111111",
                               Comment = "Bilde1 kommentar",
                               /*Location = location1,*/
                               DateTime = DateTime.Now,
                               /*User = user1*/
                           };
            var img2 = new Image
                           {
                               Id = 2,
                               Title = "Bilde2",
                               FileName = "path/Bilde2",
                               OriginalFileName = "DCIM22222",
                               Comment = "Bilde2 kommentar",
                               /*Location = location2,*/
                               DateTime = DateTime.Now,
                               /*User = user2*/
                           };

            context.Images.AddOrUpdate(img1);
            context.Images.AddOrUpdate(img2);

            var event1 = new FishEvent
                             {
                                 Id = 1,
                                 User = user1,
                                 Title = "FishEvent1",
                                 Location = location1,
                                 Images = new Collection<Image> {img1},
                                 Comment = "FishEvent1 comment",
                                 DateTime = DateTime.Now
                             };

            var event2 = new FishEvent
                             {
                                 Id = 2,
                                 User = user2,
                                 Title = "FishEvent2",
                                 Location = location2,
                                 Images = new Collection<Image> {img2},
                                 Comment = "FishEvent2 comment",
                                 DateTime = DateTime.Now
                             };

            context.FishEvents.AddOrUpdate(event1);
            context.FishEvents.AddOrUpdate(event2);

            var blogEntry1 = new BlogEntry
                                 {
                                     Id = 1,
                                     User = user1,
                                     Title = "BlogEntry1",
                                     Content = "BlogEntry1 content",
                                     /*FishEvents = new Collection<FishEvent> {event1},*/
                                     Tags = new Collection<string> {"fish", "event"},
                                     CreateDate = DateTime.Now,
                                     EditDate = DateTime.Now
                                 };

            var blogEntry2 = new BlogEntry
            {
                Id = 2,
                User = user2,
                Title = "BlogEntry2",
                Content = "BlogEntry2 content",
                /*FishEvents = new Collection<FishEvent> { event2 },*/
                Tags = new Collection<string> { "fish", "event" },
                CreateDate = DateTime.Now,
                EditDate = DateTime.Now
            };

            context.BlogEntries.AddOrUpdate(blogEntry1);
            context.BlogEntries.AddOrUpdate(blogEntry2);

            context.SaveChanges();
        }
    }
}
