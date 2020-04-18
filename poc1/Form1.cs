using Binance.Net.Objects;
using CryptoExchange.Net.Objects;
using Kucoin.Net.Objects;
using poc1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poc1
{
    public partial class Exchange : Form
    {
        private poc1Entities entities = new poc1Entities();

        public Exchange()
        {
            InitializeComponent();
        }

        private void timerBinance_Tick(object sender, EventArgs e)
        {
            //BOOK LTCBTC BINANCE 
            int count = 0;
            WebCallResult<BinanceOrderBook> bookBinance = Service.getBinanceOrderBook("LTCBTC", "500");
            bookBinance.Data.Asks.ToList().ForEach(r =>
            {
                entities.Books.Add(new Book()
                {
                    exchange = 0,
                    market = "LTCBTC",
                    dateTimeNow = DateTime.Now,
                    order = count,
                    buyPrice = r.Price.ToString(),
                    buyAmount = r.Quantity
                });
                entities.SaveChanges();

                count++;
            });
            count = 0;
            bookBinance.Data.Bids.ToList().ForEach(r =>
            {
                entities.Books.Add(new Book()
                {
                    exchange = 0,
                    market = "LTCBTC",
                    dateTimeNow = DateTime.Now,
                    order = count,
                    sellPrice = r.Price.ToString(),
                    sellAmount = r.Quantity
                });
                entities.SaveChanges();


                count++;
            });

            //BOOK NANOBTC BINANCE 
            count = 0;
            bookBinance = Service.getBinanceOrderBook("NANOBTC", "500");
            bookBinance.Data.Asks.ToList().ForEach(r =>
            {
                entities.Books.Add(new Book()
                {
                    exchange = 0,
                    market = "NANOBTC",
                    dateTimeNow = DateTime.Now,
                    order = count,
                    buyPrice = r.Price.ToString(),
                    buyAmount = r.Quantity
                });
                entities.SaveChanges();

                count++;
            });
            count = 0;
            bookBinance.Data.Bids.ToList().ForEach(r =>
            {
                entities.Books.Add(new Book()
                {
                    exchange = 0,
                    market = "NANOBTC",
                    dateTimeNow = DateTime.Now,
                    order = count,
                    sellPrice = r.Price.ToString(),
                    sellAmount = r.Quantity
                });
                entities.SaveChanges();
                count++;
            });

            //BOOK LTCBTC KUCOIN
            count = 0;
            WebCallResult<KucoinFullOrderBook> bookKucoin = Service.getOrderBookKuCoin("LTC-BTC", "sell");
            bookKucoin.Data.Asks.ToList().ForEach(r =>
            {
                entities.Books.Add(new Book()
                {
                    exchange = 1,
                    market = "LTCBTC",
                    dateTimeNow = DateTime.Now,
                    order = count,
                    buyPrice = r.Price.ToString(),
                    buyAmount = r.Quantity
                });
                entities.SaveChanges();
                count++;
            });
            count = 0;
            bookKucoin.Data.Bids.ToList().ForEach(r =>
            {
                entities.Books.Add(new Book()
                {
                    exchange = 1,
                    market = "LTCBTC",
                    dateTimeNow = DateTime.Now,
                    order = count,
                    sellPrice = r.Price.ToString(),
                    sellAmount = r.Quantity
                });
                entities.SaveChanges();
                count++;
            });

            //BOOK NANOBTC KUCOIN
            count = 0;
            bookKucoin = Service.getOrderBookKuCoin("NANO-BTC", "sell");
            bookKucoin.Data.Asks.ToList().ForEach(r =>
            {
                entities.Books.Add(new Book()
                {
                    exchange = 1,
                    market = "NANOBTC",
                    dateTimeNow = DateTime.Now,
                    order = count,
                    buyPrice = r.Price.ToString(),
                    buyAmount = r.Quantity
                });
                entities.SaveChanges();
                count++;
            });
            count = 0;
            bookKucoin.Data.Bids.ToList().ForEach(r =>
            {
                entities.Books.Add(new Book()
                {
                    exchange = 1,
                    market = "NANOBTC",
                    dateTimeNow = DateTime.Now,
                    order = count,
                    sellPrice = r.Price.ToString(),
                    sellAmount = r.Quantity
                });
                entities.SaveChanges();
                count++;
            });

            //TICKET LTCBTC KUCOIN  
            WebCallResult<KucoinTick> ticketKucoin = Service.getTicketKuCoin("LTC-BTC");
            entities.Tickers.Add(new Ticker()
            {
                exchange = 1,
                market = "LTCBTC",
                dateTimeNow = DateTime.Now,
                trade = ticketKucoin.Data.Timestamp,
                lastPrice = ticketKucoin.Data.LastTradePrice.ToString(),
                lastAmount = ticketKucoin.Data.LastTradeQuantity.ToString(),
            });
            entities.SaveChanges();

            //TICKET NANO KUCOIN
            ticketKucoin = Service.getTicketKuCoin("NANO-BTC");
            entities.Tickers.Add(new Ticker()
            {
                exchange = 1,
                market = "NANOBTC",
                dateTimeNow = DateTime.Now, 
                trade = ticketKucoin.Data.Timestamp,
                lastPrice = ticketKucoin.Data.LastTradePrice.ToString(),
                lastAmount = ticketKucoin.Data.LastTradeQuantity.ToString(),
            });
            entities.SaveChanges();

            //TICKET LTCBTC BINANCE  
            TicketBinance ticketBinance = Service.getTickerBinance("LTCBTC");
            entities.Tickers.Add(new Ticker()
            {
                exchange = 0,
                market = "LTCBTC",
                dateTimeNow = DateTime.Now,
                trade = DateTime.Now,
                tradeTimeSpan = ticketBinance.openTime.ToString(),
                lastPrice = ticketBinance.lastPrice.ToString(),
                lastAmount = ticketBinance.lastQty.ToString(),
            });
            entities.SaveChanges();

            //TICKET NANOBTC BINANCE  
            ticketBinance = Service.getTickerBinance("NANOBTC");
            entities.Tickers.Add(new Ticker()
            {
                exchange = 0,
                market = "NANOBTC",
                trade = DateTime.Now,
                dateTimeNow = DateTime.Now, //no ato do envio da requisicao
                tradeTimeSpan = ticketBinance.openTime.ToString(),//recent trades list (1) - campo time
                lastPrice = ticketBinance.lastPrice.ToString(),
                lastAmount = ticketBinance.lastQty.ToString(),
            });
            entities.SaveChanges();
        }

        private void Exchange_Load(object sender, EventArgs e)
        {
            timerBinance.Interval = 1500;
            timerBinance.Start();
        }
    }
}
