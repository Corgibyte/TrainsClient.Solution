using System.Threading.Tasks;
using RestSharp;

namespace TrainsClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetRoutes(int origin, int destination)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"routes?origin={origin}&destination={destination}", Method.Get);
      RestResponse response = await client.ExecuteGetAsync(request);
      return response.Content;
    }
  }
}