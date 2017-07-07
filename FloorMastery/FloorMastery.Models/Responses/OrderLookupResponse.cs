using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.Models.Responses
{
   public class OrderLookupResponse : Response
    {
        public List<Order> Order { get; set; }
        public Order IndivOrder { get; set; }
    }
}
