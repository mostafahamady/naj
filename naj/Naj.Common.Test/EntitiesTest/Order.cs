using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naj.Common.Test
{
    public class Order : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string OrderDate { get; set; }
        public decimal Amount { get; set; }
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
