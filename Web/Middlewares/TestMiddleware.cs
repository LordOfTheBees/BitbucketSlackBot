using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Middlewares
{
    public class TestMiddleware
    {
        private RequestDelegate _next;

        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine(context.Request.Path);
            Console.WriteLine(string.Join('|', context.Request.Query));
            await _next.Invoke(context);
        }
    }
}
