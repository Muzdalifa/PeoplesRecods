using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RaorPages.Data;
using RaorPages.Models;

namespace RaorPages.Pages
{
    public class ViewModel : PageModel
    {
        private readonly ILogger<ViewModel> _logger;
        private readonly SMSDbContext _db;

        public IList<Student> Students;

        public ViewModel(ILogger<ViewModel> logger, SMSDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task OnGetAsync()
        {
            Students = await _db.Students.ToListAsync();
        }
                
        public async Task<ActionResult> OnGetDelete(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
            return RedirectToPage("View");
        }
        

    }
}
