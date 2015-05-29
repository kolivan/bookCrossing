using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class BookCrossingContext : DbContext
    {
        public BookCrossingContext()
            : base("BookCrossing")
        {
          //  this.Configuration.LazyLoadingEnabled = false;
           // this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Author> Authors { get; set; }
    }
}
