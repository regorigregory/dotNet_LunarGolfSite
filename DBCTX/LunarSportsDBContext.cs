using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LunarSports.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


    public class LunarSportsDBContext : IdentityDbContext<ApplicationUser>
    {

        public LunarSportsDBContext(DbContextOptions<LunarSportsDBContext> opts) : base(opts)
        {
        }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
       
    }
    public DbSet<Page> Pages { get; set; }

    //public virtual DbSet<ContactDetail> ContactDetails { get; set; }
    //public virtual DbSet<ContactDetailType> ContactDetailType { get; set; }


    // public virtual DbSet<Event> Events { get; set; }
    // public virtual DbSet<EventType> EventTypes { get; set; }
    // public virtual DbSet<EventResult> EventResults { get; set; }
    // public virtual DbSet<EventScheduleEntry> EventScheduleEntries { get; set; }


    // public virtual DbSet<LaunchSite> LaunchSites { get; set; }

    // public virtual DbSet<Location> Locations { get; set; }
    // public virtual DbSet<NextOfKin> NextOfKins { get; set; }




}


