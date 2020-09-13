using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using RaorPages.Data;
using RaorPages.Models;

namespace RaorPages.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly ILogger<RegistrationModel> _logger;
        private readonly SMSDbContext _db;

        [BindProperty]
        public Student Student { get; set; }

        public RegistrationModel(ILogger<RegistrationModel> logger, SMSDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult OnGet()
        {
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
                return Page();

            _db.Students.Add(Student);
            await _db.SaveChangesAsync();

            return RedirectToPage("./View");
        }

    }
}
