using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace web_api
{
    public class LowLevelPlayerResult : ObjectResult
    {
        public LowLevelPlayerResult() : base(0)
        {

        }

        public LowLevelPlayerResult(object value) : base(value)
        { }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.StatusCode = StatusCode ?? 200;
            return Task.CompletedTask;
        }
    }
}
