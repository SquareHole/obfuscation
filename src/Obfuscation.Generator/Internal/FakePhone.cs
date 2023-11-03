namespace Obfuscation.Generator.Internal;

/// <summary>
/// Fake phone
/// </summary>
public class FakePhone
{
    /// <summary>
    /// Phone kind
    /// </summary>
    public PhoneKind PhoneKind { get; set; }
    
    /// <summary>
    /// Area code
    /// </summary>
    public string AreaCode { get; set; } = "";
    
    /// <summary>
    ///  Number
    /// </summary>
    public string Number { get; set; } = "";

    /// <summary>
    /// A string representation of the object
    /// </summary>
    /// <returns>
    /// A string representation of the object
    /// </returns>
    public override string ToString()
    {
        return $"{PhoneKind.ToString()}|{AreaCode}-{Number}";
    }
}

/// <summary>
/// Phone kind
/// </summary>
public enum PhoneKind
{
    /// <summary>
    /// Mobile
    /// </summary>
    Mobile,
    /// <summary>
    /// Home
    /// </summary>
    Home,
    /// <summary>
    /// Work
    /// </summary>
    Work
}