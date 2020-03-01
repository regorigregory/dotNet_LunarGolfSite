using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LunarSports.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


    public class LunarSportsDBContext : IdentityDbContext
    {

        public LunarSportsDBContext(DbContextOptions<LunarSportsDBContext> opts) : base(opts)
        {
        }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
       
    }
    public DbSet<Rank> Rank { get; set; }
   
    }


