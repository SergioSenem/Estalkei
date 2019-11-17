using Core.Data.Contexts;
using Estalkei.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Estalkei.Data.Contexts
{
    public class EstalkeiContext : DbContext, IContext
    {
        public IConfiguration Configuration { get; set; }

        public EstalkeiContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            var connectionString = Configuration.GetConnectionString(nameof(EstalkeiContext));
            optionsBuilder.UseMySql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Provider>();
            modelBuilder.Entity<Product>();
            modelBuilder.Entity<Exchange>();
            modelBuilder.Entity<ExchangeProduct>();

            modelBuilder.Entity<ExchangeType>().HasData(
                new ExchangeType()
                {
                    Id = 1,
                    Name = "Compra"
                },
                new ExchangeType()
                {
                    Id = 2,
                    Name = "Venda"
                }
            );
        }
    }
}
