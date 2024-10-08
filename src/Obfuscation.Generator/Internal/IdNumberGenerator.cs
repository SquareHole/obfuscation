﻿namespace Obfuscation.Generator.Internal;

using Bogus.DataSets;

internal sealed class IdNumberGenerator : IGenerator<IdNumber>
{
    public IEnumerable<IdNumber> Run( int count = 1)
    {
        DateTime startDate = new(2023, 11, 11);
        DateTime endDate = startDate.AddYears(3);
        SouthAfricanIdGenerator southAfricanIdGenerator = new();
        DateTime currentDate = startDate;

        while (currentDate < endDate)
        {
            for (int i = 0; i < Math.Min(count, 100); i++)
            {
                yield return new()
                {
                    DateOfBirth = currentDate,
                    MaleIdNumber = SouthAfricanIdGenerator.GenerateId(currentDate, Name.Gender.Male),
                    FemaleIdNumber = SouthAfricanIdGenerator.GenerateId(currentDate, Name.Gender.Female),
                };
            }

            currentDate = currentDate.AddDays(1);
        }
    }
}


