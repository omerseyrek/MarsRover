#initial commands

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


#dependencies

MarsRover.Tests depends on Moq 4.15.1 nuget.s
dotnet add package Moq --version 4.15.1