using APIProject.DTOs;
using APIProject.Models;
using AutoMapper;

namespace APIProject.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Mapping from a model-level Command object to a read DTO
            CreateMap<Command, CommandReadDTO>();
            // Mapping from a created DTO to the model-level Command object
            CreateMap<CommandCreateDTO, Command>();
            // Mapping from a updated DTO to the model-level Command object
            CreateMap<CommandUpdateDTO, Command>();
        }
    }
}