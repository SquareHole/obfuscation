namespace Obfuscation.Generator.Internal;

public class FakePhone
{
    public PhoneKind PhoneKind { get; set; }
    public string AreaCode { get; set; } = "";
    public string Number { get; set; } = "";

    public override string ToString()
    {
        return $"{PhoneKind.ToString()}|{AreaCode}-{Number}";
    }
}

public enum PhoneKind
{
    Mobile,
    Home,
    Work
}