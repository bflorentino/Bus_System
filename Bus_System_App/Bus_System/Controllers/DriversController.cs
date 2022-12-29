using Microsoft.AspNetCore.Mvc;
using Bus_System.Models.BindingModel;
using System.Threading.Tasks;
using Bus_System.Services;

namespace Bus_System.Controllers
{
    public class DriversController : Controller
    {

        private readonly IDriverServices _driverServices;

        public DriversController(IDriverServices driverServices) {
            
            _driverServices = driverServices;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddDriver()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> AddDriver(DriverBinding driver)
        {
            if (ModelState.IsValid)
            {
                var response = await _driverServices.AddDriver(driver);
                ViewBag.success  = response;

                return RedirectToAction("ViewAllDrivers");
            }

            return View(driver);
        }

        public async Task <IActionResult> ViewAllDrivers()
        {
            var drivers = await _driverServices.GetAllDrivers();

            if(drivers != null)
            {
               return View(drivers);
            }

            ViewBag.errorMessage = "Hubo un error al obtener los datos del servidor";
            return RedirectToAction("Index");
        }
    }
}
