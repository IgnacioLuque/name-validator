using NameValidatorApp;

var name = args[0];

var nameValidator = new NameValidator();

var isValidName = nameValidator.IsValidName(name);

Console.WriteLine($"{(isValidName ? "The name given is valid" : "The name given is invalid")}");