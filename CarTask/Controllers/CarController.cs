using CarTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarTask.Controllers
{
    public class CarController : Controller
    {
        private readonly List<Car> _cars;

        public CarController()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1 , Model = "c220"  , BrandId = 1 , Year = 2022 },
                new Car { Id = 2 , Model = "e46"   , BrandId = 2 , Year = 2022},
                new Car { Id = 3 , Model = "e60"  , BrandId = 2 , Year = 2022 },
                new Car { Id = 4 , Model = "f90"  , BrandId = 1 , Year = 2022 },
                new Car { Id = 5 , Model = "f10"  , BrandId = 3 , Year = 2022 },
          
            };
        }

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                return View(_cars);
            }
            else
            {
                if (_cars.Exists(s => s.BrandId == id))
                {
                    List<Car> cars = _cars.FindAll(s => s.BrandId == id);
                    return View(cars);
                }
                else
                {
                    return NotFound($"Gonderilen Group Id = {id} Yanlisdir");
                }
            }
        }

        public IActionResult Detail(int id)
        {
            if (id == null) return BadRequest("Studnet Id Mutleq Gonderilmelidi");

            Car car = _cars.Find(s => s.Id == id);

            if (car == null) return NotFound();

            return View(car);
        }
    }
}
