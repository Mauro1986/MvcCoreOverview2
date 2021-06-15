using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCoreOverview2.Models;
using MVCEFCoreOverview.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreOverview2.Controllers
{
    public class AuthorController : Controller
    {
        private readonly BookContext _db;
        public AuthorController(BookContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Authors> authors = _db.Authors.ToList();
            return View(authors);
        }
    }
}
