using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreOverview2.Models
{
    public class Publisher
    {
        [Key]
        public int PubplisherId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
