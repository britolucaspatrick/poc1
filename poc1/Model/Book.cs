using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc1.Model
{
    public class Book
    {
        public int id { get; set; }
        public int exchange { get; set; } //0 - binance 1 - kucoin
        public string market { get; set; }
        public DateTime dateTimeNow { get; set; }
        public int order { get; set; }
        public string buyPrice { get; set; }
        public decimal buyAmount { get; set; }
        public string sellPrice { get; set; }
        public decimal sellAmount { get; set; }

    }
}
