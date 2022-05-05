using APIProject.DTOs;
using APIProject.Models;
using AutoMapper;

namespace APIProject.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDTO>();
        }
    }
}