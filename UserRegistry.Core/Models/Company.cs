using System.Collections.Generic;

namespace UserRegistry.Core.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        virtual public ICollection<User> Users { get; set; }
    }
}
