using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace LineNotifierCmd
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string AppJsonFilePath = "./lineToken.json";
            string lineToken = args.Length >= 1 ? args[0] : null;
            string message = args.Length > 0 ? args[1] : null;
            /*
            if (message == null) {
                throw new Exception("message cannot be empty!");
            }
            */
            Console.WriteLine(message);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", lineToken);
            var form = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("message", message)
                });

            try
            {
                HttpResponseMessage result = await client.PostAsync(new Uri("https://notify-api.line.me/api/notify"), form);
                /*
                Console.WriteLine(result.Content);
                Console.WriteLine(result.StatusCode.ToString());
                */
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        public class AppSettings
        {
            public string LineToken { get; set; }
        }
    }
}
