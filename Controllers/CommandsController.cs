using System.Collections.Generic;
using APIProject.Data;
using APIProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers
{
    // no view support in this architecture, so use ControllerBase over Controller
    [Route("api/commands")] // controller-level route
    [ApiController] 
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;

        // constructor to inject dependency
        public CommandsController(ICommanderRepo repo)
        {
            _repository = repo;
        }

        // private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(commandItems);
        }

        // GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            return Ok(commandItem);
        }
    }
}