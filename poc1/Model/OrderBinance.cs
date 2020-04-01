using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc1.Model
{
    public class OrderBinance
    {
        public int id { get; set; }
        public string price { get; set; }
        public string qty { get; set; }
        public string quoteQty { get; set; }
        public long time { get; set; }
        public bool isBuyerMaker { get; set; }
        public bool isBestMatch { get; set; }
        
        [NotMappedAttribute]
        public TimeSpan TradeTimeSpan
        {
            get
            {
                return TimeSpan.FromTicks(time);
            }
        }
        [NotMappedAttribute]
        public TimeSpan TradeTimeNow
        {
            get
            {
                return DateTime.Now.TimeOfDay;
            }
        }
        public string Symbol { get; set; }
        public bool ChangeRenew { get; set; }
        public double LastAmout { get; set; }
    }

    public class ListOrderBinance : List<OrderBinance> { }
}
