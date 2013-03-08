using StructureMap.Configuration.DSL;

namespace QuickStart.Configuration.Bootstrapping
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.LookForRegistries();
            });
        }
    }
}