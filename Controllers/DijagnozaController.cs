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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dijagnoze = await _context.Dijagnoze.ToListAsync();
            return View(dijagnoze);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var dijagnoza = await _context.Dijagnoze.FindAsync(id);
            if (dijagnoza == null) return NotFound();

            return View(dijagnoza);
        }

        [HttpGet("Create")]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
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

        [HttpGet("Edit/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var dijagnoza = await _context.Dijagnoze.FindAsync(id);
            if (dijagnoza == null) return NotFound();

            return View(dijagnoza);
        }

        [HttpPost("Edit/{id}")]
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

        [HttpGet("Delete/{id}")]
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

        [HttpPost("Delete/{id}")]
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
