using System.Collections.Generic;
using APIProject.Models;

namespace APIProject.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int id);
    }
}