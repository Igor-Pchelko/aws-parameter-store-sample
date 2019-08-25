This project demonstrates integration .Net Core application with AWS Parameter store. 

# Run project:
To run the project locally use:
dotnet run --project webapi

DatabaseSettings API is accessible via the following URL:
https://localhost:5001/databasesettings

# Scripts
In the scripts folder, there are two samples of how to write and read parameters to/from AWS. 
Those scripts were written for OSX. And use the following dependencies:
- [Chamber](https://github.com/segmentio/chamber)
- [jq](https://stedolan.github.io/jq/download/)

Use brew to install dependencies:
```bash
brew install chamber
brew install jq
```
