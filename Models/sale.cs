using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productdatamodule.Models
{
    public class sale
    {
        public int id { get; set; }
        public string customerid { get; set; }
        public double totalvalue { get; set; }
        public DateTime date{ get; set; }
        public double packingcharges { get; set; }
        public double gst { get; set; }
        public double discount { get; set; }
        public string modeofpayment { get; set; }
    }
}
