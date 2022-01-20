using System.Threading.Tasks;
using RestSharp;

namespace TrainsClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetRoutes(int origin, int destination, string sortMethod)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"routes?origin={origin}&destination={destination}&sortMethod={sortMethod}", Method.Get);
      RestResponse response = await client.ExecuteGetAsync(request);
      return response.Content;
    }

    public static async Task<string> GetStations()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"stations", Method.Get);
      RestResponse response = await client.ExecuteGetAsync(request);
      return response.Content;
    }
  }
}