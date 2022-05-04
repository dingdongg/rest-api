using System.Collections.Generic;
using APIProject.Models;

namespace APIProject.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        // fake hard-coded data for testing the repository
        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command> {
                new Command { 
                    Id=0, 
                    HowTo="Boil an egg", 
                    Line="Boil water", 
                    Platform="Kettle & pan"
                }, 
                new Command { 
                    Id=1, 
                    HowTo="Chop up green onions", 
                    Line="Get a knife", 
                    Platform="Cutting board"
                }, 
                new Command { 
                    Id=2, 
                    HowTo="Fry kimchi", 
                    Line="Heat up pan", 
                    Platform="Frying pan"
                }
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { 
                Id=0, 
                HowTo="Boil an egg", 
                Line="Boil water", 
                Platform="Kettle & pan"
            };
        }
    }
}