﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared.Domain
{
    class Menu : BaseDomainModel
    {
        public string Name { get; set; }
        public virtual Restaurant Restaurant { get; set; }

    }
}
