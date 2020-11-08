using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using RaorPages.Data;
using RaorPages.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace RaorPages.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly ILogger<RegistrationModel> _logger;
        private readonly SMSDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        [BindProperty]
        public Student Student { get; set; }

        public RegistrationModel(ILogger<RegistrationModel> logger, SMSDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _db = db;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult OnGet()
        {            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
                return Page();

            Student.ImageName = await SaveImage(Student.ImageFile);
            _db.Students.Add(Student);
            await _db.SaveChangesAsync();

            return RedirectToPage("./View");
        }




        public async Task<string> SaveImage(IFormFile imageFile)
        {
            String imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "Images", imageName);

            //resizing image
            using var image = Image.Load(imageFile.OpenReadStream());
            image.Mutate(x => x.Resize(256, 256));
            image.Save(imagePath);

            /*using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }*/
            return imageName;

        }
    }
}
