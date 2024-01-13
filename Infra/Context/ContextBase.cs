using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Context
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase( DbContextOptions options) : base (options) {}

        public DbSet<Clientes> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Entregador> Entregador { get; set; }
        public DbSet<ItensMenu> ItensMenu { get; set; }
        public DbSet<ItensPedido> ItensPedido { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            builder.Entity<Pedidos>()
                .HasOne(p => p.Entregador)
                .WithMany()
                .HasForeignKey(p => p.EntregadorId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
                base.OnConfiguring(optionsBuilder);
            }
        }
    }

    //public class ContextBaseFactory : IDesignTimeDbContextFactory<ContextBase>
    //{
      //  public ContextBase CreateDbContext(string[] args)
        //{
          //  var optionsBuilder = new DbContextOptionsBuilder<ContextBase>();
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-UQ0J9PF\\SQLSERVER23;Initial Catalog=ReiEsfirra;Integrated Security=True;Encrypt=False");

           // return new ContextBase(optionsBuilder.Options);
       // }
    //}
}
