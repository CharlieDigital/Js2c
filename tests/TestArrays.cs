using Js2c.Generator;

namespace Js2c.Tests;

public class TestArrays {
  /// <summary>
  /// This is a reference JSON string that we'll use to create the class.
  /// </summary>
  internal const string Person3Json = @"{
    ""firstName"" : """",
    ""lastName"" : """",
    ""emails"": ["""", """"]
  }";

  [Fact]
  public void Can_Use_Model_With_Simple_Array() {
    var randy = new Person3 {
      FirstName = "Randy",
      LastName = "Lee",
      Emails = new [] { "randy@example.com", "randy.lee@example.com "}
    };

    Assert.Equal("Randy", randy.FirstName);
    Assert.Equal("Lee", randy.LastName);
    Assert.NotEmpty(randy.Emails);
    Assert.Equal(2, randy.Emails.Length);
  }
}

/// <summary>
/// This class pulls it from a `const` somewhere else.
/// </summary>
[JsonSource(TestArrays.Person3Json)]
public partial class Person3 {

}