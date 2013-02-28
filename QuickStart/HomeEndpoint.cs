using System.Web.Routing;
using Bottles;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using QuickStart.Model;

namespace QuickStart
{
	public class HomeModel
	{
		public string Message { get; set; }
        public TaskList List { get; set; }
	}    
	
	// Fubu's default policies look for classes suffixed with "Endpoint" or "Endpoints"
    public class HomeEndpoint
	{
		// Fubu will use HomeEndpoint.Index as the default "home" route
		public HomeModel Index()
		{
			return new HomeModel { Message = "This is the To Do List" 
                                    List = new TaskList()   };
		}

        public HomeModel 
	}
}