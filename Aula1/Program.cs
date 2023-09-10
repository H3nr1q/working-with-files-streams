using System.Diagnostics.CodeAnalysis;
using System.IO;

Console.WriteLine("Digite o nome do arquivo");
var nomeArquivo = Console.ReadLine();
nomeArquivo = LimparNome(nomeArquivo);
var path = Path.Combine(Environment.CurrentDirectory,$"{nomeArquivo}.txt");
CriarArquivo(path);

Console.WriteLine("Digite <ENTER> para finalizar...");
Console.ReadLine();

static void CriarArquivo(string path)
{
    try
    {
        using var streamWriter = File.CreateText(path);
        streamWriter.WriteLine("Linha 1");
        streamWriter.WriteLine("Linha 2");
        streamWriter.WriteLine("Linha 3");
        streamWriter.WriteLine("Linha 4");
        //streamWriter.Flush();
    }
    catch
    {
        Console.WriteLine("Nome do arquivo inválido!");
    }
}

static string LimparNome(string nomeArquivo)
{
    foreach (var @char in Path.GetInvalidFileNameChars())
    {
        nomeArquivo = nomeArquivo.Replace(@char, '-');
    }

    return nomeArquivo;
}