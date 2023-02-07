﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public int ContactNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a vaild email address!")]
        [EmailAddress]
        public string EmailAddress { get; set; }

    }
}
