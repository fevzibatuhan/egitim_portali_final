using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using egitim_portali_final.Models;
using egitim_portali_final.ViewModels;

namespace egitim_portali_projesi.Controllers
{
    public class UserListController : Controller
    {
        private readonly AppDbContext _context;

        public UserListController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult UsersList()
        {
            return View();
        }

        public IActionResult UserListAjax()
        {
            var userlistModels = _context.Users.Select(x => new UserModel()
            {
                Id = x.Id,
                FullName = x.FullName,
                Email = x.Email,
                UserName = x.UserName,

            }).ToList();


            return Json(userlistModels);
        }
        public IActionResult UserListByIdAjax(string id)
        {
            var userlistModel = _context.Users.Where(s => s.Id == id).Select(x => new AppUser()
            {
                Id = x.Id,
                FullName = x.FullName,
                UserName = x.UserName,
                Email = x.Email,

            }).SingleOrDefault();

            return Json(userlistModel);
        }

    }
}