namespace Pluto.Rover.Rover
{
    public interface IDriver
    {
        /// <summary>
        /// Drives the robot according to the instructions
        /// </summary>
        /// <param name="instructions">Instructions in string format, example: 'FFRFLFFB'.
        /// F=Forward; B=Backward; L=Turn left; R=Turn right;</param>
        void Drive(string instructions);
    }
}
