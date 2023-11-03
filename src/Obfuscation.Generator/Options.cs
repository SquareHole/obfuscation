namespace Obfuscation.Generator;

using CommandLine;

/// <summary>
/// Options
/// </summary>
public class Options
{
    /// <summary>
    /// Number of objects to generate. For ID Number generator the max will be capped to 100
    /// </summary>
    [Option('c', "count",
        Required = true,
        HelpText =
            "Number of objects to generate. For ID Number generator the max will be capped to 100"),]
    public int Count { get; set; }
    
    /// <summary>
    /// Kind of operation to perform
    /// </summary>
    [Option('o', "operation",
        Required = true,
        HelpText = "Operation to perform. choices: Id, Person, Phone ")]
    public Operation Operation { get; set; }

    /// <summary>
    /// Name of the file to write to. If not specified, will write to console.
    /// </summary>
    [Option('f', "file",
        Required = false,
        HelpText = "File name to write to. If not specified, will write to console.")]
    public string FileName { get; set; } = "";
}