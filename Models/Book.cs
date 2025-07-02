using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_Console_Application.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; } //Primary key   

        [Required]
        public string? Title { get; set; }

        [Required]
        public int YearPublished { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; } //Foreign key
      
        public Author Author { get; set; } //navigation property
    }
}
