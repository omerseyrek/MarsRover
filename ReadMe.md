# initialization

Make sure instelled .net core 3.1
https://dotnet.microsoft.com/download/dotnet-core/3.1

dotnet new sln MarsRover
dotnet new classlib -o MarsRoverLib
dotnet new classlib -o MarsRoverControllerLib
dotnet new console -n MarsRover
dotnet new xunit -o MarsRover.Tests

dotnet sln add ./MarsRoverLib/MarsRoverLib.csproj
dotnet sln add MarsRoverControllerLib\MarsRoverControllerLib.csproj
dotnet sln add ./MarsRover/MarsRover.csproj
dotnet sln add ./MarsRover.Tests/MarsRover.Tests.csproj

dotnet add ./MarsRoverControllerLib/MarsRoverControllerLib.csproj reference ./MarsRoverLib/MarsRoverLib.csproj
dotnet add ./MarsRover/MarsRover.csproj reference ./MarsRoverLib/MarsRoverLib.csproj
dotnet add ./MarsRover/MarsRover.csproj reference ./MarsRoverControllerLib/MarsRoverControllerLib.csproj
dotnet add ./MarsRover.Tests/MarsRover.Tests.csproj reference ./MarsRoverLib/MarsRoverLib.csproj
dotnet add ./MarsRover.Tests/MarsRover.Tests.csproj reference ./MarsRoverControllerLib/MarsRoverControllerLib.csproj

# desctiption

A squad of robotic rovers are to be landed by NASA on a plateau on Mars. This plateau, which is curiously rectangular, must be navigated by the rovers so that their on board cameras can get a complete view of the surrounding terrain to send back to Earth.

A rover's position and location is represented by a combination of x and y co-ordinates and a letter representing one of the four cardinal compass points. The plateau is divided up into a grid to simplify navigation. An example position might be 0, 0, N, which means the rover is in the bottom left corner and facing North.

In order to control a rover, NASA sends a simple string of letters. The possible letters are 'L', 'R' and 'M'. 'L' and 'R' makes the rover spin 90 degrees left or right respectively, without moving from its current spot. 'M' means move forward one grid point, and maintain the same heading.
Assume that the square directly North from (x, y) is (x, y+1).

# acceptence creiterias

Input and Output
Test Input:
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM

Expected Output:
1 3 N
5 1 E

# Conributiron
I marked up some points with "//todo", that parts needs to be improved, 

# Archeitectural Decisions

chain of responsibility pattern implemented in order to excute L R and M comman arrays, any new type of command should implement IMarsRoverCommandHandler interface and should be linked to the chain of responsibility


# Question Marks
does the rovers accepted to exceed the plateu co-ordinate limits, i designed as it should be limited but, the rule should be discussed.



