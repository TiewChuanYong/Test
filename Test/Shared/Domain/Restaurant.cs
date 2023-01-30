using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared.Domain
{
    class Restaurant : BaseDomainModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ShortDescribtion { get; set; }
        public Boolean IsActive { get; set; }

    }
}
