// See https://aka.ms/new-console-template for more information
using OtusEvents.Classes;

#region Задача по GetMax
// Создание коллекции 
List<MyCustomClass> listObj = new List<MyCustomClass>();
for (var i = 0; i < 100; i++)
{
    listObj.Add(new MyCustomClass());
}

// Делегат для GetMax
Func<MyCustomClass, float> getmax = (x) => x.GetHashCode(); 

Console.WriteLine($"Max: Delegate: {listObj.GetMax(getmax).variable}, Internal: {listObj.GetMax().variable}");
//Console.WriteLine(String.Join('\n', listObj.Select(s => $"Number: {s.variable}\t Hash: {s.GetHashCode()}")));

#endregion

Console.WriteLine("");

#region Задача по event

var fs = new FileSeeker("c:\\windows");
fs.OnFileFound += Fs_onFileFound;
fs.RunSearchFiles();

void Fs_onFileFound(object? sender, FileSeekerArgs e)
{
    Console.WriteLine(e.FileName);
}


#endregion