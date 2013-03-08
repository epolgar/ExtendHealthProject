using QuickStart.Repositories;
using StructureMap.Configuration.DSL;
using QuickStart.Model;

namespace QuickStart.Configuration.Bootstrapping
{
    public class DefaultConventionsRegistry : Registry
    {
        public DefaultConventionsRegistry()
        {
            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.WithDefaultConventions();
                     });

            For<IRepository>().Singleton().Use<Repository>();
        }
    }
}

