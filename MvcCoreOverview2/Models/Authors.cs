using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreOverview2.Models
{
    public class Authors
    {
        [Key]
        public int Author_Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string Location { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

        [NotMapped]
        public string AutherFullName
        {
            get { return $" {FirstName} + {LastName}"; }
        }
    }
}
