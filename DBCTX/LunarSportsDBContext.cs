using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LunarSports.Models;
using Microsoft.AspNetCore.Identity;
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

   

    //User tables...
    public  DbSet<UserContactDetail> UserContactDetails { get; set; }
    public DbSet<UserAddress> UserAddresseses { get; set; }
    public DbSet<NextOfKin> NextOfKins { get; set; }

    //Events, pages...etc.
    public DbSet<Page> Pages { get; set; }

    public DbSet<Event> Events { get; set; }
    public DbSet<EventType> EventTypes { get; set; }


    public DbSet<EventLocation> EventLocations { get; set; }
    public DbSet<EventScheduleEntry> EventScheduleEntries { get; set; }
    public DbSet<LaunchSite> LaunchSites { get; set; }
    public DbSet<EventLocationContactDetail> EventLocationContactDetails { get; set; }
    //public DbSet<LunarSports.Models.ApplicationRole> ApplicationRole { get; set; }









}


