using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RequestSender
{
    class Program
    {
        static async void CheckVoid() {
            throw new Exception("testing exception"); 
            
        }
        static async Task CheckVoidTask()
        {
            throw new Exception("testing exception");
        }
        static async Task Main(string[] args)
        {
            try {
                CheckVoid();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(10);
            Console.WriteLine("Press 1 to async, 2 to sync OR ESC to exit");
            ConsoleKey key = Console.ReadKey().Key;
            while (key != ConsoleKey.Escape)
            {
                if (key != ConsoleKey.D1 && key != ConsoleKey.D2) {
                    Console.WriteLine("WRONG KEY");
                }
                else 
                    for (int i = 0; i <= 500; i++)
                    {
                        string json = "{ \"idAnimal\" : 1 }";
                        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                        Console.WriteLine($"start {i}");
                        try
                        {
                            /*
                            HttpResponseMessage resp = await httpClient.PostAsync(new Uri("https://localhost:5001/Animals/GetAnimalInfo"), httpContent);
                    
                            string resptext = resp.StatusCode.ToString();
                            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                resptext = await resp.Content.ReadAsStringAsync();
                            }
                            Console.WriteLine($"end {i} - {resptext}");
                            */
                            if (key == ConsoleKey.D1)
                            {
                                httpClient.PostAsync(new Uri("https://localhost:5001/Animals/GetAnimalInfo"), httpContent);
                            }
                            else if (key == ConsoleKey.D2)
                            {
                                httpClient.PostAsync(new Uri("https://localhost:5001/Animals/GetAnimalInfoSync"), httpContent);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"end {i} - Exeption");
                        }
                    
                        Console.WriteLine("---------------------");
                    }
                key = Console.ReadKey().Key;
            }
        }
    }
}
