using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        
        static  void Main(string[] args)
        {
            //  callHttpExampleAsync();
            //   topUpRequest();

            OurCode ourCode = new OurCode("tapos.aa@gmail.com", "Rcis123$..");
            ourCode.topUpCode();

           
        }

        private static void topUpRequest()
        {
            
        }

        private  static void   callHttpExampleAsync()
        {
            HttpClient client = new HttpClient();
            string url = "https://sanapi.cashbaba.com.bd/api/Payment/CustomerLogin";
            UserInformation userInfo = new UserInformation()
            {
                UserName = "tapos.aa@gmail.com",
                Password = "Rcis123$.."

            };
           // var stringContent = new StringContent(JsonConvert.SerializeObject(userInfo), Encoding.UTF8, "application/json");
            HttpResponseMessage response =  client.PostAsJsonAsync(url, userInfo).Result;
            if (response.IsSuccessStatusCode)
            {
                var header = response.Headers.GetValues("token").FirstOrDefault();
                var data =  JObject.Parse(response.Content.ReadAsStringAsync().Result);
               
                Console.WriteLine(data);
            }
           
            Console.ReadKey();
        }
    }
}
