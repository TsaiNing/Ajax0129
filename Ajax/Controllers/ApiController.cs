using Ajax.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Ajax.Controllers
{
    public class ApiController : Controller
    {

        private readonly MyDBContext _context;
        public ApiController(MyDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //return View();
            return Content("<h2>哈囉~Index</h2>", "text/html", Encoding.UTF8);
        }

        public IActionResult Avatar(int id=1)
        {
            Member? member = _context.Members.Find(id);
            if (member != null)
            {
                byte[] img = member.FileData;
                if(img != null) 
                {
                    return File(img, "image/jpeg");
                }
            }
            return NotFound();
        }
        public IActionResult Cities()
        {
            var cities = _context.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }

    }
}
