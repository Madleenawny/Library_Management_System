using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace Final.Models
{
    public class LibEntity :DbContext
    {
        public LibEntity() : base()
        {

        }

        public LibEntity(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Reader> Readers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Borrow> Borrows { get; set; }

      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-O2Q8R7B\\SQL2012; Initial Catalog=LibrarySysteManagment; Integrated Security=True;TrustServerCertificate=True;");

            // optionsBuilder.UseSqlServer("Data Source=DESKTOP-FA6NEEL\\SQL2019; Initial Catalog=FinalLibrarySys; Integrated Security=True; Encrypt = false ;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
