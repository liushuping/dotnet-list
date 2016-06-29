# dotnet-list
List all dependencies in a .net core project.

## Installation
Edit `project.json` file, add `dotnet-list` in `tools` section:
```javascript
"tools": {
	"dotnet-list": {
	    "version": "*"
	}
}
 ```
 Then run `dotnet restore` to install it from nuget source.

## Run
Once succesfully installed, running below command will list all dependencies in the project.
```bash
dotnet list
```

## License
MIT
