using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.Models.Responses
{
    public class ProductResponse : Response
    {
       public List<Products> products { get; set; }
    }
}
