namespace Obfuscation.Generator.Internal;

using Bogus;
using Bogus.DataSets;

/// <summary>
/// Fake name generator
/// </summary>
internal sealed class FakeNameGenerator : IGenerator<FakePerson>
{
    public IEnumerable<FakePerson> Run(int count = 1)
    {
        Faker<FakePerson>? faker = new Faker<FakePerson>()
            .RuleFor(u => u.Gender, f => f.PickRandom<Name.Gender>())
            .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName(u.Gender))
            .RuleFor(u => u.LastName, (f, u) => f.Name.LastName(u.Gender))
            .RuleFor(u => u.MiddleName, (f, u) => f.Name.FirstName(u.Gender))
            .RuleFor(u => u.EmailAddress,
                (f, u) => f.Internet.Email(u.FirstName, u.LastName, provider: "brightrockdev.co.za"))
            .RuleFor(u => u.FakeId, (f, _) => f.IndexFaker);

        for (int i = 0; i < count; i++)
            yield return faker.Generate();
    }
}