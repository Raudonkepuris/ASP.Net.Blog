using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;

namespace Blog.Controllers
{
    public class ApprovedEmailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApprovedEmailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApprovedEmails
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApprovedEmail.ToListAsync());
        }

        // GET: ApprovedEmails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approvedEmail = await _context.ApprovedEmail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (approvedEmail == null)
            {
                return NotFound();
            }

            return View(approvedEmail);
        }

        // GET: ApprovedEmails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApprovedEmails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email")] ApprovedEmail approvedEmail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(approvedEmail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(approvedEmail);
        }

        // GET: ApprovedEmails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approvedEmail = await _context.ApprovedEmail.FindAsync(id);
            if (approvedEmail == null)
            {
                return NotFound();
            }
            return View(approvedEmail);
        }

        // POST: ApprovedEmails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email")] ApprovedEmail approvedEmail)
        {
            if (id != approvedEmail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(approvedEmail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApprovedEmailExists(approvedEmail.Id))
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
            return View(approvedEmail);
        }

        // GET: ApprovedEmails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approvedEmail = await _context.ApprovedEmail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (approvedEmail == null)
            {
                return NotFound();
            }

            return View(approvedEmail);
        }

        // POST: ApprovedEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var approvedEmail = await _context.ApprovedEmail.FindAsync(id);
            if (approvedEmail != null)
            {
                _context.ApprovedEmail.Remove(approvedEmail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApprovedEmailExists(int id)
        {
            return _context.ApprovedEmail.Any(e => e.Id == id);
        }
    }
}
