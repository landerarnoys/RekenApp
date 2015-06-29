using System.Web;
using System.Web.Mvc;

namespace Wiskunde_App
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //Te verwijderen voor custom error attribute
            //filters.Add(new HandleErrorAttribute());
        }
    }
}
