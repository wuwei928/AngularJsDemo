using System.Web.Mvc;

namespace CodefirstDemo.Web.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandleErrorAttribute());
        }
    }

    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled) return;
            filterContext.Controller.ViewData.Model = filterContext.Exception;
            filterContext.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = filterContext.Controller.ViewData
            };

            filterContext.ExceptionHandled = true;
        }
    }
}
