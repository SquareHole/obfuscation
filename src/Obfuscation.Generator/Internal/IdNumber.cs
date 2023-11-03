namespace Obfuscation.Generator.Internal;

internal sealed class IdNumber
{
    public DateTime DateOfBirth { get; set; }
    public string MaleIdNumber { get; set; } = "";
    public string FemaleIdNumber { get; set; } = "";

    public override string ToString()
    {
        return $"{DateOfBirth:yyyy-MM-dd}|{MaleIdNumber}|{FemaleIdNumber}";
    }
}