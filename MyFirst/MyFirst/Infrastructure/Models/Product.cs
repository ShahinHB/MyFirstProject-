﻿using System;
using System.Collections.Generic;
using System.Text;
using MyFirst.Infrastructure.Enums;

namespace MyFirst.Infrastructure.Models
{
    public class Product
    {
        
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public Category ProductCategory { get; set; }
        public int Count { get; set; }
        public int ProductCode { get; set; }

    }
}
