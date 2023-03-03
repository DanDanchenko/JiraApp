using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToDoCosmos.Domain
{
    public class Subtask
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public User Assignee { get; set; }
        public string Staatus { get; set; }
    }
}
