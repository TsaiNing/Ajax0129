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
            //int x = 10;
            //int y = 0;
            //int z = x / y;
            Thread.Sleep(3000);
            return Content("<h2>哈囉~Index</h2>", "text/html", Encoding.UTF8);
        }
        public IActionResult Register(string name,int age= 28)
        {
            if (string.IsNullOrEmpty(name)) 
            {
                name = "guest";
            }
            return Content($"Hello {name},{age}歲了!","text/plain", Encoding.UTF8);
        }

        public IActionResult CheckAccount(Member member)
        {
            if (string.IsNullOrEmpty(member.Name))
            {
                member.Name = "guest";
            }
            return Content($"Hello {member.Name},{member.Age}歲了,電子郵件是{member.Email}!", "text/plain", Encoding.UTF8);
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
