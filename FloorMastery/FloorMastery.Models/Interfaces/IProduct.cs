﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.Models.Interfaces
{
    public interface IProduct
    {
        //load product
        List<Products> ListProducts(); 
    }
}
