﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TaxiQualifer.Web.Data;
using TaxiQualifer.Web.Data.Entities;

namespace TaxiQualifer.Web.Controllers
{
    public class TaxisController : Controller
    {
        private readonly DataContext _context;

        public TaxisController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Taxis.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxiEntity = await _context.Taxis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxiEntity == null)
            {
                return NotFound();
            }

            return View(taxiEntity);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaxiEntity taxiEntity)
        {
            if (ModelState.IsValid)
            {
                taxiEntity.Plaque = taxiEntity.Plaque.ToUpper();
                _context.Add(taxiEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxiEntity);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxiEntity = await _context.Taxis.FindAsync(id);
            if (taxiEntity == null)
            {
                return NotFound();
            }
            return View(taxiEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaxiEntity taxiEntity)
        {
            if (id != taxiEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                taxiEntity.Plaque = taxiEntity.Plaque.ToUpper();
                _context.Update(taxiEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxiEntity);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxiEntity = await _context.Taxis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxiEntity == null)
            {
                return NotFound();
            }

            _context.Taxis.Remove(taxiEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private bool TaxiEntityExists(int id)
        {
            return _context.Taxis.Any(e => e.Id == id);
        }
    }
}
