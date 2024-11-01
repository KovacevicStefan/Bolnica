using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using arhitektura_projekat.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using arhitektura_projekat.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace arhitektura_projekat.Controllers
{
    [Route("[controller]")]
    public class BolnicaController : Controller
    {
        private readonly ILogger<BolnicaController> _logger;
        private readonly ApplicationDbContext _context;

        public BolnicaController(ILogger<BolnicaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var bolnice = await _context.Bolnice.ToListAsync();
            return View(bolnice);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var bolnica = await _context.Bolnice.FindAsync(id);
            if (bolnica == null)
            {
                return NotFound();
            }
            return View(bolnica);
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
        public async Task<IActionResult> Create([Bind("Id,Naziv,Adresa,Budzet,BrojTelefona,Slika")] Bolnica bolnica)
        {
            if (ModelState.IsValid)
            {
                if(string.IsNullOrEmpty(bolnica.Slika)) {
                    bolnica.Slika = "https://st4.depositphotos.com/14953852/24787/v/450/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg";
                }
                _context.Add(bolnica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bolnica);
        }

        [HttpGet("Edit/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var bolnica = await _context.Bolnice.FindAsync(id);
            if (bolnica == null)
            {
                return NotFound();
            }
            return View(bolnica);
        }

        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Adresa,Budzet,BrojTelefona,Slika")] Bolnica bolnica)
        {
            if (id != bolnica.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(string.IsNullOrEmpty(bolnica.Slika)) {
                    bolnica.Slika = "https://st4.depositphotos.com/14953852/24787/v/450/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg";
                }
                    _context.Update(bolnica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BolnicaExists(bolnica.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bolnica);
        }

        [HttpGet("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var bolnica = await _context.Bolnice.FindAsync(id);
            if (bolnica == null)
            {
                return NotFound();
            }
            return View(bolnica);
        }

        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bolnica = await _context.Bolnice.FindAsync(id);
            if (bolnica == null)
            {
                return NotFound();
            }
            _context.Bolnice.Remove(bolnica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BolnicaExists(int id)
        {
            return _context.Bolnice.Any(e => e.Id == id);
        }
    }
}
