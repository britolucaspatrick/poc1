using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc1.Model
{
    public class Ticker
    {
        public int id { get; set; }
        public int exchange { get; set; } //0 - binance 1 - kucoin
        public string market { get; set; }
        public DateTime dateTimeNow { get; set; }
        public DateTime trade { get; set; }
        public string tradeTimeSpan { get; set; }
        public string lastPrice { get; set; }
        public string lastAmount { get; set; } //volume (price * quantidade)
        public bool changeRenew { get; set; }
    }
}
