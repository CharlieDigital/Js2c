# JSON to Class (js2c)

JSON to class (*js2c*) is a small library using .NET Source Generators to automatically create classes based on snippets of JSON.

This project was inspired by parsing JSON+LD from various websites which all use slightly different formats and different structures.

However, it can be used with any JSON snippet.

To use:

```
dotnet add package js2c.generator
```

## Motivation

If you have a snippet of JSON and you'd like to quickly create a strongly typed class from it, js2c let's you do that quickly by simply decorating your class with an attribute:

```cs
// 1️⃣ A partial class that is otherwise empty
[JsonSource(PersonJson)]
public partial class Person {
  // A JSON snippet which defines a "template"
  internal const string PersonJson = @"{
    ""firstName"" : """",
    ""lastName"" : """",
    ""age"": 0
  }";
}

// 2️⃣ The generated class:
public partial class Person {
  public static Person? Parse(string json) {
    return JsonSerializer.Deserialize<Person>(json);
  }
  [JsonPropertyName("firstName")] public string FirstName { get; set;} = "";
  [JsonPropertyName("lastName")] public string LastName { get; set;} = "";
  [JsonPropertyName("age")] public decimal Age { get; set; }
}

// 3️⃣ Which you can use like this
var person = new Person {
  FirstName = "Stanley",
  LastName = "Banks",
  Age = 30m
}

// Or like this:
var adam = Person.Parse("{ \"firstName\": \"Adam\", \"lastName\": \"Ng\" }");
```

js2c simplifies defining classes from JSON by allowing you to simply paste a template into your source.

## Basic Types

- JSON Strings are mapped to `string`
- JSON Booleans are mapped to `bool`
- JSON Numbers are mapped to `decimal`
- JSON Arrays are mapped to `Array<T>`
- JSON Objects are mapped to `class`

## Complex Types

js2c handles complex types like arrays and objects (with limitations for now; feel free to contribute!):

### Arrays

Here is an example of using it with arrays of values:

```cs
// JSON with string array
internal const string PersonJson = @"{
  ""firstName"" : """",
  ""lastName"" : """",
  ""emails"": ["""", """"]
}";

// Partial class
[JsonSource(PersonJson)]
public partial class Person {

}

// Used like this:
var randy = new Person3 {
  FirstName = "Randy",
  LastName = "Lee",
  Emails = new [] {
    "randy@example.com",
    "randy.lee@example.com "
  }
};
```

### Objects

js2c handles nested objects and will generate classes using a special attribute like `@type`:

```cs
// JSON template
internal const string PersonJson = @"{
  ""firstName"" : """",
  ""lastName"" : """",
  ""emails"": ["""", """"],
  ""address"": {
    ""@type"": ""Address"",
    ""street"": """",
    ""city"": """",
    ""state"": """"
  }
}";

// Partial class
[JsonSource(PersonJson)]
public partial class Person {

}

// Generated class can use arrays and objects.
var patty = new Person {
  FirstName = "Patty",
  LastName = "Lundgren",
  Emails = new [] { "patty@example.com", "patty.Lundgren@example.com "},
  Address = new()  {
    Street = "123 Acme Ln",
    City = "New York City",
    State = "NY"
  }
};
```

## Development

### Unit Tests

The best way to work with this is to build unit tests for your use cases as you go along.

From the command line:

```shell
cd tests
dotnet test
```

### A Note on Caching

You may run into issues with caching while developing your own generators.  To work around this, you can use the `build-server shutdown` command to effectively restart the build server:

```shell
cd tests

# Reset the build server to clear cache.
dotnet build-server shutdown
dotnet run

# Or combine:
dotnet build-server shutdown && dotnet run
```