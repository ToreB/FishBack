using System.Collections.ObjectModel;
using FishBack.Domain;
using System.Security.Cryptography;
using FishBack.Util;
using System.Collections;

namespace FishBack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

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
                               FileName = "MF004566700",
                               OriginalFileName = "DCIM111111",
                               Comment = "Bilde1 kommentar",
                               DateTime = DateTime.Now,
                               FileNameSuffix = "jpg",
                               Size = 0l
                           };
            var img2 = new Image
                           {
                               Id = 2,
                               Title = "Bilde2",
                               FileName = "MF1122334455",
                               OriginalFileName = "DCIM22222",
                               Comment = "Bilde2 kommentar",
                               DateTime = DateTime.Now,
                               FileNameSuffix = "jpg",
                               Size = 0l
                           };

            var images = new List<Image>
                             {
                                 img1, img2,
                                 new Image {Id = 3, Title = "Bilde3", FileName = "Fish1", OriginalFileName = "DCIM33333", Comment = "Bilde3 comment", DateTime = DateTime.Now, FileNameSuffix = "jpg", Size = 0l},
                                 new Image {Id = 4, Title = "Bilde4", FileName = "Fish2", OriginalFileName = "DCIM4444", Comment = "Bilde4 comment", DateTime = DateTime.Now, FileNameSuffix = "jpg", Size = 0l},
                                 new Image {Id = 5, Title = "Bilde5", FileName = "Fish3", OriginalFileName = "DCIM5555", Comment = "Bilde5 comment", DateTime = DateTime.Now, FileNameSuffix = "jpg", Size = 0l},
                                 new Image {Id = 6, Title = "Bilde6", FileName = "Fish4", OriginalFileName = "DCI66666", Comment = "Bilde6 comment", DateTime = DateTime.Now, FileNameSuffix = "jpg", Size = 0l},
                             };

            var images2 = new List<Image>
                              {
                                 new Image {Id = 7, Title = "Bilde7", FileName = "Fish5", OriginalFileName = "DCIM77777", Comment = "Bilde7 comment", DateTime = DateTime.Now, FileNameSuffix = "jpg", Size = 0l},
                                 new Image {Id = 8, Title = "Bilde8", FileName = "Fish6", OriginalFileName = "DCIM88888", Comment = "Bilde8 comment", DateTime = DateTime.Now, FileNameSuffix = "jpg", Size = 0l},
                                 new Image {Id = 9, Title = "Bilde9", FileName = "Fish7", OriginalFileName = "DCIM99999", Comment = "Bilde9 comment", DateTime = DateTime.Now, FileNameSuffix = "jpg", Size = 0l},
                                 new Image {Id = 10, Title = "Bilde10", FileName = "Fish8", OriginalFileName = "DCIM101010", Comment = "Bilde10 comment", DateTime = DateTime.Now, FileNameSuffix = "jpg", Size = 0l},
                                 new Image {Id = 11, Title = "Bilde11", FileName = "Fish9", OriginalFileName = "DCIM11011011", Comment = "Bilde11 comment", DateTime = DateTime.Now, FileNameSuffix = "jpg", Size = 0l},
                                 new Image {Id = 12, Title = "Bilde12", FileName = "Fish10", OriginalFileName = "DCIM121212", Comment = "Bilde12 comment", DateTime = DateTime.Now, FileNameSuffix = "jpg", Size = 0l}
                             };
            foreach(var img in images)
            {
                context.Images.AddOrUpdate(img);                
            }

            var event1 = new FishEvent
                             {
                                 Id = 1,
                                 User = user1,
                                 Title = "FishEvent1",
                                 Location = location1,
                                 Images = images,
                                 Comment = "FishEvent1 comment",
                                 DateTime = DateTime.Now
                             };

            var event2 = new FishEvent
                             {
                                 Id = 2,
                                 User = user2,
                                 Title = "FishEvent2",
                                 Location = location2,
                                 Images = images2,
                                 Comment = "FishEvent2 comment",
                                 DateTime = DateTime.Now
                             };

            context.FishEvents.AddOrUpdate(event1);
            context.FishEvents.AddOrUpdate(event2);

            var tag1 = new Tag { Id = 1, Text = "Fish", BlogEntries = new Collection<BlogEntry>()};
            var tag2 = new Tag { Id = 2, Text = "Event", BlogEntries = new Collection<BlogEntry>()};
            var tag3 = new Tag { Id = 3, Text = "Fishing", BlogEntries = new Collection<BlogEntry>()}; 

            var blogEntry1 = new BlogEntry
                                 {
                                     Id = 1,
                                     User = user1,
                                     Title = "BlogEntry1",
                                     Content = "BlogEntry1 content",
                                     Tags = new Collection<Tag> { tag1, tag2, tag3},
                                     CreateDate = DateTime.Now,
                                     EditDate = DateTime.Now
                                 };

            var blogEntry2 = new BlogEntry
            {
                Id = 2,
                User = user2,
                Title = "BlogEntry2",
                Content = "BlogEntry2 content",
                Tags = new Collection<Tag> { tag1, tag2 },
                CreateDate = DateTime.Now,
                EditDate = DateTime.Now
            };

            tag1.BlogEntries.Add(blogEntry1);
            tag1.BlogEntries.Add(blogEntry2);

            tag2.BlogEntries.Add(blogEntry1);
            tag2.BlogEntries.Add(blogEntry2);

            tag3.BlogEntries.Add(blogEntry1);

            var blogEntries = new Collection<BlogEntry> { blogEntry1, blogEntry2 };
            var dateTime = DateTime.Now;
            for (int i = 3; i <= 12; i++ )
            {
                if (i % 2 == 0)
                 dateTime = dateTime.AddMonths(-i);

                var blogEntry = new BlogEntry
                                    {
                                        Id = i,
                                        User = (i % 2 == 0 ? user1 : user2),
                                        Title = "BlogEntry" + i,
                                        Content = "BlogEntry" + i + " content",
                                        CreateDate = dateTime,
                                        EditDate = dateTime,
                                        Tags = new Collection<Tag> { tag1, tag2 }
                                    };

                blogEntries.Add(blogEntry);
                tag1.BlogEntries.Add(blogEntry);
                tag2.BlogEntries.Add(blogEntry);
            }

            context.Tags.AddOrUpdate(tag1);
            context.Tags.AddOrUpdate(tag2);
            context.Tags.AddOrUpdate(tag3);


            foreach (var blogEntry in blogEntries)
            {
                context.BlogEntries.AddOrUpdate(blogEntry);
            }

            context.SaveChanges();
        }
    }
}
