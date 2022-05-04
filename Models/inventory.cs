using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace productdatamodule.Models
{
    public class inventory
    {
        public int id { get; set; }
        [ForeignKey("food")]
        public int foodid { get; set; }
        public food food { get; set; }
        public double quantity { get; set; }
        public int reorderlevel { get; set; }
        public DateTime datetimesample{ get; set; }
    }
}
