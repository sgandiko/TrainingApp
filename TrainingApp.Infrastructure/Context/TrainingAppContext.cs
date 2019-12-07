using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Domain.Entity;

namespace TrainingApp.Infrastructure.Context
{
    public class TrainingAppContext : DbContext
    {

        public TrainingAppContext()
        {

        }

        public TrainingAppContext(DbContextOptions<TrainingAppContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public virtual DbSet<Training> Trainings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Training>(entity =>
            {
                entity.HasIndex(c => new { c.TrainingStartDate });
                entity.HasIndex(c => new { c.TrainingEndDate });
                entity.Property(p => p.RowVersion).IsConcurrencyToken();
            });
        }
    }
}
