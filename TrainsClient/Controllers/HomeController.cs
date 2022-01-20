using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
      ViewBag.StationsList = GetStationsList();
      return View();
    }

    [HttpPost]
    public PartialViewResult GetRoutes(int Origin, int Destination)
    {
      Console.WriteLine("you are in the route!");
      List<Route> model = Route.GetRoutes(Origin, Destination);
      return PartialView("_ResultsPartial", model);
    }

    private List<Object> GetStationsList()
    {
      var apiCallTask = ApiHelper.GetStations();
      string result = apiCallTask.Result;
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      return JsonConvert.DeserializeObject<List<Object>>(jsonResponse.ToString());
    }
  }
}
