using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testlab1.Models
{
    public class Brands
    {
        public Brands(string Name, DateTime date)
        {
            this.Name = Name;
            this.date = date;
        }
        public string Name { get; set; }
        public DateTime date { get; set; }


    }
}
