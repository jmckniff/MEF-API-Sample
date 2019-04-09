# MEF-API-Sample

This is a sample ASP.NET Web API application which discovers assemblies containing API controllers at runtime,
using MEF from the API's bin folder.

## Setup
1. Open and build the Visual Studio solution.
2. Create a folder named "Modules" in the API project's "bin" folder.
3. Copy the contents of the "ModuleA" projects bin folder in a new folder inside the "API\bin\Modules" folder named "ModuleA"
4. Copy the contents of the "ModuleB" projects bin folder in a new folder inside the "API\bin\Modules" folder named "ModuleB"
5. Debug the API project.
6. From the browser hit the "test1/doSomething" endpoint on the website.
7. From the browser hit the "test2/doSomething" endpoint on the website.
