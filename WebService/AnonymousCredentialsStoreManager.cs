﻿using commercetools.Sdk.HttpApi.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService
{
    public class AnonymousCredentialsStoreManager : InMemoryTokenStoreManager, IAnonymousCredentialsStoreManager
    {
        public string AnonymousId => "mvc-example" + DateTime.Now.ToString("yyyyMMddhhmmss");
    }
}
