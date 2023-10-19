namespace Obfuscation.Generator.Internal;

internal interface IGenerator<out T>
{
    IEnumerable<T> Run(int count = 1);
}

