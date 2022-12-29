using Bus_System.Models.Binding_Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bus_System.Services;

namespace Bus_System.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusServices _busServices;

        public BusController(IBusServices busServices)
        {
            _busServices = busServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBus()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> AddBus(BusBinding bus) 
        {
            if (ModelState.IsValid)
            {
               var response = await _busServices.AddBus(bus);

                if (response)
                {
                    ViewBag.success = true;
                }
                else
                {
                    ViewBag.success = false;
                }

                return RedirectToAction("ViewAllBuses");
            }

            return View(bus);
        }

        public async Task<IActionResult> ViewAllBuses()
        {
            var response = await _busServices.GetAllBuses();

            if(response != null)
            {
                return View(response);
            }

            ViewBag.errorMessage = "No se pudieron obtener los datos del servidor";
            return RedirectToAction("Index");
        }
    }
}
