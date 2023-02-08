using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared.Domain
{
    public class OrderItem : BaseDomainModel
    {
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
        
    }
}
