using Newtonsoft.Json;
using poc1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace poc1
{
    public class Service
    {
        protected static string Uri = "https://api.binance.com";
        protected static string APIKey = "ye8f5jaWDbJVfPgYMHQFf6gahT3qgZg7uLv6vXc2OLEtwvfoUYIze1pThEgeqNhW";
        protected static string APISecret = "Bp0DBASh8E3I2dtOEVg2Ki1brTAROfBBw1Rs60FM5XifBvDmfIZ1iQ0Xq1NqEREF";

        protected static string UriKucoin = "https://api.kucoin.com";
        protected static string KCAPIKEY = "5e8293c1005b020008e15219";
        protected static string APISecretKucoin = "bf800b7b-8ed3-4a11-a39c-ff65889df0d8";

        protected static string KCAPIPASSPHRASE = "Ppatrick@2020";

        public static List<OrderBinance> getTradeListBinance(string symbol, string limit)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(APIKey)));
            var result = client.GetAsync("/api/v3/trades?symbol=" + symbol + "&limit=" + limit).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> ret = result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<OrderBinance>>(ret.Result);
            }
            else return null;
        }

        public static List<OrderKucoin> getTradeListKuCoin(string symbol, string side)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(UriKucoin);
            string timestamp = DateTime.Now.TimeOfDay.Ticks.ToString();

            string str_to_sign = timestamp + "GET" + "/api/v1/hist-orders";
            var inferno = Encoding.ASCII.GetBytes(str_to_sign + APISecretKucoin);
            
            HMACSHA256 hmac = new HMACSHA256(inferno);
            

            client.DefaultRequestHeaders.Add("KC-API-KEY", KCAPIKEY);
            client.DefaultRequestHeaders.Add("KC-API-SIGN", Convert.ToBase64String(hmac.ComputeHash(inferno)));


            client.DefaultRequestHeaders.Add("KC-API-PASSPHRASE", KCAPIPASSPHRASE);
            client.DefaultRequestHeaders.Add("KC-API-TIMESTAMP", timestamp);

            var result = client.GetAsync("/api/v1/hist-orders?symbol=" + symbol + "&side=" + side).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> ret = result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<OrderKucoin>>(ret.Result);
            }
            else return null;
        }
    }
}
