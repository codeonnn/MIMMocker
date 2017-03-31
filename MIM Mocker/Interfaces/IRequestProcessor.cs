﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titanium.Web.Proxy.EventArguments;

namespace MIM_Mocker
{
    public interface IRequestProcessor
    {
        Task<MockResponse> ProcessAsync(SessionEventArgs rq);
    }
}
