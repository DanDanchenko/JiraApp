using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCosmos.Domain;

namespace ToDoCosmos.BusinessLogic.Models
{
    public class ChangeSubtaskStatusDTO
    {
        public Guid UserStoryId { get; set; }
        public Guid Id { get; set; }
        public string Status { get; set; }
    }
}
