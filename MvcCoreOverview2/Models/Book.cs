using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreOverview2.Models
{
    public class Book
    {
        [Key]
        public int Books_Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(20)]
        public string Genre { get; set; }

        [Required]
        public int Pages { get; set; }

        public int YearPublished { get; set; }

        [Required]
        [StringLength(50)]
        public string Auther { get; set; }

        [StringLength(50)]
        public string AutherFirstName { get; set; }

        [StringLength(50)]
        public string AutherLastName { get; set; }
        public bool IsBestSeller { get; set; }

        [ForeignKey("BookDetail")]
        public int BookDetailId { get; set; }

        public BookDetail BookDetail { get; set; }

        [ForeignKey("Pubplisher")]
        public int PubplisherId { get; set; }
        public Publisher Publisher { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

        [NotMapped]
        public string AutherFullName
        {
            get { return $" {AutherFirstName} + {AutherLastName}"; }
        }
    }
}
