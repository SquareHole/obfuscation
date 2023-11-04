namespace Obfuscation.Generator;

/// <summary>
/// Kind of operation to perform
/// </summary>
public enum Operation
{
    /// <summary>
    /// Identity number operation flags the application to generate South-African identity numbers.
    /// </summary>
    Id,
    
    /// <summary>
    /// Person information flags the application to generate name, middle name and surname combinations.
    /// </summary>
    Person,
    
    /// <summary>
    /// Phone number flags the application to generate South-African phone numbers.
    /// </summary>
    Phone
}