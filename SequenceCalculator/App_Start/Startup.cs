﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SequenceCalculator.App_Start.Startup))]

namespace SequenceCalculator.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // app.MapSignalR();
        }
    }
}
