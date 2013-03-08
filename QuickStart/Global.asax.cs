using System;
using System.Collections.Generic;
using System.Linq;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;
using QuickStart.Configuration;
using QuickStart.Configuration.Bootstrapping;
using System.Web.Routing;

 
namespace QuickStart
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
             FubuApplication.For<QuickStartRegistry>()
            .StructureMap(QuickStartRegistry.BuildWebsiteContainer())
            .Bootstrap();
            
            FubuApplication
                .For<QuickStartRegistry>()
                .StructureMapObjectFactory(x => x.AddRegistry<CoreRegistry>());
                
        }                
    }    
}
