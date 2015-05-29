using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Book:Entity
    {
        public Book() {
            this.Users = new HashSet<User>();
            this.Genres = new HashSet<Genre>();
            this.Authors = new HashSet<Author>();
        }
        

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}
