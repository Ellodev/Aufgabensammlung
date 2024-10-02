using System.Net;
using Newtonsoft.Json.Linq;

namespace Aufgabe_17
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            while (true)
            {
                FetchJoke();
                Console.WriteLine("Press Enter to get another joke...");
                Console.ReadLine(); // Wait for user input before fetching the next joke
                
            }
        }

        static async void FetchJoke()
        {
            try
            {
                using HttpResponseMessage response = await client.GetAsync("https://witzapi.de/api/joke/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                
                parsejoke(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        static void parsejoke(string responseBody)
        {
            Console.Write(JObject.Parse(responseBody)["data"].ToString());
        }
    }
}