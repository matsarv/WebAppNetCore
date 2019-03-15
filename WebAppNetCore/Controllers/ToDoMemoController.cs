using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebAppNetCore.Controllers
{
    public class ToDoMemoController : Controller
    {
        public IActionResult Index()
        {
            string toDo ="";
            int? prio=0;
            
            toDo = HttpContext.Session.GetString("_ToDo");
            prio = HttpContext.Session.GetInt32("_Prio");

            ViewBag.ToDo = toDo;
            ViewBag.prio = prio;

            return View();
        }

        public IActionResult MakeToDo()
        {
            return View("SetToDo"); // Default: Name of method, this goes to SetToDo view
        }

        [HttpPost]
        public IActionResult MakeToDo(string toDo, int prio)
        {
            HttpContext.Session.SetString("_ToDo",toDo);
            HttpContext.Session.SetInt32("_Prio", prio);

            return RedirectToAction("Index","ToDoMemo"); //Controler obsolite in this example
        }

    }
}