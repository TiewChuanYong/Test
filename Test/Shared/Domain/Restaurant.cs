using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared.Domain
{
    public class Restaurant : BaseDomainModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string ShortDescribtion { get; set; }

        [Required]
        public Boolean IsActive { get; set; }
        public virtual List<Menu> Menus { get; set; }
        public virtual List<Order> Orders { get; set; }
    }   
}
    