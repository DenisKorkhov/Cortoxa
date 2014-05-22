using System.Web.Mvc;

namespace Cortoxa.Web.MVC.Helpers
{
    public static class UrlExtentions
    {
        public static bool IsController<TController>(this UrlHelper helper) where TController : Controller
        {
            return typeof(TController).Name == helper.RequestContext.RouteData.Values["Controller"].ToString();
        }
    }
}