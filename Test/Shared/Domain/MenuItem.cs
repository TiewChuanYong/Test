using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared.Domain
{
    public class MenuItem : BaseDomainModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public virtual Menu Menu { get; set; }

    }
}
