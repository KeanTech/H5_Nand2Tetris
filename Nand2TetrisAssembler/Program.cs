using Microsoft.Extensions.DependencyInjection;
using Nand2TetrisAssembler.Core.Assemblers;
using Nand2TetrisAssembler.Core.Converters;
using Nand2TetrisAssembler.Core.Helpers;
using Nand2TetrisAssembler.Core.Managers;
using Nand2TetrisAssembler.Interfaces;
using TestConsole.Core.Translators;

// Registre dependencies and add them to the serviceprovider
var services = new ServiceCollection()
    .AddSingleton<IAssemblyTranslator, AssemblyTranslator>()
    .AddSingleton<IAssembler, HackAssembler>()
    .AddSingleton<IBinaryConverter, BinaryConverter>()
    .AddSingleton<IDestHelper, DestHelper>()
    .BuildServiceProvider();


string inputFile = "C:\\Users\\KennethAndersen\\Desktop\\Logic\\nand2tetris\\nand2tetris\\projects\\06\\add\\Add.asm";
string outputFile = "C:\\Users\\KennethAndersen\\Desktop\\Logic\\nand2tetris\\nand2tetris\\projects\\06\\add\\Add.hack";

IAssembler assembler = services.GetService<IAssembler>() ?? throw new NullReferenceException();

AssembleManager assembleManager = new AssembleManager(assembler);

assembleManager.Assemble(inputFile, outputFile);

Console.WriteLine("Press any key to continue");
Console.ReadKey();