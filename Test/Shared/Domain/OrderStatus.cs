using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared.Domain
{
    public class OrderStatus : BaseDomainModel
    {
        public Boolean Ordered { get; set; }
        public Boolean Preparing { get; set; }
        public Boolean Delivering { get; set; }
        public Boolean Cancelled { get; set; }
    }
}
