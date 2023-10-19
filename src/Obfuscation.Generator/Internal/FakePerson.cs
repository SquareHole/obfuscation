namespace Obfuscation.Generator.Internal;

using System.Text.Json.Serialization;
using Bogus.DataSets;

internal sealed class FakePerson
{
    public int FakeId { get; set; }
    public string FirstName { get; set; } = "";
    public string MiddleName { get; set; } = "";
    public string LastName { get; set; } = "";
    public Name.Gender Gender { get; set; }
    public string EmailAddress { get; set; } = "";

    private string DisplayName => $"{FirstName} {LastName}";

    public override string ToString()
    {
        return $"{FakeId}|{FirstName}|{MiddleName}|{LastName}|{Gender}|{EmailAddress}|{DisplayName}";
    }
}
