﻿using System;

namespace Trabalho_Final.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public string Barcodetype { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public decimal Costprice { get; set; }
    }
}
