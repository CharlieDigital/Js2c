using Js2c.Generator;

namespace Js2c.Tests;

public class TestNestedObject {
  /// <summary>
  /// This is a reference JSON string that we'll use to create the class.
  /// </summary>
  internal const string Person4Json = @"{
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

  [Fact]
  public void Can_Use_Model_With_Nested_Object() {
    var patty = new Person4 {
      FirstName = "Patty",
      LastName = "Lundgren",
      Emails = new [] { "patty@example.com", "patty.Lundgren@example.com "},
      Address = new()  {
        Street = "123 Acme Ln",
        City = "New York City",
        State = "NY"
      }
    };

    Assert.Equal("Patty", patty.FirstName);
    Assert.Equal("Lundgren", patty.LastName);
    Assert.NotEmpty(patty.Emails);
    Assert.Equal(2, patty.Emails.Length);
  }
}

/// <summary>
/// This class pulls it from a `const` somewhere else.
/// </summary>
[JsonSource(TestNestedObject.Person4Json)]
public partial class Person4 {

}