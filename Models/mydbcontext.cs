using Microsoft.EntityFrameworkCore;

namespace WebCoreApi_Login_Net8.Models
{
    public class mydbcontext : DbContext
    {
        public mydbcontext(DbContextOptions<mydbcontext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
    }
}
