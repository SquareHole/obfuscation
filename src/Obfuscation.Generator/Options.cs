namespace Obfuscation.Generator;

using CommandLine;

public class Options
{
    [Option('c', "count",
        Required = true,
        HelpText =
            "Number of objects to generate. For ID Number generator the max will be capped to 10"),]
    public int Count { get; set; }
    
    [Option('o', "operation",
        Required = true,
        HelpText = "Operation to perform. choices: Id, Person ")]
    public Operation Operation { get; set; }
    
    [Option('f', "file",
        Required = false,
        HelpText = "File name to write to. If not specified, will write to console.")]
    public string FileName { get; set; } = "";
}