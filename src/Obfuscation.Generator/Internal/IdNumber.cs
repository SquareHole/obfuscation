namespace Obfuscation.Generator.Internal;

internal sealed class IdNumber
{
    public DateTime DateOfBirth { get; set; }
    public string MaleIdNumber { get; set; } = "";
    public string FemaleIdNumber { get; set; } = "";

    public override string ToString()
    {
        return
            $"INSERT INTO [FakeLegalReferencenumber] ([DateOfBirth],[Gender],[LegalReferenceNumber],[Used]) VALUES ('{DateOfBirth:yyyy-MM-dd}','Male','{MaleIdNumber}',0); " +
            $"INSERT INTO [FakeLegalReferencenumber] ([DateOfBirth],[Gender],[LegalReferenceNumber],[Used]) VALUES ('{DateOfBirth:yyyy-MM-dd}','Female','{FemaleIdNumber}',0);";
        //return $"{DateOfBirth:yyyy-MM-dd}|{MaleIdNumber}|{FemaleIdNumber}";
    }
}