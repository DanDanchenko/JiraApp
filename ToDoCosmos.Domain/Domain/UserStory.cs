using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoCosmos.Domain
{
    public class UserStory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? AssigneeId { get; set; }
        public string Status { get; set; }
        public ICollection<Subtask> Subtasks { get; set; }
    }
}
