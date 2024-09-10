namespace Obfuscation.Generator.Internal;

internal sealed class Runner
{
    private readonly CancellationToken _cancellationToken;

    public Runner(CancellationToken cancellationToken)
    {
        _cancellationToken = cancellationToken;
    }
    public  async Task OptionsRunner(Options options)
    {
        
        Console.WriteLine($"Count: {options.Count}");
        Console.WriteLine($"Operation: {options.Operation}");

        try
        {
            switch (options.Operation)
            {
                case Operation.Id:
                    await IdNumberRunner(options, _cancellationToken);
                    break;
                case Operation.Person:
                    await FakeNameRunner(options, _cancellationToken);
                    break;
                case Operation.Phone:
                    await FakePhoneRunner(options, _cancellationToken);
                    break;
                default:
                    throw new ArgumentNullException(nameof(options));
            }
        }
        catch (OperationCanceledException e)
        {
            Console.Write("*** Operation cancelled ****");
        }
    }

    private static async Task FakeNameRunner(Options options, CancellationToken cancellationToken)
    {
        FakeNameGenerator fakeNameGenerator = new();
        if (!string.IsNullOrEmpty(options.FileName))
        {
            await File.WriteAllLinesAsync(options.FileName, fakeNameGenerator.Run(options.Count).Select(x => x.ToString()), cancellationToken);
        }
        else
        {
            foreach (FakePerson fakePerson in fakeNameGenerator.Run(options.Count))
            {
                cancellationToken.ThrowIfCancellationRequested();
                Console.WriteLine(fakePerson);
            }
        }
    }
    private static async Task FakePhoneRunner(Options options, CancellationToken cancellationToken)
    {
        FakePhoneGenerator fakePhoneGenerator = new();
        if (!string.IsNullOrEmpty(options.FileName))
        {
            await File.WriteAllLinesAsync(options.FileName, fakePhoneGenerator.Run(options.Count).Select(x => x.ToString()), cancellationToken);
        }
        else
        {
            foreach (FakePhone fakePhone in fakePhoneGenerator.Run(options.Count))
            {
                cancellationToken.ThrowIfCancellationRequested();
                Console.WriteLine(fakePhone);
            }
        }
    }

    private static async Task IdNumberRunner(Options options, CancellationToken cancellationToken)
    {
        IdNumberGenerator idNumberGenerator = new();
        if (!string.IsNullOrEmpty(options.FileName))
        {
            await File.WriteAllLinesAsync(options.FileName, idNumberGenerator.Run(options.Count).Select(x => x.ToString()), cancellationToken);
        }
        else
        {
            foreach (IdNumber idNumber in idNumberGenerator.Run(options.Count))
            {
                cancellationToken.ThrowIfCancellationRequested();
                Console.WriteLine(idNumber);
            }
        }
    }
}