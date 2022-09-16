using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RS1Seminarski.Helper
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool admin, bool vodic)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { };
        }
    }

    public class MyAuthorizeImpl : IActionFilter
    {

        private readonly bool _admin;
        private readonly bool _vodic;


        public MyAuthorizeImpl(bool admin, bool vodic)
        {
            _admin = admin;
            _vodic = vodic;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.HttpContext.GetLoginInfo().isLogiran)
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }

            KretanjePoSistemu.Save(filterContext.HttpContext);

            if (filterContext.HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return;//ok - ima pravo pristupa
            }

            if (filterContext.HttpContext.GetLoginInfo().isPermisijaVodic && _vodic)
            {
                return;
            }
            //else nema pravo pristupa
            filterContext.Result = new UnauthorizedResult();
        }
    }
}