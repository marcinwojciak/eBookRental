using eBookRental.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookRental.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiController : Controller
    {
        protected readonly ICommandDispatcher CommandDispatcher;

        public ApiController(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }

    }
}
