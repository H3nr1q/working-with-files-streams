using System.Text;

static void ExemploStringBuilder()
{
    var stringBuilder = new StringBuilder();
    stringBuilder.AppendLine("Linha 1 testando buffer");
    stringBuilder.AppendLine("Linha 2");
    stringBuilder.AppendLine("Linha 3");
    stringBuilder.AppendLine("Linha 4");

    using var stringReader = new StringReader(stringBuilder.ToString());
    var buffer = new char[10];
    var tamanho = 0;
    do
    {
        // tamanho = stringReader.Read(buffer);
        // Console.Write(string.Join("", buffer));
        Console.WriteLine(stringReader.ReadLine());

    // } while (tamanho >= buffer.Length);
    }while(stringReader.Peek() >= 0);

    // Console.WriteLine("Digite [enter] para finalizar");
    // Console.ReadKey();
}

string textReaderText = "Voce também pode usar uma instancia de textreader para ler.\n\n" +
                        "texto de um armazenamento de suporte personalizado usando as mesmas.\n\n" +
                        "APIs que você usaria para uma string ou um fluxo.\n\n" ;

Console.WriteLine($"Texto original : {textReaderText}");
string linha, paragrafo = null;

var stringReader = new StringReader(textReaderText);

while (true)
{
    linha = stringReader.ReadLine();
    if(linha  != null)
    {
        paragrafo += linha + " ";
    }
    else
    {
        paragrafo += "\n";
        break;
    }
}

Console.WriteLine($"Texto modificado : {paragrafo}");
int caratereLido;
char caracterConvertido;

var stringWriter = new StringWriter();
stringReader = new StringReader(paragrafo);

while(true)
{
    caratereLido = stringReader.Read();
    if(caratereLido == -1) break;

    caracterConvertido = Convert.ToChar(caratereLido);

    if(caratereLido == '.')
    {
        stringWriter.Write("\n\n");

        stringReader.Read();
        stringReader.Read();
    }
    else
    {
        stringWriter.Write(caracterConvertido);
    }

}

Console.WriteLine($"Texto armazenado no StringWriter: {stringWriter.ToString()}");

