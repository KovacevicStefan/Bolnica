using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using arhitektura_projekat.Models;
using Microsoft.EntityFrameworkCore;
using arhitektura_projekat.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace arhitektura_projekat.Controllers
{
    [Route("[controller]")]
    public class OdeljenjeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OdeljenjeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Index()
        {
            var odeljenja = await _context.Odeljenja
                .Include(o => o.Bolnica)
                .ToListAsync();
            return View(odeljenja);
        }

        [HttpGet("Details/{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Details(int id)
        {
            var odeljenje = await _context.Odeljenja
                .Include(o => o.Bolnica)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (odeljenje == null) return NotFound();
            return View(odeljenje);
        }

        [HttpGet("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Bolnice = await _context.Bolnice.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Naziv
            }).ToListAsync();

            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Lokacija,Slika,BolnicaId")] Odeljenje odeljenje)
        {
            if (ModelState.IsValid)
            {
                if(string.IsNullOrEmpty(odeljenje.Slika)) {
                    odeljenje.Slika = "https://st4.depositphotos.com/14953852/24787/v/450/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg";
                }
                
                var bolnica = await _context.Bolnice.FindAsync(odeljenje.BolnicaId);
                if (bolnica == null) return BadRequest("Bolnica ne postoji.");
                
                _context.Add(odeljenje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Bolnice = await _context.Bolnice.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Naziv
            }).ToListAsync();

            return View(odeljenje);
        }

        [HttpGet("Edit/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var odeljenje = await _context.Odeljenja.FindAsync(id);
            if (odeljenje == null) return NotFound();

            ViewBag.Bolnice = await _context.Bolnice.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Naziv
            }).ToListAsync();

            return View(odeljenje);
        }

        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Lokacija,Slika,BolnicaId")] Odeljenje odeljenje)
        {
            if (id != odeljenje.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    if(string.IsNullOrEmpty(odeljenje.Slika)) {
                    odeljenje.Slika = "https://st4.depositphotos.com/14953852/24787/v/450/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg";
                }
                    _context.Update(odeljenje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdeljenjeExists(odeljenje.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Bolnice = await _context.Bolnice.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Naziv
            }).ToListAsync();

            return View(odeljenje);
        }

        private bool OdeljenjeExists(int id)
        {
            return _context.Odeljenja.Any(e => e.Id == id);
        }

        [HttpGet("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var odeljenje = await _context.Odeljenja
                .Include(o => o.Bolnica)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odeljenje == null) return NotFound();
            return View(odeljenje);
        }

        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odeljenje = await _context.Odeljenja.FindAsync(id);
            if (odeljenje != null)
            {
                _context.Odeljenja.Remove(odeljenje);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
