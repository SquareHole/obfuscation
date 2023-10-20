namespace Obfuscation.Generator.Internal;

using Bogus.DataSets;

internal sealed class IdNumberGenerator : IGenerator<IdNumber>
{
    public IEnumerable<IdNumber> Run( int count = 1)
    {
        DateTime startDate = new(1937, 1, 1);
        DateTime endDate = DateTime.Today.AddYears(-2);
        SouthAfricanIdGenerator southAfricanIdGenerator = new();
        DateTime currentDate = startDate;

        while (currentDate < endDate)
        {
            for (int i = 0; i < Math.Min(count, 100); i++)
            {
                yield return new()
                {
                    DateOfBirth = currentDate,
                    MaleIdNumber = southAfricanIdGenerator.GenerateId(currentDate, Name.Gender.Male),
                    FemaleIdNumber = southAfricanIdGenerator.GenerateId(currentDate, Name.Gender.Female),
                };
            }

            currentDate = currentDate.AddDays(1);
        }
    }
}