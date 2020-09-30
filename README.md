# Message board

Sample Message board API, allows retrieving messages, posting message, deleting messages etc

Implemented in vscode


## To run
----------------------------------
Install VS Code (https://code.visualstudio.com/download)
Install VS Code C# (https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
Install C#.NET CORE (https://dotnet.microsoft.com/download/dotnet-core/3.1)

Open folder in vscode
Hit Ctrl-F5 to run the application


## Viewing messages
----------------------------------
Navigate a web browser to https://localhost:5001/api/Messages


## Posting messages
----------------------------------
POST a message in JSON format to https://localhost:5001/api/Messages (e.g. useing postman)
Message format:
```javascript
{
    "Title": "My first message",
    "Message": "Hello world"
}
```

## ToDo
----------------------------------
* Currently uses an in-memory database, implement SQL or NoSQL database for persistent storage, e.g. SQLite, SQL Server, MongoDB etc
* Implement user authentication
* Implement message replies


