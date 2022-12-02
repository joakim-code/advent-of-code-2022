# advent-of-code-2022


¨¨¨
dotnet new sln --name AdventOfCode
mkdir src
mkdir tests
cd src
dotnet new consoledo -n DayXX
cd ..
cd tests
dotnet new xunit -n DayXX.Tests
cd ..
dotnet sln add src/DayXX
dotnet sln add tests/DayXX.Tests

dotnet new gitignore


¨¨¨