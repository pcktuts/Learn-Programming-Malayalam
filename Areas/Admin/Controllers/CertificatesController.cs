using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Learn_Programming_Malayalam.Areas.Admin.Models;
using Learn_Programming_Malayalam.Data;
using Microsoft.AspNetCore.Authorization;

namespace Learn_Programming_Malayalam.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CertificatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CertificatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Certificates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Certificates.Include(c => c.Course).Include(c => c.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Certificates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate = await _context.Certificates
                .Include(c => c.Course)
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificate == null)
            {
                return NotFound();
            }

            return View(certificate);
        }

        // GET: Admin/Certificates/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirstName");
            return View();
        }

        // POST: Admin/Certificates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,ProjectUrl,Description,StartedAt,CompletedAt,StudentId,CourseId")] Certificate certificate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certificate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", certificate.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirstName", certificate.StudentId);
            return View(certificate);
        }

        // GET: Admin/Certificates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate = await _context.Certificates.FindAsync(id);
            if (certificate == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", certificate.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirstName", certificate.StudentId);
            return View(certificate);
        }

        // POST: Admin/Certificates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,ProjectUrl,Description,StartedAt,CompletedAt,StudentId,CourseId")] Certificate certificate)
        {
            if (id != certificate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificateExists(certificate.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", certificate.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirstName", certificate.StudentId);
            return View(certificate);
        }

        // GET: Admin/Certificates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate = await _context.Certificates
                .Include(c => c.Course)
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificate == null)
            {
                return NotFound();
            }

            return View(certificate);
        }

        // POST: Admin/Certificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certificate = await _context.Certificates.FindAsync(id);
            _context.Certificates.Remove(certificate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificateExists(int id)
        {
            return _context.Certificates.Any(e => e.Id == id);
        }
    }
}
