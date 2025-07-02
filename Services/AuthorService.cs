using Library_Management_Console_Application.Data;
using Library_Management_Console_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_Console_Application.Services
{
    public class AuthorService
    {
        private readonly LibraryContext _context;

        public AuthorService(LibraryContext context)
        {
            _context = context;
        }

        public void AddAuthor()
        {
            Console.Write("Enter Author Name: ");
            string? name = Console.ReadLine();
            Console.Write("Email:");
            string? email = Console.ReadLine();

            var author = new Author
            {
                Name = name,
                Email = email
            };

            _context.Authors.Add(author);
            _context.SaveChanges();
            Console.WriteLine("Author added.");
            Console.WriteLine();
        }

        public void GetAuthorList()
        {
            var authorList = _context.Authors.ToList();

            if (!authorList.Any())
            {
                Console.WriteLine("No Authors found. Please add a author first.");
                return;
            }

            Console.WriteLine("Available Authors: ");
            foreach (var author in authorList)
            {
                Console.WriteLine($"Author Id: {author.AuthorId} Name: {author.Name} Email: {author.Email}");
            }
            Console.WriteLine();

        }
    }
}
