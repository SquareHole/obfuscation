namespace Obfuscation.Generator.Internal;

internal static class Runner
{
    public static Task OptionsRunner(Options options)
    {
        Console.WriteLine($"Count: {options.Count}");
        Console.WriteLine($"Operation: {options.Operation}");

        switch (options.Operation)
        {
            case Operation.Id:
                IdNumberRunner(options);
                break;
            case Operation.Person:
                FakeNameRunner(options);
                break;
            case Operation.Phone:
                FakePhoneRunner(options);
                break;
            default:
                return Task.FromException(new ArgumentNullException(nameof(options)));
        }

        return Task.CompletedTask;
    }

    private static void FakeNameRunner(Options options)
    {
        FakeNameGenerator fakeNameGenerator = new();
        if (!string.IsNullOrEmpty(options.FileName))
        {
            File.WriteAllLines(options.FileName, fakeNameGenerator.Run(options.Count).Select(x => x.ToString()));
        }
        else
        {
            foreach (FakePerson fakePerson in fakeNameGenerator.Run(options.Count))
            {
                Console.WriteLine(fakePerson);
            }
        }
    }
    private static void FakePhoneRunner(Options options)
    {
        FakePhoneGenerator fakePhoneGenerator = new();
        if (!string.IsNullOrEmpty(options.FileName))
        {
            File.WriteAllLines(options.FileName, fakePhoneGenerator.Run(options.Count).Select(x => x.ToString()));
        }
        else
        {
            foreach (FakePhone fakePhone in fakePhoneGenerator.Run(options.Count))
            {
                Console.WriteLine(fakePhone);
            }
        }
    }

    private static void IdNumberRunner(Options options)
    {
        IdNumberGenerator idNumberGenerator = new();
        if (!string.IsNullOrEmpty(options.FileName))
        {
            
            File.WriteAllLines(options.FileName, idNumberGenerator.Run(options.Count).Select(x => x.ToString()));
        }
        else
        {
            foreach (IdNumber idNumber in idNumberGenerator.Run(options.Count))
            {
                Console.WriteLine(idNumber);
            }
        }
    }
}