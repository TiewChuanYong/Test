using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared.Domain
{
    public class Order : BaseDomainModel
    {
        public int Price { get; set; }
        public Boolean Paid { get; set; }
        public virtual Make Make { get; set; }
        public virtual Customer Customer { get; set; }
        
    }
}
