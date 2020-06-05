using System;
using System.Collections.Generic;
using System.Text;

namespace EFCodeFirst.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}