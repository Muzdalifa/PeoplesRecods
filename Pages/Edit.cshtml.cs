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
    public class EditModel : PageModel
    {
        public readonly SMSDbContext _db;

        public EditModel(SMSDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { get; set; }
        
        //when the page loaded it will be loaded with specified student id
        public void OnGet(int id)
        {
            var student = _db.Students.FirstOrDefault(x=> x.Id == id);
            if (student != null)
            {
                Student = student;
            }
               
        }

        // Editing student
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var student = _db.Students.Find(Student.Id);
            if (student != null)
            {
                student.FirstName = Student.FirstName;
                student.LastName = Student.LastName;
                student.PhoneNumber = Student.PhoneNumber;
                student.ImageName = Student.ImageName;
                _db.Update(student);
               
                
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("View");


        }
    }
}