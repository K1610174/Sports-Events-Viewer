using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SPEvents.Models;

namespace SPEvents.Data
{
    public class SPEventsContext : IdentityDbContext<ApplicationUser>//DbContext
    {
        public SPEventsContext(DbContextOptions<SPEventsContext> options)
            : base(options)
        {
        }

        public DbSet<SPEvents.Models.User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventsUsers>().HasKey(euser => new { euser.EventId, euser.userId} );
            modelBuilder.Entity<EventsUsers>()
                .HasOne(esus => esus.thisevent)
                .WithMany(e => e.EventsUsers)
                .HasForeignKey(esus => esus.EventId);
            modelBuilder.Entity<EventsUsers>()
                .HasOne(esus => esus.eu)
                .WithMany(e => e.EventsUsers)
                .HasForeignKey(esus => esus.userId);

            modelBuilder.Entity<Event>().HasData(new Event
            {
                id = "1",
                title = "Football Match",
                location = "Southampton",
                datetime = new System.DateTime(2020, 3, 10, 2, 15, 10),
                description = "This is the description of the activity",
                category = "Outdoor Sport"
            }, new Event
            {
                id = "2",
                title = "Tennis Match",
                location = " Wimbledon",
                datetime = new System.DateTime(2020, 6, 10, 1, 15, 10),
                description = "This is the description of the activity",
                category = "Indoor Sport"
            }, new Event
            {
                id = "3",
                title = "Rugby Match",
                location = "Twickenham",
                datetime = new System.DateTime(2020, 4, 10, 2, 30, 10),
                description = "This is the description of the event",
                category = "Outdoor Sport"
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                id = "1",
                name = "John Doe",
                userid = "JD01",
                email = "johndoe@yahoo.com",
                address = "London",
                worklocation = "Walthamstow",
                postcode = "KT1 2EE",
                contact = "0744674873",
                dob = new System.DateTime(1985, 4, 10, 2, 30, 10),
                gender = "Male"
            }, new User
            {
                id = "2",
                name = "Jane Doe",
                userid = "JD02",
                email = "janedoe@yahoo.com",
                address = "London",
                worklocation = "Stratford",
                postcode = "KT1 2EE",
                contact = "0745612187",
                dob = new System.DateTime(1982, 4, 10, 2, 30, 10),
                gender = "Female"
            });
        }

        public DbSet<SPEvents.Models.Event> Event { get; set; }

        public DbSet<SPEvents.Models.EventUser> EventUser { get; set; }

        public DbSet<SPEvents.Models.EventsUsers> EventsUsers { get; set; }
    }
}
