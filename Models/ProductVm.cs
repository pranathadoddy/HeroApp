using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroApp.Models
{
    public class ProductVm
    {
        public int Id { get; set; }

        public Double Score { get; set; }

        public string  Name { get; set; }

        public int NumberOfNights { get; set; }

        public string FormattedAddressName { get; set; }

        public string ShortDescription { get; set; }
    }
}
