using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.IO;

namespace BookLibraryModification
{
    class BookLibraryModification
    {
        static void Main(string[] args)
        {
            string outputPath = @"..\..\output.txt";
            File.Delete(outputPath);

            string[] input = File.ReadAllLines(@"..\..\input.txt");

            int booksCount = int.Parse(input[0]);
            Library library = Library.CreateLibrary(booksCount, input);
            DateTime afterDate = DateTime.ParseExact(input.Last(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            library.Books = library.Books.OrderBy(x => x.ReleaseDate).ThenBy(x => x.Title).ToList();

            foreach (var book in library.Books)
            {
                if (book.ReleaseDate > afterDate)
                {
                    File.AppendAllText(outputPath, ($"{book.Title} -> {book.ReleaseDate.ToString("dd.MM.yyyy")}"+Environment.NewLine));
                }
            }
        }
    }
    public class Library
    {
        public string Name;
        public List<Book> Books;

        public static Library CreateLibrary(int booksCount, string [] input)
        {
            List<Book> books = new List<Book>();
            for (int i = 0; i < booksCount; i++)
            {
                books.Add(Book.CreateFromData(input[i+1].Split(' ')));
            }

            return new Library()
            {
                Books = books
            };
        }

        public static void PrintStudentList(List<Book> bookList, string outputPath)
        {
            foreach (var book in bookList)
            {
                File.AppendAllText(outputPath, ($"{book.Author} -> {book.Price.ToString("f2")}") + Environment.NewLine);
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