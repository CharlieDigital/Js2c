using Js2c.Generator;

namespace Js2c.Tests;

public class TestBasicModels {
  [Fact]
  public void Can_Use_Simple_Models() {
    var sandra = new Person {
      FirstName = "Sandra",
      LastName = "Smith"
    };

    Assert.Equal("Sandra", sandra.FirstName);
    Assert.Equal("Smith", sandra.LastName);
  }

  [Fact]
  public void Can_Parse_Simple_Models() {
    var adam = Person.Parse("{ \"firstName\": \"Adam\", \"lastName\": \"Ng\" }");

    Assert.NotNull(adam);
    Assert.Equal("Adam", adam.FirstName);
    Assert.Equal("Ng", adam.LastName);
  }
}

  /// <summary>
  /// This partial class exposes a constant JSON expression which is used to generate
  /// the class.
  /// </summary>
  [JsonSource(Json)]
  public partial class Person {

    /// <summary>
    /// This is a reference JSON string that we'll use to create the class.
    /// </summary>
    internal const string Json = @"{
      ""firstName"" : ""Charles"",
      ""lastName"" : ""Chen""
    }";
  }