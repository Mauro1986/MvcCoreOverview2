using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreOverview2.Models
{
    public class BookAuthor
    {
        [ForeignKey("Book")]
        public int Books_Id { get; set; }

        [ForeignKey("Authors")]
        public int Author_Id { get; set; }

        public Book Book { get; set; }
        public Authors Authors { get; set; }
    }
}
