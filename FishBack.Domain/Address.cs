﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishBack.Domain
{
    public class Address
    {
        public int Id { get; set; }

        //public User User { get; set; }

        public string Street { get; set; }
        public string ZipCode { get; set; }
        public DateTime Date { get; set; }
    }
}
