using Bogus;

namespace Obfuscation.Generator.Internal;

/// <summary>
/// Fake phone generator
/// </summary>
internal sealed class FakePhoneGenerator : IGenerator<FakePhone>
{
    public IEnumerable<FakePhone> Run(int count = 1)
    {
        Faker<FakePhone>? faker = new Faker<FakePhone>()
            .RuleFor(u => u.PhoneKind, f => f.PickRandom<PhoneKind>())
            .RuleFor(u => u.AreaCode, (f, u) =>
            {
                return u.PhoneKind switch
                {
                    PhoneKind.Mobile => f.Phone.PhoneNumber("08#"),
                    PhoneKind.Home => f.Phone.PhoneNumber("01#"),
                    _ => f.Phone.PhoneNumber("02#")
                };
            })
            .RuleFor(u => u.Number, f => f.Phone.PhoneNumber("###-####"));

        for (int i = 0; i < count; i++)
            yield return faker.Generate();
    }
}