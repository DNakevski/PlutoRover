using System;
using System.Collections.Generic;
using Pluto.Rover.Commands;
using Pluto.Rover.Utilities;
using Pluto.Rover.Utilities.Exceptions;

namespace Pluto.Rover.Rover
{
    /// <summary>
    /// Implementation of IDriver
    /// Responsible for reading the instructions, translating them into movement commands
    /// and executing them.
    /// It is also keeping history of all the movement commands executed.
    /// </summary>
    public class RoverDriver : IDriver
    {
        private readonly IRover _rover;
        private readonly List<ICommand> _commands;

        public RoverDriver(IRover rover)
        {
            _rover = rover;
            _commands = new List<ICommand>();
        }

        /// <inheritdoc cref="IDriver.Drive"/>
        public void Drive(string instructions)
        {
            if (string.IsNullOrEmpty(instructions))
                throw new ArgumentNullException(nameof(instructions), "Instructions should not be empty");

            foreach (var instruction in instructions)
            {
                ICommand movementCommand;
                switch (instruction)
                {
                    case 'F':
                        movementCommand = new MovementCommand(_rover, Movement.Forward);
                        break;
                    case 'B':
                        movementCommand = new MovementCommand(_rover, Movement.Backward);
                        break;
                    case 'L':
                        movementCommand = new MovementCommand(_rover, Movement.Left);
                        break;
                    case 'R':
                        movementCommand = new MovementCommand(_rover, Movement.Right);
                        break;
                    default:
                        throw new InvalidOperationException($"Invalid movement instructions: '{instruction}', " +
                                                            $"supported instructions are: 'F', 'B', 'L', 'R'");
                }

                //Execute the movement command
                try
                {
                    movementCommand.ExecuteAction();
                }
                catch (ObstacleDetectedException e)
                {
                    //TODO: an event can also be triggered here and logging can be added as well.
                    Console.WriteLine(e.Message);
                    Console.WriteLine($"The rover is at position: {_rover.Position}");

                    //obstacle is detected, terminate the instructions execution;
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Unknown exception: {e.Message}");
                    throw;
                }

                _commands.Add(movementCommand);
            }

            Console.WriteLine($"The Journey has ended, rover's final position is {_rover.Position}");
        }
    }
}
