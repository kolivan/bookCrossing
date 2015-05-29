using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.commands.models;
namespace Client.ViewModels 
{
    class BookViewModel  
    {
        public Book book;

        public BookViewModel(Book book)
        {
            this.Book = book;
        }
    }
}
