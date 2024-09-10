using System.Runtime.CompilerServices;
using CommandLine;
using Obfuscation.Generator;
using Obfuscation.Generator.Internal;

CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

Console.CancelKeyPress += (_, eventArgs) =>
{
    Console.WriteLine("***** CANCELLED *******");
    eventArgs.Cancel = true;
    cancellationTokenSource.Cancel();
};

await Parser.Default
    .ParseArguments<Options>(args)
    .WithParsedAsync(new Runner(cancellationTokenSource.Token).OptionsRunner);
    