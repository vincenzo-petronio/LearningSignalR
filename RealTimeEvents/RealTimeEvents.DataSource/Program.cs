using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RealTimeEvents.DataSource
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello Console!");
            await SendData();
        }

        private static async Task SendData()
        {
            while (true)
            {
                // random delay
                double max = 10;
                double min = 0.5;
                double randomInterval = (new Random()).NextDouble() * (max - min) + min;
                await Task.Delay(TimeSpan.FromSeconds(randomInterval));

                using (HttpClient httpClient = new HttpClient())
                {
                    string msg = "A new message after " + randomInterval.ToString() + " ms";
                    HttpContent httpContent = new StringContent(JsonSerializer.Serialize(msg), Encoding.UTF8, "application/json");
                    HttpRequestMessage message = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri("http://host.docker.internal:5000/api/event"),
                        Content = httpContent
                    };
                    var resultForDebug = await httpClient.SendAsync(message, default(CancellationToken));
                }
            }
        }
    }
}
