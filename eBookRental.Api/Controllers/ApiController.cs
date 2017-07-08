using eBookRental.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;

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
