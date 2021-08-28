# Pluto Rover

## The solution
The problematics of the exercise moving Rover on a planet, and in general instructing any vehicle to move in some direction immediately associates with the Command design pattern.  Hence, for the purpose of this exercise I decided to go with approach where I would  be implementing the mentioned designed pattern. At least a version of it, up to a point where it catches the concept and the benefits of the command design pattern but it doesn't introduce too much overhead and boilerplate code.  
The reason why I went with this approach is because I wanted to keep the movement logic inside the rover but decouple the controlling logic out of it. As well as being able to keep track of the commands that were executed.  

The basic idea behind the solution is to have one rover controller (RoverDriver in our case) that reads the series of instructions, translates them into commands and triggers their execution. The commands then are calling the appropriate movement function of the Rover which given his current position and the movement calculates the new position. In case the rover encounters some obstacle along the way it stays put to its last position and alerts about the obstacle.

## Project structure
The solution consists of two projects: **Pluto.Rover** that contains the solution code and **Pluto.Rover.Tests** that contains the unit tests for the components from **Pluto.Rover**.  

The **Pluto.Rover** project is organized in folders by the domain of the classes. Meaning, if the classes are related to the rover than they are in the **Rover** folder, if they are related to the commands they are located in the **Commands** folder. I favored this approach for the particular solution because it gives clear idea about the structure and the namespaces of the classes are in coordination with their domain.   

The tests are organized in the same manner. Each of the tests are located in the corresponding folder that matches their domain and folder structure of the component they they are testing from the **Pluto.Rover** project. 

#### Solution Structure:

```csharp
PlutoRoverExercise
  |
  |-Pluto.Rover
  |   |
      |-Commands
      |   |-ICommand.cs
          |-Command.cs
      |-Models
      |   |-DirectionalPosition.cs
          |-Position.cs
      |-Planet
      |   |-IPlanet.cs
          |-Pluto.cs
      |-Rover
      |   |-IDriver.cs
          |-IRover.cs
          |-Rover.cs
          |-RoverDriver.cs
      |-Utilities
      |   |-Enums.cs
          |-Exceptions
              |-ObstacleDetectedException.cs
   |-Pluto.Rover.Tests
   |   |
       |-Models
       |   |-PositionTests.cs
       |-Planet
       |   |-PlutoTests.cs
       |-Rover
       |   |-RoverTests.cs
           |-RoverDriverTests.cs
             
```

## Future improvements

 1. Change the position models into structs (value types), this will allow simple storing and checking for the values in the HashSet structure of the Planet, it will remove the necessity of converting them to string when storing or accessing them. They will also need to be organized in more composite way. Meaning, **DirectionalPosition** should contain instance of **Position** instead of inheriting from it.
 2. Introduce **undo** operations that will be able to revert the movements of the Rover. This might not be necessary but it is a nice addition and it will complete the paradigm of the Command design pattern.

## Run the solution
Since there is no startup or main program to run the solution, the unit tests can be used to run and verify the logic and the execution.

#### Prerequisite:
In order to run the tests .NET 5 runtime and SDK are needed. You can check whether you have .NET 5 installed by running the following command in the terminal **dotnet --version**. If the version is not **5.X.X** download and install the runtime and the SDK from the following link: https://dotnet.microsoft.com/download.

#### Steps to run the tests
1. Download the [repo](https://github.com/DNakevski/PlutoRover).
2. Enter the **Pluto.Rover.Tests** folder in terminal and run the **dotnet test** command.
