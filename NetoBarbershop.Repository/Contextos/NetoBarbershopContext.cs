using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetoBarbershop.Domain.Models;

namespace NetoBarbershop.Repository.Contextos
{
    public class NetoBarbershopContext : IdentityDbContext<ApplicationUSER>
    {
        public NetoBarbershopContext(DbContextOptions<NetoBarbershopContext> options) : base(options) { }
        public DbSet<ServiceDone> servicesDone { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
