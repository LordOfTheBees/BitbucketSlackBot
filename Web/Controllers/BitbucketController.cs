using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Controllers
{
    [ApiController]
    [Route("Bitbucket")]
    public class BitbucketController : ControllerBase
    {
        public BitbucketController()
        {

        }

        [HttpPost("EventProcessing")]
        public IActionResult EventProcessing()
        {
            return this.Ok();
        }
    }
}
