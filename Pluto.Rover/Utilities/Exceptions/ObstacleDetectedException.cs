using System;

namespace Pluto.Rover.Utilities.Exceptions
{
    /// <summary>
    /// Custom exception that is thrown when obstacle is detected
    /// </summary>
    public class ObstacleDetectedException : Exception
    {
        public ObstacleDetectedException()
        {
        }

        public ObstacleDetectedException(string message)
            : base(message)
        {
        }

        public ObstacleDetectedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
