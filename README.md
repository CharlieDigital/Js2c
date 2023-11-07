# JSON to Class

JSON to class (*js2c*) is a small library using .NET Source Generators to automatically create classes based on snippets of JSON.

This project was inspired by parsing JSON+LD from various websites which all use slightly different formats and different structures.

However, it can be used with any JSON snippet.

## A Note on Caching

You may run into issues with caching while developing your own generators.  To work around this, you can use the `build-server shutdown` command to effectively restart the build server:

```shell
cd runtime

# Reset the build server to clear cache.
dotnet build-server shutdown
dotnet run

# Or combine:
dotnet build-server shutdown && dotnet run
```