﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Middlewares
{
    public class TestMiddleware
    {
        ILogger<TestMiddleware> _logger;
        private RequestDelegate _next;

        public TestMiddleware(RequestDelegate next, ILogger<TestMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("=============================================================\r\n========================Request==============================");
            _logger.LogInformation(string.Format("{0} | {1}", context.Request.Path, string.Join('|', context.Request.Query)));

            await _next.Invoke(context);

            _logger.LogInformation("=============================================================\r\n=============================================================");
        }
    }
}
