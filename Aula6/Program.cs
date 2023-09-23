CriarCsv();

Console.WriteLine("\n\n Pressione [enter] para finalizar");
Console.ReadLine();

static void CriarCsv()
{
    var path = Path.Combine(Environment.CurrentDirectory, "ArquivoSaida");

    var pessoas = new List<Pessoa>(){
        new Pessoa()
        {
            Nome = "José da Silva",
            Email = "jose.silva@gmail.com",
            Telefone = 2123131,
            Nascimento = new DateOnly(year: 1970, month: 2, day: 11)
        },
        new Pessoa()
        {
            Nome = "Mané da Silva",
            Email = "mane.silva@gmail.com",
            Telefone = 2123131,
            Nascimento = new DateOnly(year: 1970, month: 2, day: 11)
        },
    };

    var directoryInfo = new DirectoryInfo(path);
    if(!directoryInfo.Exists)
    {
        directoryInfo.Create();
        path = Path.Combine(path, "usuarios.csv");
    }
    using var streamWriter = new StreamWriter(path);
    streamWriter.WriteLine("nome, email, telefone, nascimento");
    foreach (var pessoa in pessoas)
    {
        var linha =$"{pessoa.Nome},{pessoa.Email},{pessoa.Telefone},{pessoa.Nascimento}";
        streamWriter.WriteLine(linha);
    }

}

static void LerCsv()
{
    var path = Path.Combine(Environment.CurrentDirectory, "ArquivoEntrada", "usuarios-exportacao.csv");
    using var streamReader = new StreamReader(path);
    if(File.Exists(path))
    {
        var cabecalho = streamReader.ReadLine()?.Split(',');
        while(true)
        {
            var registro = streamReader.ReadLine()?.Split(',');
            if(registro == null) break;
            if(cabecalho.Length != registro.Length)
            {
                Console.WriteLine("Arquivo fora do padrão");
                break;
            }
            for( int i = 0; i < registro.Length; i++)
            {
                Console.WriteLine($"{cabecalho?[i]}:{registro?[i]}");
            }
            Console.WriteLine("-------------------------");
        }
    }
    else
    {
        Console.WriteLine($"O arquivo {path} não existe!");
    }
}


class Pessoa
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Telefone { get; set; }
    public DateOnly Nascimento { get; set; }
}