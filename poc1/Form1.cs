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
            //EXCHANGE BINANCE
            List<OrderBinance> list = Service.getTradeListBinance("LTCBTC", "500");
            binanceLTCBTCBuy.DataSource = list.FindAll(r => r.isBuyerMaker == true);
            binanceLTCBTCSale.DataSource = list.FindAll(r => r.isBuyerMaker == false);
            (binanceLTCBTCBuy.DataSource as List<OrderBinance>).ForEach(r => r.Symbol = "LTCBTC");
            (binanceLTCBTCSale.DataSource as List<OrderBinance>).ForEach(r => r.Symbol = "LTCBTC");

            List<OrderBinance> listN = Service.getTradeListBinance("NANOBTC", "500");
            binanceLTCNANOBuy.DataSource = listN.FindAll(r => r.isBuyerMaker == true);
            binanceLTCNANOSale.DataSource = listN.FindAll(r => r.isBuyerMaker == false);
            (binanceLTCNANOBuy.DataSource as List<OrderBinance>).ForEach(r => r.Symbol = "NANOBTC");
            (binanceLTCNANOSale.DataSource as List<OrderBinance>).ForEach(r => r.Symbol = "NANOBTC");

            entities.OrderBinances.AddRange((binanceLTCBTCBuy.DataSource as List<OrderBinance>));
            entities.OrderBinances.AddRange((binanceLTCBTCSale.DataSource as List<OrderBinance>));
            entities.OrderBinances.AddRange((binanceLTCNANOBuy.DataSource as List<OrderBinance>));
            entities.OrderBinances.AddRange((binanceLTCNANOSale.DataSource as List<OrderBinance>));


            //EXCHANGE KUCOIN
            List<OrderKucoin> listLTCBTCSale = Service.getTradeListKuCoin("LTC-BTC", "sell");
            (kucoinLTCBTCSale.DataSource as List<OrderKucoin>).AddRange(listLTCBTCSale);

            List<OrderKucoin> listNANOBTCSale = Service.getTradeListKuCoin("NANO-BTC", "sell");
            (kucoinNANOBTCSale.DataSource as List<OrderKucoin>).AddRange(listNANOBTCSale);

            List<OrderKucoin> listLTCBTCBuy = Service.getTradeListKuCoin("LTC-BTC", "buy");
            (kucoinLTCBTCBuy.DataSource as List<OrderKucoin>).AddRange(listLTCBTCBuy);

            List<OrderKucoin> listNANOBTCBuy = Service.getTradeListKuCoin("LTC-BTC", "buy");
            (kucoinNANOBTCBuy.DataSource as List<OrderKucoin>).AddRange(listNANOBTCBuy);

            entities.OrderKucoins.AddRange((kucoinLTCBTCSale.DataSource as List<OrderKucoin>));
            entities.OrderKucoins.AddRange((kucoinNANOBTCSale.DataSource as List<OrderKucoin>));
            entities.OrderKucoins.AddRange((kucoinLTCBTCBuy.DataSource as List<OrderKucoin>));
            entities.OrderKucoins.AddRange((kucoinNANOBTCBuy.DataSource as List<OrderKucoin>));

            entities.SaveChangesAsync();

        }

        private void Exchange_Load(object sender, EventArgs e)
        {
            timerBinance.Interval = 1500;
            timerBinance.Start();
        }
    }
}
