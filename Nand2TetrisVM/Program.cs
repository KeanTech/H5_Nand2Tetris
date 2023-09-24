using Microsoft.Extensions.DependencyInjection;
using Nand2TetrisVM.Core.Factories;
using Nand2TetrisVM.Core.FileHandlers;
using Nand2TetrisVM.Core.LogicConvertion;
using Nand2TetrisVM.Core.Managers;
using Nand2TetrisVM.Core.Setup;
using Nand2TetrisVM.Interfaces;
using Nand2TetrisVM.Models;
using System.Security.AccessControl;

var services = Startup.Initialize();

Run(services);


static void Run(IServiceProvider service)
{
    string? input;

    do
    {
        Console.Clear();
        Console.WriteLine("Enter path to .vm file:");
        input = Console.ReadLine();
    }
    while (string.IsNullOrEmpty(input));
    
    var fileHandler = service.GetRequiredService<FileHandler>();
    
    if (fileHandler == null)
    {
        Console.WriteLine($"Could not find service {nameof(FileHandler)}");
        Console.ReadKey();
        return;
    }

    List<ICommandLine> cmdLines = new List<ICommandLine>();

    try
    {
        var parser = service.GetRequiredService<ICommandParser>();
        var lines = fileHandler.ReadFile(input);
        cmdLines = parser.ParseLines(lines.ToArray());
        
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    var asmBuilder = service.GetRequiredService<AsmBuilder>();
    var asmLines = asmBuilder.BuildAsmLines(cmdLines);

    do
    {
        Console.Clear();
        Console.WriteLine("Enter path to put .asm file:\n");
        input = Console.ReadLine();
    }
    while (string.IsNullOrEmpty(input));

    fileHandler.WriteFile(input, asmLines);
    Console.Clear();
    Console.WriteLine("asm file created!");
    Console.ReadLine();
}