
var path = @"C:\Projetos\Estudo\working-with-files-streams\Aula2\globo";

using var fileSystemWatch = new FileSystemWatcher(path);
fileSystemWatch.Created += OnCreated;
fileSystemWatch.Deleted += OnDeleted;
fileSystemWatch.Renamed += OnRenamed;

fileSystemWatch.EnableRaisingEvents = true;
fileSystemWatch.IncludeSubdirectories = true;

Console.WriteLine($"Monitoramento de eventos da pasta {path}");
Console.WriteLine("Tecle [enter] para sair...");
Console.ReadLine();

void OnCreated(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"Foi criado o arquivo {e.Name}");
}


void OnDeleted(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"Foi deletado o arquivo {e.Name}");
}


void OnRenamed(object sender, RenamedEventArgs e)
{
    Console.WriteLine($"Foi renomeado o arquivo {e.OldName}");
}