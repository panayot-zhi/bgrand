using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace BGRandomGenerator.Controllers
{
    public abstract class MainControllerBase : ControllerBase
    {
        protected readonly IHostingEnvironment Environment;        

        protected MainControllerBase(IHostingEnvironment environment)
        {
            Environment = environment;
        }

        public ActionResult Ping()
        {
            return Ok(DateTime.Now);
        }
    }
}
