using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace egitim_portali_final.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}