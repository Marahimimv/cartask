using CarTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CarTask.Controllers
{
    public class HomeController : Controller
    {


        private readonly List<Brand> _brands;

        public HomeController()
        {
            _brands = new List<Brand>
            {
                new Brand {Id = 1,Name = "Bmw"},
                new Brand {Id = 2,Name = "Mercedes"},
                new Brand {Id = 3,Name = "Audi"},
                new Brand {Id = 4,Name = "Wolkswagen"},
            };
        }

        public IActionResult Index()
        {

            return View(_brands);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return BadRequest("Group Id Mutleq Gonderilmelidi");

            if (!_brands.Exists(g => g.Id == id)) return NotFound("Gonderilen Id Yanlisdir");

            Brand brand = _brands.Find(g => g.Id == id);

            return View(brand);
        }

    }
}