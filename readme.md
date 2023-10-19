# Obfuscation Generator

Generate fake person data to be used in database obfuscation. 

## Supported Operations

### Id

Generate a South African ID number for the provided date of birth and gender.

```csharp
    public DateTime DateOfBirth { get; set; }
    public string MaleIdNumber { get; set; } = "";
    public string FemaleIdNumber { get; set; } = "";
```

### Person

Generate a fake person with the following properties:

```csharp
    public int FakeId { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public Name.Gender Gender { get; set; }
    public string EmailAddress { get; set; }
    
    public string DisplayName => $"{FirstName} {LastName}";
```

## Usage

Below is the output from the --help flag for the command line tool.
File is an optional parameter. If not specified, the output will be written to the console.

```bash
Obfuscation.Generator 1.0.0
Copyright (C) 2023 Obfuscation.Generator

  -c, --count        Required. Number of objects to generate. For ID Number generator the max will be capped to 10

  -o, --operation    Required. Operation to perform. choices: Id, Person

  -f, --file         File name to write to. If not specified, will write to console.

  --help             Display this help screen.

  --version          Display version information.
```

