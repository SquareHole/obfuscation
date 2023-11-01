namespace Obfuscation.Generator.Internal;

using Bogus;
using Bogus.DataSets;

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
            .RuleFor(u => u.FakeId, (f, u) => f.IndexFaker);

        for (int i = 0; i < count; i++)
            yield return faker.Generate();
    }
}

internal sealed class FakePhoneGenerator : IGenerator<FakePhone>
{
    public IEnumerable<FakePhone> Run(int count = 1)
    {
        Faker<FakePhone>? faker = new Faker<FakePhone>()
            .RuleFor(u => u.PhoneKind, f => f.PickRandom<PhoneKind>())
            .RuleFor(u => u.AreaCode, f => f.Phone.PhoneNumber("0##"))
            .RuleFor(u => u.Number, f => f.Phone.PhoneNumber("###-####"));

        for (int i = 0; i < count; i++)
            yield return faker.Generate();
    }
}