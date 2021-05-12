using System;
using System.Collections.Generic;

namespace RC.AutoMapper.Request
{
    public class ProductRequest
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public DateTime Validity { get; set; }
        public IEnumerable<SupplierRequest> Suppliers { get; set; }
    }
}
