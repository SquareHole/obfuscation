using CommandLine;
using Obfuscation.Generator;
using Obfuscation.Generator.Internal;



Parser.Default
    .ParseArguments<Options>(args)
    .WithParsed(Runner.OptionsRunner)
    .WithNotParsed(Handler.HandleParseError);