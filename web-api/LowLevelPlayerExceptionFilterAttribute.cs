using Microsoft.AspNetCore.Mvc.Filters;

namespace web_api
{
    public class LowLevelPlayerExceptionFilterAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(ExceptionContext context){
            if (context.Exception is LowLevelPlayerException){
                context.Result = new LowLevelPlayerResult();
            }
        }
    }
}