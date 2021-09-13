using SEDC.HomeworkAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.HomeworkAPI2
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Author = "Author_1",
                Title = "Book_Title_1"
            },
            new Book
            {
                Id = 2,
                Author = "Author_2",
                Title = "Book_Title_2"
            },
            new Book
            {
                Id = 3,
                Author = "Author_3",
                Title = "Book_Title_3"
            },
            new Book
            {
                Id = 4,
                Author = "Author_4",
                Title = "Book_Title_4"
            }
        };
    }
}
