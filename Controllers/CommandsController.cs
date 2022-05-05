using System.Collections.Generic;
using APIProject.Data;
using APIProject.DTOs;
using APIProject.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers
{
    // no view support in this architecture, so use ControllerBase over Controller
    [Route("api/commands")] // controller-level route
    [ApiController] 
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        // constructor to inject dependency
        public CommandsController(ICommanderRepo repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }

        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commandItems));
        }

        // GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDTO> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDTO>(commandItem));
            }
            return NotFound();
        }

        // POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO createDTO)
        {
            var commandModel = _mapper.Map<Command>(createDTO);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDTO>(commandModel);

            // return 201 code
            return CreatedAtRoute(nameof(GetCommandById), new {Id=commandReadDto.Id}, commandReadDto);
        }
    }
}