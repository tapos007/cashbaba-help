using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public  class OurCode
    {
        public  string userName { set; get; }
        public string  password { set; get; }
        public string token { set; get; }

        public OurCode(string username,string password)
        {
            this.userName = username;
            this.password = password;
        }


        public void loginMethod()
        {
            HttpClient client = new HttpClient();
            string url = "https://sanapi.cashbaba.com.bd/api/Payment/CustomerLogin";
            UserInformation userInfo = new UserInformation()
            {
                UserName = "tapos.aa@gmail.com",
                Password = "Rcis123$.."

            };
            // var stringContent = new StringContent(JsonConvert.SerializeObject(userInfo), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsJsonAsync(url, userInfo).Result;
            if (response.IsSuccessStatusCode)
            {
                var header = response.Headers.GetValues("token").FirstOrDefault();
                this.token = header;
                var data = JObject.Parse(response.Content.ReadAsStringAsync().Result);

               
            }
        }

        public void topUpCode()
        {
            loginMethod();
            TopUP topUP = new TopUP()
            {
                UserName = this.userName,
                Token = this.token,
                BankAccountNumber = "EAAAAH7/WGsJdjk5OyTZSBW0OhsMbOvqAStypJsbtN+pVe3ZN1dr/liAe6mIfcSKn4E4Ww==",
                BankCode = "JANB",
                CashAmount = "2000"
            };

            HttpClient client = new HttpClient();
            string url = "https://sanapi.cashbaba.com.bd/api/payment/WithdrawMoney";
            
            // var stringContent = new StringContent(JsonConvert.SerializeObject(userInfo), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsJsonAsync(url, topUP).Result;
            if (response.IsSuccessStatusCode)
            {
               // var header = response.Headers.GetValues("token").FirstOrDefault();
               // this.token = header;
                var data = JObject.Parse(response.Content.ReadAsStringAsync().Result);


            }
        }

    }
}
