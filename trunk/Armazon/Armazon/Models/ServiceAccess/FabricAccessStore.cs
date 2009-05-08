﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.ServiceAccess
{
    public class FabricAccessStore
    {
        private static FabricAccessStore _instance = null;

        public static FabricAccessStore getInstance()
        {
            if (_instance == null)
                _instance = new FabricAccessStore();
            return _instance;
        }

        public IAccessStore createAmazonServiceAccess()
        {
            return new AmazonService();
        }

        public IAccessStore createArmazonServiceAccess(string url)
        {
            return new ArmazonService(url);
        }

    }
}
