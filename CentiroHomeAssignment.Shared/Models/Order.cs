using System;
using System.Collections.Generic;
using System.Text;

namespace CentiroHomeAssignment.Shared.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public int OrderNumber { get; set; }
        public int OrderLineNumber { get; set; }
        public string ProductNumber { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ProductGroup { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public int CustomerNumber { get; set; }

    }
}
