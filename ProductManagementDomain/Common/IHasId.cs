﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementDomain.Common
{
    public interface IHasId
    {
        int Id { get; set; }
    }
}
