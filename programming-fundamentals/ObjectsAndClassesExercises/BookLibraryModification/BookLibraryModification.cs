using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;

namespace BookLibraryModification
{
    class BookLibraryModification
    {
        static void Main(string[] args)
        {
            int booksCount = int.Parse(Console.ReadLine());
            Library library = Library.CreateLibrary(booksCount);
            DateTime afterDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            library.Books = library.Books.OrderBy(x => x.ReleaseDate).ThenBy(x => x.Title).ToList();

            foreach (var book in library.Books)
            {
                if (book.ReleaseDate>afterDate)
                {
                    Console.WriteLine($"{book.Title} -> {book.ReleaseDate.ToString("dd.MM.yyyy")}");
                }
            }
        }
    }
    public class Library
    {
        public string Name;
        public List<Book> Books;

        public static Library CreateLibrary(int booksCount)
        {
            List<Book> books = new List<Book>();
            for (int i = 0; i < booksCount; i++)
            {
                books.Add(Book.CreateFromData(Console.ReadLine().Split(' ')));
            }

            return new Library()
            {
                Books = books
            };
        }

        public static void PrintStudentList(List<Book> bookList)
        {
            foreach (var book in bookList)
            {
                Console.WriteLine($"{book.Author} -> {book.Price.ToString("f2")}");
            }
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string IsbnNumber { get; set; }
        public DateTime ReleaseDate;
        public double Price;

        public Book() { }
        public Book(string author, double price)
        {
            Author = author;
        }

        public static Book CreateFromData(string[] data)
        {
            return new Book
            {
                Title = data[0],
                Author = data[1],
                Publisher = data[2],
                ReleaseDate = DateTime.ParseExact(data[3], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                IsbnNumber = data[4],
                Price = double.Parse(data[5]),
            };
        }
    }
}
