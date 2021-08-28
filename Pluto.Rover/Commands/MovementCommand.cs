using Pluto.Rover.Rover;
using Pluto.Rover.Utilities;

namespace Pluto.Rover.Commands
{
    /// <summary>
    /// Implementation of ICommand
    /// </summary>
    public class MovementCommand : ICommand
    {
        private readonly IRover _rover;
        private readonly Movement _movement;

        public MovementCommand(IRover rover, Movement movement)
        {
            _rover = rover;
            _movement = movement;
        }

        /// <inheritdoc cref="ICommand.ExecuteAction"/>
        public void ExecuteAction()
        {
            switch (_movement)
            {
                case Movement.Forward:
                    _rover.MoveForward();
                    break;
                case Movement.Backward:
                    _rover.MoveBackward();
                    break;
                case Movement.Left:
                    _rover.TurnLeft();
                    break;
                case Movement.Right:
                    _rover.TurnRight();
                    break;
            }
        }
    }
}
