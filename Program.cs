// See https://aka.ms/new-console-template for more information
using Library_Management_Console_Application.Data;
using Library_Management_Console_Application.Models;
using Library_Management_Console_Application.Services;

var context = new LibraryContext();
AuthorService author = new AuthorService(context);
BookService book = new BookService(context);


while(true)
{
    Console.WriteLine("---------------------Library Management Console Application---------------------");
    Console.WriteLine("\t 1. Add Author\n" + "\t 2. Add Book to Author\n" + "\t 3. List all Books with Authors\n" +
                      "\t 4. Update a Book’s Title \n" + "\t 5. Delete a book\n" + "\t 6. Exit");

    Console.WriteLine("--------------------------------------------------------------------------------");
    Console.Write("Enter choice from menu: ");
    string choice = Console.ReadLine();

    switch(choice)
    {
        case "1":
            author.AddAuthor();
            break;

        case "2":
            author.GetAuthorList();
            book.AddBook();
            break;

        case "3":
            var books = book.GetAllBooksWithAuthors();

            if (!books.Any())
            {
                Console.WriteLine("No books found in the library.");
            }
            else
            {
                foreach (var b in books)
                {
                    Console.WriteLine($"Book ID: {b.BookId} Book Name: {b.Title} ({b.YearPublished}) - Author Id: {b.AuthorId} Author Name: {b.Author.Name}");
                }
            }

            Console.WriteLine();
            break;

        case "4":
            book.UpdateBookTitle();
            break;

        case "5":
            book.DeleteBook();
            break;

        case "6":
            Console.WriteLine("Exited");
            return;

        default:
            Console.WriteLine("Invalid Input. Please Try Again.");
            break;
    }
}

