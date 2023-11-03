using System.Globalization;

namespace Obfuscation.Generator.Internal;

using Bogus.DataSets;

internal sealed class SouthAfricanIdGenerator
{
    
    public static string GenerateId(DateTime dateOfBirth, Name.Gender gender)
    {

        // Parse date of birth
        string yymmdd = dateOfBirth.ToString("yyMMdd", CultureInfo.InvariantCulture);

        // Determine gender SSSS
        int ssss = gender switch
        {
            Name.Gender.Female => new Random().Next(0, 5000),
            Name.Gender.Male => new Random().Next(5000, 10000),
            _ => throw new ArgumentException("Invalid gender. Use 'male' or 'female'.")
        };

        // Fixed values
        const int a = 8; // Citizenship status
        const int c = 0;
        int z = CalculateChecksum(yymmdd, ssss, c, a);

        // Construct the ID number
        return $"{yymmdd}{ssss:D4}{c}{a}{z}";
    }

    static int CalculateChecksum(string yymmdd, int ssss,int c, int a)
    {
        string idWithoutChecksum = $"{yymmdd}{ssss:D4}{c}{a}";


        int sum = 0;
        bool shouldApplyDouble = true;
        for (int index = idWithoutChecksum.Length - 1; index >= 0; index--)
        {
            int currentDigit = (Int32)Char.GetNumericValue(idWithoutChecksum, index);

            if (shouldApplyDouble)
            {
                if (currentDigit > 4)
                {
                    sum += currentDigit * 2 - 9;
                }
                else
                {
                    sum += currentDigit * 2;
                }
            }
            else
            {
                sum += currentDigit;
            }
            shouldApplyDouble = !shouldApplyDouble;
        }
        int checkDigit = (10 - (sum % 10)) % 10;

        return checkDigit;
    }
}