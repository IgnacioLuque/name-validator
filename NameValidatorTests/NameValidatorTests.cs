using NameValidatorApp;

namespace NameValidatorTests;

[TestClass]
public class NameValidatorTests
{
    NameValidator nameValidator;

    [TestInitialize]
    public void Setup()
    {
        nameValidator = new NameValidator();
    }

    [TestMethod]
    [DataRow("E. Poe")]
    [DataRow("E. A. Poe")]
    [DataRow("Edgard A. Poe")]
    [DataRow("Edgard Allan Poe")]
    public void Identifies_valid_names(string name)
    {
        var isValidName = nameValidator.IsValidName(name);

        Assert.IsTrue(isValidName);
    }

    [TestMethod]
    [DataRow("Edgard")]
    [DataRow("e. Poe")]
    [DataRow("E Poe")]
    [DataRow("E. poe")]
    [DataRow("e. a. Poe")]
    [DataRow("E. A Poe")]
    [DataRow("E. Allan Poe")]
    [DataRow("Edg. Allan Poe")]
    [DataRow("Edg. A. Poe")]
    [DataRow("E. A. P.")]
    public void Identifies_invalid_names(string name)
    {
        var isValidName = nameValidator.IsValidName(name);

        Assert.IsFalse(isValidName);
    }
}
