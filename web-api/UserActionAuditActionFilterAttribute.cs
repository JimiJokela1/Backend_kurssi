using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace web_api
{
    public class UserActionAuditActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // A request from ip address {insertIpHere} to delete player ended at 9:30:36 12.10 2018

            if (!context.Canceled && context.Exception != null)
            {
                IRepository _repository = (IRepository) context.HttpContext.RequestServices.GetService(typeof(IRepository));

                string ip = context.HttpContext.Request.Host.Value;
                DateTime currentTime = DateTime.Now;

                _repository.WriteToLog("A request from ip address " + ip + " to delete player ended at " + currentTime.ToString());
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // A request from ip address {insertIpHere} to delete player started at 9:30:35 12.10 2018

            IRepository _repository = (IRepository) context.HttpContext.RequestServices.GetService(typeof(IRepository));

            string ip = context.HttpContext.Request.Host.Value; // ServerVariables["HTTP_X_FORWARDED_FOR"];
            DateTime currentTime = DateTime.Now;

            _repository.WriteToLog("A request from ip address " + ip + " to delete player started at " + currentTime.ToString());
        }
    }
}
