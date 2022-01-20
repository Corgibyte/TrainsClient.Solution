using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainsClient.Models;

namespace TrainsClient.Controllers
{
  public class HomeController : Controller
  {
    
    [Route("/")]
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public PartialViewResult GetRoutes(int Origin, int Destination)
    {
      
      return PartialView("_ResultsPartial");
    }
  }
}
