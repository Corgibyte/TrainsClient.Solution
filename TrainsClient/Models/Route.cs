using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TrainsClient.Models
{
  public class Route
  {
    public List<string> StationNames {get; set;}
    public int TotalTravelTime {get; set;}
    public double TotalFare {get; set;}
    public static List<Route> GetRoutes(int origin, int destination)
    {   
      var apiCallTask = ApiHelper.GetRoutes(origin, destination);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Route> routes = JsonConvert.DeserializeObject<List<Route>>(jsonResponse.ToString());
      
      int listIndex = 0;
      foreach (JToken token in jsonResponse)
      {
        List<string> names = new List<string>();
        foreach (JToken stationToken in token.SelectToken("stations"))
        {
          names.Add((string)stationToken.SelectToken("name"));
        }
        routes[listIndex].StationNames = names;
        listIndex++;
      }
      return routes;
    }
  }
}