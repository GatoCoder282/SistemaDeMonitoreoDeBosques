using Microsoft.EntityFrameworkCore;
using SistemaDeMonitoreoDeBosques.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeMonitoreoDeBosques.Infraestructure.Data
{
    public partial class ForestMonitoringDbContext : DbContext
    {
        public ForestMonitoringDbContext()
        {
        }
        public ForestMonitoringDbContext(DbContextOptions<ForestMonitoringDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Visitor> visitors { get; set; }
        public virtual DbSet<Vehicle> vehicles { get; set; }
        public virtual DbSet<Forest> forests { get; set; }
        public virtual DbSet<Sensor> sensors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
