using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naj.Common.Test
{
    public class Customer : IEntity<Guid>,IEquatable<Customer>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            return Age + " ( " + this.Id + " ) " + FirstName + " " + LastName + "\n" + GetHashCode().ToString();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Customer);
        }

        public bool Equals(Customer other)
        {
            return FirstName == other.FirstName && LastName == other.LastName && Age == other.Age;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ FirstName.GetHashCode() ^ LastName.GetHashCode() ^ Age.GetHashCode();
        }
    }
}
