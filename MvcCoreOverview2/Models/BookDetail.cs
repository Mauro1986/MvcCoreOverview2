using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreOverview2.Models
{
    public class BookDetail
    {
        [Key]
        public int BookDetailId { get; set; }
        public double Weight { get; set; }
        public Book Book { get; set; }
    }
}
