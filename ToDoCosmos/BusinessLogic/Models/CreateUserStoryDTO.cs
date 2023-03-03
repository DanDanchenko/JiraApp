using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCosmos.Domain;

namespace ToDoCosmos.BusinessLogic.Models
{
    public class CreateUserStoryDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public User Assignee { get; set; }
        public List<Subtask> Subtasks { get; set; }
        public string Status { get; set; }



    }
}
