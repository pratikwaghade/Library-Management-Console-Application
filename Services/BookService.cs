    using Library_Management_Console_Application.Data;
    using Library_Management_Console_Application.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    namespace Library_Management_Console_Application.Services
    {
    
        public class BookService
        {
            private readonly LibraryContext _context;

            public BookService(LibraryContext context)
            {
                _context = context;
            }

            public void AddBook()
            {
                //var authorService = new AuthorService(_context);
                //authorService.GetAuthorList();

                Console.Write("Enter Author Id to assign book:");
                int aid = Convert.ToInt32(Console.ReadLine());

                var selectedId = _context.Authors.Find(aid);

                if (selectedId == null)
                {
                    Console.WriteLine("Author Id not found!");
                    return;
                }
                Console.WriteLine();

                Console.Write("Enter Book Title: ");
                string? title = Console.ReadLine();

                Console.Write("Year: ");
                int year = Convert.ToInt32(Console.ReadLine());

                var books = new Book
                {
                    Title = title,
                    YearPublished = year,
                    AuthorId = aid
                };

                _context.Books.Add(books);
                _context.SaveChanges();
                Console.WriteLine("Book added.");
                Console.WriteLine();

            }

            public List<Book> GetAllBooksWithAuthors()
            {
                return _context.Books.Include(b => b.Author).ToList();
            }

            public void UpdateBookTitle()
            {
                var booklist = GetAllBooksWithAuthors();

                if (!booklist.Any())
                {
                    Console.WriteLine("No books available to update.\n");
                    return;
                }

                Console.WriteLine("Available Books: ");
                foreach (var b in booklist)
                {
                    Console.WriteLine($"Book ID: {b.BookId} Book Name: {b.Title} ({b.YearPublished}) - Author Id: {b.AuthorId} Author Name: {b.Author.Name}");
                }
                Console.WriteLine();

                Console.Write("Enter Book Id to update title:");
                int bid = Convert.ToInt32(Console.ReadLine());

                var book = _context.Books.Find(bid);

                if (book == null)
                {
                    Console.WriteLine("Book not found.");
                    return;
                }

                Console.Write("Enter New Title: ");
                string title = Console.ReadLine();

                //var books = new Book
                //{
                //    Title = title
                //};

                book.Title = title;
               // _context.Books.Update(books);
                _context.SaveChanges();
                Console.WriteLine("Title updated.");
                Console.WriteLine();

            }

            public void DeleteBook()
            {
                var booklist = GetAllBooksWithAuthors();

                if (!booklist.Any())
                {
                    Console.WriteLine("No books available to update.\n");
                    return;
                }

                Console.WriteLine("Available Books: ");
                foreach (var b in booklist)
                {
                    Console.WriteLine($"Book ID: {b.BookId} Book Name: {b.Title} ({b.YearPublished}) - Author Id: {b.AuthorId} Author Name: {b.Author.Name}");
                }
                Console.WriteLine();

                Console.Write("Enter Book Id to delete: ");
                int bookId = Convert.ToInt32(Console.ReadLine());

                var book = _context.Books.Find(bookId);

                if (book == null)
                {
                    Console.WriteLine("No book found.");
                    return;
                }
                Console.WriteLine();

                _context.Books.Remove(book);
                _context.SaveChanges();
                Console.WriteLine();
            }
        }
    }
