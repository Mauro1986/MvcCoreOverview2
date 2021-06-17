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
            //List<Authors> authors = _db.Authors.ToList();     // Kan je authors.add doen
            IEnumerable<Authors> authors = _db.Authors.ToList(); //kan ook maar geen .add
            
            return View(authors);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]  //VEILIGHEID!  maakt key zodat request enkel van deze app gebruikt worden
        public async Task<IActionResult> Create(Authors author)
        {
            if (ModelState.IsValid) //(controle van alle velden of correct ingevuld)
            {
                //_db.Authors.Add(author); 
                //_db.SaveChanges();

                //_db.Authors.AddAsync(author);

                _db.Authors.Add(author);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); // nameof helpt fout vermijden
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var editAuthor = await _db.Authors.FindAsync(Id);

            return View(editAuthor);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Authors NewAuthors)
        {
            if (ModelState.IsValid)
            {
                _db.Authors.Update(NewAuthors);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(NewAuthors);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                //return RedirectToAction(nameof(Index));
                return NotFound();
            }
            var AuthorDetails = await _db.Authors.FindAsync(Id);
            return View(AuthorDetails);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var AuthorDetails = await _db.Authors.FindAsync(Id);
            return View(AuthorDetails);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(Authors author)
        {
            if (author.Author_Id == null)
            {
            
                return RedirectToAction(nameof(Index));
            }
            _db.Authors.Remove(author);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
