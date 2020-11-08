using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RaorPages.Data;
using RaorPages.Models;

namespace RaorPages.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly SMSDbContext _db;

        [BindProperty]
        public Student Student { get; set; }

        public DetailsModel(SMSDbContext db)
        {
            _db = db;

        }        
        public void OnGet(int id)
        {
            var student = _db.Students.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                Student = student;
            }
        }

        
    }
}