using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_Console_Application.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; } //primary key

        [Required]
        public string? Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public List<Book> Books { get; set; } = new List<Book>(); //Navigation : one author can have many books


    }
}
