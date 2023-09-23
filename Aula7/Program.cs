using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;
using Aula7.Model;
using Aula7.Mapping;

//LerCsv();
//LerCsvClass();
//LerCsvComPontoVirgula();
EscreverCsv();
Console.WriteLine("\n\n Pressione [enter] para finalizar");
Console.ReadLine();

static void EscreverCsv()
{
    var path = Path.Combine(Environment.CurrentDirectory, "Saida");

    var directoryInfo = new DirectoryInfo(path);

    if(!directoryInfo.Exists) directoryInfo.Create();

    path = Path.Combine(path, "usuarios.csv");

     var pessoas = new List<Pessoa>(){
        new Pessoa()
        {
            Nome = "José da Silva",
            Email = "jose.silva@gmail.com",
            Telefone = 2123131,
        },
        new Pessoa()
        {
            Nome = "Mané da Silva",
            Email = "mane.silva@gmail.com",
            Telefone = 2123131,
        },
    };

    using var streamWriter = new StreamWriter(path);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        Delimiter = "|"
    };
    using var csvWriter = new CsvWriter(streamWriter, csvConfig);
    csvWriter.WriteRecords(pessoas);

}

static void LerCsvComPontoVirgula()
{
    var path = Path.Combine(Environment.CurrentDirectory, "Entrada", "livros.csv");

    var fileInfo = new FileInfo(path);

    if(!fileInfo.Exists)
        throw new FileNotFoundException($"O arquivo {path} não existe");

    using var streamReader = new StreamReader(fileInfo.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        Delimiter = ";"
    };

    using var csvReader = new CsvReader(streamReader, csvConfig);
    csvReader.Context.RegisterClassMap<LivroMap>();

    var registros = csvReader.GetRecords<Livro>();

    foreach (var registro in registros)
    {
        Console.WriteLine($"nome: {registro.Titulo}");
        Console.WriteLine($"marca: {registro.Preco}");
        Console.WriteLine($"preço: {registro.Autor}");
        Console.WriteLine($"Lançamento: {registro.Lancamento}");
        Console.WriteLine("-----------------");
    }
}

static void LerCsvClass()
{
    var path = Path.Combine(Environment.CurrentDirectory, "Entrada", "produto.csv");

    var fileInfo = new FileInfo(path);

    if(!fileInfo.Exists)
        throw new FileNotFoundException($"O arquivo {path} não existe");

    using var streamReader = new StreamReader(fileInfo.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
    using var csvReader = new CsvReader(streamReader, csvConfig);

    var registros = csvReader.GetRecords<Produto>();

    foreach (var registro in registros)
    {
        Console.WriteLine($"nome: {registro.NomeProduto}");
        Console.WriteLine($"marca: {registro.Marca}");
        Console.WriteLine($"preço: {registro.Preco}");
        Console.WriteLine("-----------------");
    }
}

static void LerCsv()
{
    var path = Path.Combine(Environment.CurrentDirectory, "Entrada", "produto.csv");

    var fileInfo = new FileInfo(path);

    if(!fileInfo.Exists)
        throw new FileNotFoundException($"O arquivo {path} não existe");

    using var streamReader = new StreamReader(fileInfo.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
    using var csvReader = new CsvReader(streamReader, csvConfig);

    var registros = csvReader.GetRecords<dynamic>();

    foreach (var registro in registros)
    {
        Console.WriteLine($"nome: {registro.NomeProduto}");
        Console.WriteLine($"marca: {registro.Marca}");
        Console.WriteLine($"preço: {registro.Preco}");
        Console.WriteLine("-----------------");
    }
}


