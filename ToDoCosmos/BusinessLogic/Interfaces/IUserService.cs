﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ToDoCosmos.BusinessLogic.Interfaces
{
    public interface IUserService
    {
         Guid CurrentUserId   { get; }
    }
}
