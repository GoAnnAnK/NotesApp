using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    public class Transaction
    {
        class Transactions
        {
            public string Type { get; set; }
            public decimal Amout { get; set; }
            public DateTime DateCreated { get; set; }

        }
    }
}
