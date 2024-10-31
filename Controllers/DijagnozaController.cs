using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using arhitektura_projekat.Models;
using Microsoft.EntityFrameworkCore;
using arhitektura_projekat.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace arhitektura_projekat.Controllers
{
    [Route("Dijagnoza")] // Postavi osnovnu rutu za kontroler
    public class DijagnozaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DijagnozaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dijagnoza
        [HttpGet] // Oznaci da je ovo GET zahtev
        public async Task<IActionResult> Index()
        {
            var dijagnoze = await _context.Dijagnoze.ToListAsync();
            return View(dijagnoze);
        }

        // GET: Dijagnoza/Details/5
        [HttpGet("{id}")] // Oznaci da je ovo GET zahtev sa id parametrom
        public async Task<IActionResult> Details(int id)
        {
            var dijagnoza = await _context.Dijagnoze.FindAsync(id);
            if (dijagnoza == null) return NotFound();

            return View(dijagnoza);
        }

        // GET: Dijagnoza/Create
        [HttpGet("Create")] // Oznaci da je ovo GET zahtev za kreiranje
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dijagnoza/Create
        [HttpPost("Create")] // Oznaci da je ovo POST zahtev za kreiranje
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Naziv,Opis,Oznaka,Slika")] Dijagnoza dijagnoza)
        {
            if (ModelState.IsValid)
            {
                if(string.IsNullOrEmpty(dijagnoza.Slika)) {
                    dijagnoza.Slika = "https://st4.depositphotos.com/14953852/24787/v/450/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg";
                }
                _context.Add(dijagnoza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dijagnoza);
        }

        // GET: Dijagnoza/Edit/5
        [HttpGet("Edit/{id}")] // Oznaci da je ovo GET zahtev za izmenu sa id parametrom
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var dijagnoza = await _context.Dijagnoze.FindAsync(id);
            if (dijagnoza == null) return NotFound();

            return View(dijagnoza);
        }

        // POST: Dijagnoza/Edit/5
        [HttpPost("Edit/{id}")] // Oznaci da je ovo POST zahtev za izmenu sa id parametrom
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Opis,Oznaka,Slika")] Dijagnoza dijagnoza)
        {
            if (id != dijagnoza.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    if(string.IsNullOrEmpty(dijagnoza.Slika)) {
                    dijagnoza.Slika = "https://st4.depositphotos.com/14953852/24787/v/450/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg";
                }
                    _context.Update(dijagnoza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DijagnozaExists(dijagnoza.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dijagnoza);
        }

        // GET: Dijagnoza/Delete/5
        [HttpGet("Delete/{id}")] // Oznaci da je ovo GET zahtev za brisanje sa id parametrom
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var dijagnoza = await _context.Dijagnoze.FindAsync(id);
            if (dijagnoza == null)
            {
                return NotFound();
            }

            return View(dijagnoza);
        }

        // POST: Dijagnoza/Delete/5
        [HttpPost("Delete/{id}")] // Oznaci da je ovo POST zahtev za potvrdu brisanja sa id parametrom
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dijagnoza = await _context.Dijagnoze.FindAsync(id);
            if (dijagnoza == null)
            {
                return NotFound();
            }
            _context.Dijagnoze.Remove(dijagnoza);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DijagnozaExists(int id)
        {
            return _context.Dijagnoze.Any(e => e.Id == id);
        }
    }
}
