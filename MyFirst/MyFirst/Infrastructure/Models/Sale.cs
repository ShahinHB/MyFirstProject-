﻿using System;
using System.Collections.Generic;
using System.Text;


namespace MyFirstProject.Infrastructure.Models
{
    class Sale
    {
        public int SaleNumber { get; set; }
        public double SalePrice { get; set; }
        public List<SaleItem> SaleItems { get; set; }
        public DateTime Date { get; set; }

    }
}
