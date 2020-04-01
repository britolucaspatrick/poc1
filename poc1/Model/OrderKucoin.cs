using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc1.Model
{
    public class OrderKucoin
    {
        public int id { get; set; }
        public string symbol { get; set; }
        public string dealPrice { get; set; }
        public string dealValue { get; set; }
        public string amount { get; set; }
        public string fee { get; set; }
        public string side { get; set; }
        public TimeSpan createdAt { get; set; }

    }

    public class ListOrderKucoin : List<OrderKucoin> { }
}
