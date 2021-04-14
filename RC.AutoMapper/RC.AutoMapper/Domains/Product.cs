using System;
using System.Collections.Generic;

namespace RC.AutoMapper.Domains
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime Validity { get; set; }
        public List<Product> Products { get; set; }

    }
}
