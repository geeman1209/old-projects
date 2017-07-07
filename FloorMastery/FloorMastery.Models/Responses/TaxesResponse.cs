using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.Models.Responses
{
    public class TaxesResponse : Response
    {
       public List<Taxes> taxes { get; set; }
    }
}
