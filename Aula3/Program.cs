var path = @"C:\Projetos\Estudo\working-with-files-streams\Aula2\globo";
ReadFile(path);
// ReadDirectory(path);
Console.WriteLine("Digite <ENTER> pra finalizar!!!");
Console.ReadLine();


static void ReadFile(string path)
{
    var files = Directory.GetFiles(path,"*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
        var fileInfo = new FileInfo(file);
        Console.WriteLine($"[Nome]: {fileInfo.Name}");
        Console.WriteLine($"[Tamanho]: {fileInfo.Length}");
        Console.WriteLine($"[Ultimo Acesso]: {fileInfo.LastAccessTime}");
        Console.WriteLine($"[Pasta]: {fileInfo.DirectoryName}");
        Console.WriteLine($"[-----------------------------]");
    }
}

static void ReadDirectory(string path)
{
    if(Directory.Exists(path))
    {
        var directory = Directory.GetDirectories(path,"*",SearchOption.AllDirectories);
        foreach (var dir in directory)
        {
            var dirInfo = new DirectoryInfo(dir);
            Console.WriteLine($"[Nome]:{dirInfo.Name}");
            Console.WriteLine($"[Raiz]:{dirInfo.Root}");
            if(dirInfo.Parent != null){
                Console.WriteLine($"[Pai]:{dirInfo.Parent.Name}");
            }
            Console.WriteLine("--------------");
        }
    }
    else
    {
        Console.WriteLine($"Diretorio {path} não existe!");
    }
}