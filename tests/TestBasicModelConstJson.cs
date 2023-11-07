using Js2c.Generator;

namespace Js2c.Tests;

public class TestBasicModelsConstJson {
  /// <summary>
  /// This is a reference JSON string that we'll use to create the class.
  /// </summary>
  internal const string Person2Json = @"{
    ""firstName"" : """",
    ""lastName"" : """"
  }";

  [Fact]
  public void Can_Use_Model_From_Const() {
    var riju = new Person2 {
      FirstName = "Riju",
      LastName = "Patel"
    };

    Assert.Equal("Riju", riju.FirstName);
    Assert.Equal("Patel", riju.LastName);
  }
}

/// <summary>
/// This class pulls it from a `const` somewhere else.
/// </summary>
[JsonSource(TestBasicModelsConstJson.Person2Json)]
public partial class Person2 {

}