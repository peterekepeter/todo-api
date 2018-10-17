
# todo-api

A simple todo API for testing purposes.

# Run using Visual Studio 2017

You can download and install the Visual Studio 2007 Community edition for free.
Visual Studio might have outdated .NET Core SDK, you might also need to install a newer one.
After installing do the following:

 1. In team explorer clone this repository
 2. Open the solution file *.sln
 3. Click run!
   - it should build and restore nugets automatically
   - after done it should launch http://localhost:54394/index.html in browser
   
Note: port may vary!

# Run using dotnet core

Recommended editor is VS Code!
This should work on Linux and Mac too!
Install at least dotnet core 2.1.403 sdk and git!

 1. Git clone the repository
 2. Navigate to the project (where the *.csproj file is)
 3. Type dotnet restore to install nugets
 4. Type dotnet run to run the application 
 5. You need to navigate manually to http://localhost:54394/index.html
 

