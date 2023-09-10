CreateDirectoryGlobo();
CreateFile();
var pathOrigem = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
var pathDestino = Path.Combine(Environment.CurrentDirectory, "globo", "America_do_Sul", "ARGENTINA", "argentina.txt");
CopyFile(pathOrigem, pathDestino);

static void CopyFile(string pathOrigem, string pathDestine)
{
    if(!File.Exists(pathOrigem))
    {
        Console.WriteLine("Arquivo de origem não existe");
        return;
    }
    if(File.Exists(pathDestine))
    {
        Console.WriteLine("Arquivo já existe na pasta de destino");
        return;
    }
    File.Copy(pathOrigem, pathDestine);
}


static void MoveFile(string pathOrigem, string pathDestine)
{
    if(!File.Exists(pathOrigem))
    {
        Console.WriteLine("Arquivo de origem não existe");
        return;
    }
    if(File.Exists(pathDestine))
    {
        Console.WriteLine("Arquivo já existe na pasta de destino");
        return;
    }

    File.Move(pathOrigem, pathDestine);
}

static void CreateFile()
{
    var path = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
    if(!File.Exists(path))
    {
        using var streamWriter = File.CreateText(path);
        streamWriter.WriteLine("População: 213MM");
        streamWriter.WriteLine("IDH: 0,901");
        streamWriter.WriteLine("Dados Atualizado em: 20/04/2018");
    }
}

static void CreateDirectoryGlobo(){
    var path = Path.Combine(Environment.CurrentDirectory,"globo");

    if(!Directory.Exists(path)){
        var dirGlobo = Directory.CreateDirectory(path);

        var dirAmNorte = dirGlobo.CreateSubdirectory("America_do_Norte");
        var dirAmCentral = dirGlobo.CreateSubdirectory("America_Central");
        var dirAmSul = dirGlobo.CreateSubdirectory("America_do_Sul");

        dirAmNorte.CreateSubdirectory("USA");
        dirAmNorte.CreateSubdirectory("MEXICO");
        dirAmNorte.CreateSubdirectory("CANADA");

        dirAmCentral.CreateSubdirectory("COSTA_RICA");
        dirAmCentral.CreateSubdirectory("PANAMA");


        dirAmSul.CreateSubdirectory("BRASIL");
        dirAmSul.CreateSubdirectory("ARGENTINA");
        dirAmSul.CreateSubdirectory("PARAGUAI");
    }
}







