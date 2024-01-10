using egitim_portali_final.Controllers;
using egitim_portali_final.Models;
using egitim_portali_final.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;
using System.Security.Claims;

namespace egitim_portali_projesi.Controllers
{
    public class EduController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly IFileProvider _fileProvider;



        public EduController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, AppDbContext appDbcontext, IFileProvider fileProvider, AppDbContext context)
        {
            _context = appDbcontext;
            _roleManager = roleManager;
            _fileProvider = fileProvider;
            _userManager = userManager;
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var eduModel = _context.Educations.
                Include(x => x.Category).
                Where(x=>x.TeachersUserName == User.FindFirstValue(ClaimTypes.Name))
                .Select(x => new EducationModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Link = x.Link,
                    CategoryName = x.Category.Name,
                    TeachersUserName = x.TeachersUserName,
                }).ToList();
            return View(eduModel);



        }

        
        public IActionResult Insert()
        {
            List<SelectListItem> kategoriname = (from x in _context.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.kategoriname = kategoriname;
            return View();

        }

        [HttpPost]
        public IActionResult Insert(EducationModel model)
        {

            var rootfolder = _fileProvider.GetDirectoryContents("wwwroot");
            var videourl = "-";
            if (model.Video.Length > 0 && model.Video != null)
            {
                var dosya = Guid.NewGuid().ToString() + Path.GetExtension(model.Video.FileName);
                var dosyayolu = Path.Combine(rootfolder.First(x => x.Name == "Videos").PhysicalPath, dosya);
                using var stream = new FileStream(dosyayolu, FileMode.Create);
                model.Video.CopyTo(stream);
                videourl = dosya;
            }


            var education = new Education();
            education.Name = model.Name;
            education.Description = model.Description;
            education.Link = videourl;
            education.CategoryId = model.CategoryId;
            education.TeachersUserName = User.Identity.Name;
            _context.Educations.Add(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {

            var educationModel = _context.Educations.Select(x => new EducationModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Link = x.Link,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                TeachersUserName = x.TeachersUserName,

            }).SingleOrDefault(x => x.Id == id);
            return View(educationModel);
        }

        [HttpPost]
        public IActionResult Edit(EducationModel model)
        {
            var education = _context.Educations.SingleOrDefault(x => x.Id == model.Id);
            education.Name = model.Name;
            education.Description = model.Description;
            education.Link = model.Link;

            education.TeachersUserName = User.Identity.Name;


            _context.Educations.Update(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var educationModel = _context.Educations.Select(x => new EducationModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Link = x.Link,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                TeachersUserName = x.TeachersUserName,
                

            }).SingleOrDefault(x => x.Id == id);
            return View(educationModel);
        }

        [HttpPost]
        public IActionResult Delete(EducationModel model)
        {
            var education = _context.Educations.SingleOrDefault(x => x.Id == model.Id);
            _context.Educations.Remove(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            var educationModel = _context.Educations.Select(x => new EducationModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Link = x.Link,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                TeachersUserName = x.TeachersUserName,

            }).SingleOrDefault(x => x.Id == id);
            return View(educationModel);

        }

        [Authorize]

        public async Task<IActionResult> IndexForUser()
        {
            var eduModel = _context.Educations.
                Include(x => x.Category).
                Where(x => x.TeachersUserName == User.FindFirstValue(ClaimTypes.Name))
                .Select(x => new EducationModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Link = x.Link,
                    CategoryName = x.Category.Name,
                    TeachersUserName = x.TeachersUserName

                }).ToList();
            return View(eduModel);
        }

        public IActionResult DisplayForUser(int id)
        {
            var educationModel = _context.Educations.Select(x => new EducationModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Link = x.Link,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                TeachersUserName = x.TeachersUserName
                
            }).SingleOrDefault(x => x.Id == id);
            return View(educationModel);

        }
        public IActionResult GetCategoryList()
        {
            var category = _context.Categories.ToList();
            return View(category);
        }

        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category model)
        {
            var categoryExists = _context.Categories.FirstOrDefault(c => c.Name == model.Name);
            if (categoryExists == null)
            {
                var newCategory = new Category();
                newCategory.Name = model.Name;
                _context.Categories.Add(newCategory);
                _context.SaveChanges(); 
            }

            return RedirectToAction("GetCategoryList");
        }


    }
}