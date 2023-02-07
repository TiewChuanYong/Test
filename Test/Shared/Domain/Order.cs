using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared.Domain
{
    public class Order : BaseDomainModel
    {

        public double Price { get; set; }
        public Boolean Paid { get; set; }
        public virtual Make Make { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public int ResturantId { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
        
    }
}
