using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Genre:Entity
    {
        public Genre() { this.Books = new HashSet<Book>(); }
       

        public virtual ICollection<Book> Books { get; set; }
    }
}
