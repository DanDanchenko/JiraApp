using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCosmos.Domain;

namespace ToDoCosmos.BusinessLogic.Models
{
    public class CreateSubtaskDTO
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserStoryId { get; set; }

    }
}
