﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Armazon.Models.DataTypes;

namespace Armazon.Models.ServiceAccess
{
    interface IAccessStore
    {
        List<DTProduct> searchProducts(string fullText);
    }
}
