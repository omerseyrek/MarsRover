





#initial commands
https://dotnet.microsoft.com/download/dotnet-core/3.1

dotnet new sln MarsRover
dotnet new classlib -o MarsRoverLib
dotnet new console -n MarsRover
dotnet new xunit -o MarsRover.Tests

dotnet sln add ./MarsRoverLib/MarsRoverLib.csproj
dotnet sln add ./MarsRover/MarsRover.csproj
dotnet sln add ./MarsRover.Tests/MarsRover.Tests.csproj

dotnet add  ./MarsRover/MarsRover.csproj reference ./MarsRoverLib/MarsRoverLib.csproj
dotnet add  ./MarsRover.Tests/MarsRover.Tests.csproj reference ./MarsRoverLib/MarsRoverLib.csproj


