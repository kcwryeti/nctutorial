using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nctutorial.Data;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace nctutorial.Data
{

    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Ticket> Tickets { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    base.OnConfiguring(options);
        //    options.UseSqlServer(@"Server=DESKTOP-4FAG3LS\SQLEXPRESS;Database=ncturotrial;user=sa;password=Enova123;MultipleActiveResultSets=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
