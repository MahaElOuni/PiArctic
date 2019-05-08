﻿using Data.Configurations;
using Data.Conventions;
using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
    public class Context: IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public Context():base("name=BD")
        {

        }
        public DbSet<Event> Event { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //convention et configuration
            //strategie d'heritage TPT...
            modelBuilder.Conventions.Add(new DateTimeConvention());
            modelBuilder.Entity<CustomUserRole>().HasKey(t => t.UserId);
          //  modelBuilder.Entity<CustomUserLogin>().HasKey(t => t.UserId);
            modelBuilder.Conventions.Add(new KeyConvention());
            modelBuilder.Entity<Scheduler>().HasOptional(c => c.Event).WithMany(s=>s.ListScheduler).HasForeignKey(i=>i.EventId).WillCascadeOnDelete(true);
            modelBuilder.Entity<Event>().HasOptional(c => c.President).WithMany(s => s.ListEvent).HasForeignKey(i => i.UserId);
            modelBuilder.Entity<Recommendation>().HasOptional(c => c.Event).WithMany(s => s.listRecommdendation).HasForeignKey(i => i.EventId).WillCascadeOnDelete(true);
			modelBuilder.Entity<Reward>().HasOptional(c => c.Event).WithMany(s => s.Rewards).HasForeignKey(i => i.EventId).WillCascadeOnDelete(true);
			modelBuilder.Entity<Blog>().HasOptional(c => c.User).WithMany(s => s.Blogs).HasForeignKey(i => i.UserId);

            modelBuilder.Entity<Satisfaction>().HasOptional(c => c.Event).WithMany(s => s.Satisfaction).HasForeignKey(i => i.EventId).WillCascadeOnDelete(true);


            modelBuilder.Entity<Tasks>().HasOptional(c => c.Organizer).WithMany(s => s.ListTask).HasForeignKey(i => i.UserId);
            modelBuilder.Entity<Tasks>().HasOptional(c => c.Event).WithMany(s => s.ListTask).HasForeignKey(i => i.EventId).WillCascadeOnDelete(true); 

            modelBuilder.Configurations.Add(new CommentConfig());
        }
        public static Context Create()
        {
            return new Context();
        }
        static Context()
        {
            Database.SetInitializer<Context>(null);
        }

    }
}
