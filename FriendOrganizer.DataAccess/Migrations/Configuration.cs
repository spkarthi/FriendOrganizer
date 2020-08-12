﻿namespace FriendOrganizer.DataAccess.Migrations
{
    using FriendOrganizer.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAccess.FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizer.DataAccess.FriendOrganizerDbContext context)
        {
            context.Friends.AddOrUpdate(f => f.FirstName,
                new Friend { FirstName = "Karthik", LastName = "Swamy", Email = "kswamy@cquest.us" },
                new Friend { FirstName = "Yasoda", LastName = "Swamy", Email = "kswamy@cquest.us" },
                new Friend { FirstName = "Ajay", LastName = "Swamy", Email = "kswamy@cquest.us" },
                new Friend { FirstName = "Shashu", LastName = "Swamy", Email = "kswamy@cquest.us" });
        }
    }
}
