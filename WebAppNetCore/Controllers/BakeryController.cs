using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppNetCore.Models;


namespace WebAppNetCore.Controllers
{
    public class BakeryController : Controller
    {
        ICakeService _cakeService;

        public BakeryController(ICakeService cakeService) // Dependency Injection
        {
            _cakeService = cakeService;
        }



        public IActionResult Index()
        {
            return View(_cakeService.AllCakes());
        }

        [HttpPost]
        public IActionResult Index(string name, int price, string details)
        {
            _cakeService.CreateCake(name, price, details);

            return View(_cakeService.AllCakes());
        }

    }
}