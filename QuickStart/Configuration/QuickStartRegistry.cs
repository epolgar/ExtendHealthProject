using System;
using FubuMVC.Core;
using QuickStart.Handlers;
using QuickStart.Model;
using QuickStart.Home;
using StructureMap;

namespace QuickStart
{ 
    public class QuickStartRegistry : FubuRegistry
    {
        private static IContainer _container;

        public QuickStartRegistry()
        {
             // var httpVerbs = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase) { "GET", "POST", "PUT", "HEAD" };

            //httpVerbs.Each(verb => Routes.ConstrainToHttpMethod(action => action.Method.Name.Equals(verb, StringComparison.InvariantCultureIgnoreCase), verb));

            Actions.IncludeType<HomeAction>();
            

            Actions.FindBy(x =>
            {
                x.Applies.ToThisAssembly();
                x.IncludeClassesSuffixedWithEndpoint();

            });

            //Routes.HomeIs<DashboardViewModel>().ConstrainToHttpMethod(x => x.Method.Name.Equals("Get", StringComparison.InvariantCultureIgnoreCase), "GET");

            //Routes.HomeIs<DashboardViewModel>().ConstrainToHttpMethod(x => x.Method.Name.Equals("Post", StringComparison.InvariantCultureIgnoreCase), "POST");
            Routes.HomeIs<TaskListModel>().ConstrainToHttpMethod(x => x.Method.Name.Equals("Get", StringComparison.InvariantCultureIgnoreCase), "GET");

            Routes.HomeIs<TaskListModel>().ConstrainToHttpMethod(x => x.Method.Name.Equals("Post", StringComparison.InvariantCultureIgnoreCase), "POST");
            
            // can't access a lot of the different method calls that I should be able to access from here for some reason
            //Output.ToJson.WhenCallMatches(call => call.OutputType().Name.StartsWith("Json"));        
        }

        public static IContainer BuildWebsiteContainer()
        {
            Bootstrap();
            return _container;
        }

        public static void Bootstrap()
        {
            if (_container != null) return;

            _container = BootstrapContainer();
        }

        public static IContainer BootstrapContainer()
        {
            _container = new Container();
            return _container;
        }
    }    
}