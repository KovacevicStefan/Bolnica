using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using arhitektura_projekat.Data;
using arhitektura_projekat.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace arhitektura_projekat.Controllers
{
    public class PacijentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacijentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pacijent
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var pacijenti = await _context.Pacijenti
                .Include(p => p.Odeljenje)
                .Include(p => p.Dijagnoza)
                .ToListAsync();
            return View(pacijenti);
        }

        [HttpGet("Details/{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Details(int id)
        {
            var pacijent = await _context.Pacijenti
                .Include(p => p.Odeljenje)
                .Include(p => p.Dijagnoza)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pacijent == null) return NotFound();
            return View(pacijent);
        }

        // GET: Pacijent/Create
        [HttpGet("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Odeljenja = await _context.Odeljenja.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Naziv
            }).ToListAsync();

            ViewBag.Dijagnoze = await _context.Dijagnoze.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Naziv
            }).ToListAsync();

            return View();
        }

        // POST: Pacijent/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,Zdr_osiguranje,DatumRodjenja,Slika,OdeljenjeId,DijagnozaId")] Pacijent pacijent)
        {
            if (ModelState.IsValid)
            {
                if(string.IsNullOrEmpty(pacijent.Slika)) {
                    pacijent.Slika = "https://storage.needpix.com/rsynced_images/blank-profile-picture-973460_1280.png";
                }
                pacijent.DatumRodjenja = DateTime.SpecifyKind(pacijent.DatumRodjenja, DateTimeKind.Utc);
                _context.Add(pacijent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Odeljenja = await _context.Odeljenja.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Naziv
            }).ToListAsync();

            ViewBag.Dijagnoze = await _context.Dijagnoze.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Naziv
            }).ToListAsync();

            return View(pacijent);
        }

        // GET: Pacijent/Edit/5
        [HttpGet("Edit/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var pacijent = await _context.Pacijenti.FindAsync(id);
            if (pacijent == null) return NotFound();

            ViewBag.Odeljenja = await _context.Odeljenja.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Naziv
            }).ToListAsync();

            ViewBag.Dijagnoze = await _context.Dijagnoze.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Naziv
            }).ToListAsync();

            return View(pacijent);
        }

        // POST: Pacijent/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,Zdr_osiguranje,DatumRodjenja,Slika,OdeljenjeId,DijagnozaId")] Pacijent pacijent)
        {
            if (id != pacijent.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    if(string.IsNullOrEmpty(pacijent.Slika)) {
                    pacijent.Slika = "https://storage.needpix.com/rsynced_images/blank-profile-picture-973460_1280.png";
                    }
                    pacijent.DatumRodjenja = DateTime.SpecifyKind(pacijent.DatumRodjenja, DateTimeKind.Utc);
                    _context.Update(pacijent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacijentExists(pacijent.Id))
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

            ViewBag.Odeljenja = await _context.Odeljenja.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Naziv
            }).ToListAsync();

            ViewBag.Dijagnoze = await _context.Dijagnoze.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Naziv
            }).ToListAsync();

            return View(pacijent);
        }

        private bool PacijentExists(int id)
        {
            return _context.Pacijenti.Any(e => e.Id == id);
        }

        [HttpGet("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var pacijent = await _context.Pacijenti
                .Include(p => p.Odeljenje)
                .Include(p => p.Dijagnoza)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacijent == null) return NotFound();
            return View(pacijent);
        }

        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacijent = await _context.Pacijenti.FindAsync(id);
            if (pacijent != null)
            {
                _context.Pacijenti.Remove(pacijent);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        
    }
}
