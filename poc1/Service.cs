using Binance.Net.Objects;
using CryptoExchange.Net.Objects;
using Kucoin.Net;
using Kucoin.Net.Objects;
using Binance.Net;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using poc1.Model;

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

        public static WebCallResult<BinanceOrderBook> getBinanceOrderBook(string symbol, string side)
        {
            BinanceClientOptions clientOptions = new BinanceClientOptions(Uri);
            BinanceClient binance = new BinanceClient(clientOptions);
            return binance.GetOrderBook(symbol);

        }

        public static TicketBinance getTickerBinance(string symbol)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(APIKey)));
            var result = client.GetAsync("/api/v3/ticker/24hr?symbol=" + symbol).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> ret = result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TicketBinance>(ret.Result);
            }
            else return null;
        }

        public static WebCallResult<KucoinFullOrderBook> getOrderBookKuCoin(string symbol, string side)
        {
            KucoinClientOptions clientOptions = new KucoinClientOptions();
            clientOptions.ApiCredentials = new KucoinApiCredentials(KCAPIKEY, APISecretKucoin, KCAPIPASSPHRASE);
            
            KucoinClient kucoin = new KucoinClient(clientOptions);
            return kucoin.GetOrderBook(symbol);
            
        }

        public static WebCallResult<KucoinTick> getTicketKuCoin(string symbol)
        {
            KucoinClientOptions clientOptions = new KucoinClientOptions();
            clientOptions.ApiCredentials = new KucoinApiCredentials(KCAPIKEY, APISecretKucoin, KCAPIPASSPHRASE);

            KucoinClient kucoin = new KucoinClient(clientOptions);
            return kucoin.GetTicker(symbol);

        }
    }
}
