using CommandLine;
using Obfuscation.Generator;
using Obfuscation.Generator.Internal;

await Parser.Default
    .ParseArguments<Options>(args)
    .WithParsedAsync(Runner.OptionsRunner);
    